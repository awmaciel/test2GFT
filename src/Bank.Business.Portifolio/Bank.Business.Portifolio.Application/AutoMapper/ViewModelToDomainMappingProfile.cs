using AutoMapper;
using Bank.Business.Portifolio.Application.ViewsModel;
using Bank.Business.Portifolio.Domain.Entities;

namespace Bank.Business.Portifolio.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<BankViewModel, Domain.Entities.Bank>();
            CreateMap<ClientViewModel, Client>();
            CreateMap<CategoryBusinessViewModel, CategoryBusiness>();
            CreateMap<PortifolioViewModel, Domain.Entities.Portifolio>();
            CreateMap<PaymentViewModel, Payment>();
            CreateMap<BusinessViewModel, Domain.Entities.Business>();
        }
    }
}
