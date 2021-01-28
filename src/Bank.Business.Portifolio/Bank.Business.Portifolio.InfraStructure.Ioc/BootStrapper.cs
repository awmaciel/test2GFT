using Bank.Business.Portifolio.Application;
using Bank.Business.Portifolio.Application.Interfaces;
using Bank.Business.Portifolio.Domain.Interfaces.ICrossCutting;
using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;
using Bank.Business.Portifolio.Domain.Interfaces.IServicesDomain;
using Bank.Business.Portifolio.Domain.Services;
using Bank.Business.Portifolio.InfraStructure.CrossCutting.FileHandle.Strategy;
using Bank.Business.Portifolio.InfraStructure.Repository;
using SimpleInjector;
using System.Linq;

namespace Bank.Business.Portifolio.InfraStructure.Ioc
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // Repository
            container.Register<IBankRespository, BankRepository>(Lifestyle.Scoped);
            container.Register<IClientRepository, ClientRepository>(Lifestyle.Scoped);
            container.Register<IBusinessRespository, BusinessRepository>(Lifestyle.Scoped);
            container.Register<ICategoryBusinessRespository, CategoryBusinessRespository>(Lifestyle.Scoped);
            container.Register<IPortifolioRepository, PortifolioRepository>(Lifestyle.Scoped);
            container.Register<IPaymentRepository, PaymentRepository>(Lifestyle.Scoped);
            container.RegisterConditional(typeof(IRepository<>),typeof(Repository<>),c => c.ServiceType.GetGenericArguments().Single().Namespace.Contains("Bank"));

            //App
            container.Register<IBusinessAppService, BusinessAppService>(Lifestyle.Scoped);

            //container.Register<IBusinessAppService, BusinessAppService>(Lifestyle.Scoped);
            //container.Register<ICategoryAppService, CategoryAppService>(Lifestyle.Scoped);
            //container.Register<IPortifolioAppService, PortifolioAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<IBusinessService, BusinessService>(Lifestyle.Scoped);

            //CrossCutting
            container.Register<IFileHandle, FileHandleStrategy>(Lifestyle.Scoped);
            
        }
    }
}
