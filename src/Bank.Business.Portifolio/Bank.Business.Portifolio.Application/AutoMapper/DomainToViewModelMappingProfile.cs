using AutoMapper;
using Bank.Business.Portifolio.Application.ViewsModel;
using Bank.Business.Portifolio.Domain.Entities;

namespace Bank.Business.Portifolio.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Domain.Entities.Bank, BankViewModel>();
            CreateMap<Client, ClientViewModel>();
            CreateMap<CategoryBusiness, CategoryBusinessViewModel>();
            CreateMap<Domain.Entities.Portifolio, PortifolioViewModel>();
            CreateMap<Payment, PaymentViewModel>();
            CreateMap<Domain.Entities.Business, BusinessViewModel>();
        }
    }
}
