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
        public string[] ValidateTxt(string[] LinesTxt)
        {
            string[] str = Array.Empty<string>();
            Domain.Entities.Business business = new Domain.Entities.Business();

            if (business.ValidateTxt(LinesTxt))
                InputDataTxt(LinesTxt);
            else
                str = new string[1] { "O arquivo não possui uma formatação correto" };

            return str;
        }
        public void InputDataTxt(string[] LinesTxt)
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
            var IdCategoryBusiness = ValidateClient(business.IdClient, business.ValueBusiness);

            if (IdCategoryBusiness != 0)
                business.IdCategoryBusiness = IdCategoryBusiness;

            return (business,pay);
        }            

        /*Return Category Client*/
        private int ValidateClient(int IdClient, decimal valueBusiness)
        {
            var client = _ClientRepository.GetById(IdClient);
            if (valueBusiness < 1000000 && client.SectorClient == "Private")
                return 1; 
            else if(valueBusiness > 1000000 && client.SectorClient == "Private")
                return 3;

            if (valueBusiness < 1000000 && client.SectorClient == "Public")
                return 1;
            else if (valueBusiness > 1000000 && client.SectorClient == "Public")
                return 2;

            return 0;
        }
    }
}
