using Bank.Business.Portifolio.Domain.Dto;
using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;
using Bank.Business.Portifolio.Domain.Interfaces.IServicesDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank.Business.Portifolio.Domain.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRespository _BusinessRespository;
        private readonly IClientRepository _ClientRepository;
        private readonly ICategoryBusinessRespository _CategoryRepository;
        private readonly IPaymentRepository _PaymentRepository;
        public BusinessService(IBusinessRespository BusinessRespository,
                               IClientRepository ClientRepository,
                               ICategoryBusinessRespository CategoryRepository,
                               IPaymentRepository PaymentRepository)
        {
            _BusinessRespository = BusinessRespository;
            _ClientRepository = ClientRepository;
            _CategoryRepository = CategoryRepository;
            _PaymentRepository = PaymentRepository;
        }
        public List<Trade> ValidateTxt(string[] LinesTxt)
        {
            List<Trade> str = new  List<Trade>();
            Domain.Entities.Business business = new Domain.Entities.Business();

            if (business.ValidateTxt(LinesTxt))
                InputDataTxt(LinesTxt);
            else
            {
                str[0].Note = "O arquivo não possui uma formatação correto";
                return str;
            }

            return GetClientByBusinessCategory();
        }
        private void InputDataTxt(string[] LinesTxt)
        {
            int cont = 0;
            Domain.Entities.Business business = new Domain.Entities.Business();
           
            List<Domain.Entities.Business> lstBusiness = new List<Domain.Entities.Business>();

            foreach (var item in LinesTxt)
            {
                if (cont == 0)
                    business.DateReference = Convert.ToDateTime(item);
                if (cont == 1)
                    business.IdPortifolio = Convert.ToInt32(item);

                if (cont >= 2)
                {
                    var arr = item.Split(' ');
                    var result = InputDataTxtAux(arr, business);
                    _BusinessRespository.Add(result.Item1);
                    result.Item2.IdBusiness = result.Item1.IdBusiness;
                    _PaymentRepository.Add(result.Item2);
                }

                cont++;
            }            
        }

        private List<Trade> GetClientByBusinessCategory()
        {
            var result = _BusinessRespository.GetClientByCategories();
            Trade trade = null;
            List<Trade> LstTrade = new List<Trade>();

            foreach (var item in result)
            {
                trade = new Trade();
                trade.NameClient = item.Client.NameClient;
                trade.SectorClient = item.Client.SectorClient;
                trade.CategoryClient = item.CategoryBusiness.NameCategory;
                trade.NamePortifolio = item.Portifolio.NameProtifolio;
                trade.ValueInvestment = item.ValueBusiness;
                trade.DateNextPayment = _PaymentRepository.GetAll().Where(x => x.IdBusiness == item.IdBusiness).Select(c => c.DateTimeNextPayment).LastOrDefault();
                LstTrade.Add(trade);
            }
            return LstTrade;
        }
        private (Domain.Entities.Business, Domain.Entities.Payment) InputDataTxtAux(string[] LinesTxt, Domain.Entities.Business business)
        {
            int contArr = 0;
            Entities.Payment pay = null;

            foreach (var item in LinesTxt)
            {
                if (contArr == 0)
                    business.ValueBusiness = Convert.ToDecimal(item);
                if (contArr == 1)
                {
                    //cli = new Entities.Client();
                    //cli.IdBank = 1;
                    //cli.NameClient = "teste" + contArr.ToString();
                    //cli.SectorClient = item;
                }
                if (contArr == 2)
                {
                    pay = new Entities.Payment();
                    pay.paid = true;
                    pay.IdBusiness = business.IdBusiness;
                    pay.DateTimeNextPayment = Convert.ToDateTime(item);
                }
                contArr++;
            }
            business.IdClient = 1;
            business.DateRegister = DateTime.Now;
            business.DateUpdate = null;
            var IdCategoryBusiness = ValidateClient(business.IdClient, business,pay);

            if (IdCategoryBusiness != 0)
                business.IdCategoryBusiness = IdCategoryBusiness;

            return (business,pay);
        }            

        /*Return Category Client*/
        private int ValidateClient(int IdClient, Domain.Entities.Business Business, Entities.Payment pay)
        {            
            var client = _ClientRepository.GetById(IdClient);
            if (Business.ValueBusiness < 1000000 && client.SectorClient == "Private" && !(pay.DateTimeNextPayment.Subtract(Business.DateReference).Days < -30))
                return 4; 
            else if(Business.ValueBusiness > 1000000 && client.SectorClient == "Private" && !(pay.DateTimeNextPayment.Subtract(Business.DateReference).Days < -30))
                return 3;

            if (Business.ValueBusiness < 1000000 && client.SectorClient == "Public" && !(pay.DateTimeNextPayment.Subtract(Business.DateReference).Days < -30))
                return 4;
            else if (Business.ValueBusiness > 1000000 && client.SectorClient == "Public")
                return 3;            

            return 1;
        }
    }
}
