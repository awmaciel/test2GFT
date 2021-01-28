using Bank.Business.Portifolio.Application;
using Bank.Business.Portifolio.Application.AutoMapper;
using Bank.Business.Portifolio.Application.Interfaces;
using Bank.Business.Portifolio.Domain.Interfaces.ICrossCutting;
using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;
using Bank.Business.Portifolio.Domain.Interfaces.IServicesDomain;
using Bank.Business.Portifolio.Domain.Services;
using Bank.Business.Portifolio.InfraStructure.CrossCutting.FileHandle.Strategy;
using Bank.Business.Portifolio.InfraStructure.Repository;
using Bank.Business.Portifolio.Presenter.App_Start;
using SimpleInjector;
using System;
using System.Text;

namespace Bank.Business.Portifolio.Presenter
{
    class Program
    {        
        static void Main(string[] args)
        {
            SimpleInjectorInitializer.Initialize();
            AutoMapperConfig.RegisterMappings();

            while (true)
            {
                Console.WriteLine("Digite o endereço do arquivo e tecle Enter ou Q para sair");
                var getKey = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("");

                if (getKey.ToUpper() == "Q")
                    break;

                Console.WriteLine(GetFile(getKey));
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
            }
        }
        public static string GetFile(string endPoint)
        {
            StringBuilder Sb = new StringBuilder();
            var container = new Container();
            var lifeStyle = Lifestyle.Singleton;
            container.Register<IBusinessAppService, BusinessAppService>(lifeStyle);
            container.Register<IFileHandle, FileHandleStrategy>(lifeStyle);
            container.Register<IBusinessService, BusinessService>(lifeStyle);
            container.Register<IBusinessRespository, BusinessRepository>(lifeStyle);
            container.Register<IClientRepository, ClientRepository>(lifeStyle);
            container.Register<ICategoryBusinessRespository, CategoryBusinessRespository>(lifeStyle);
            container.Register<IPaymentRepository, PaymentRepository>(lifeStyle);
             
            var bl = container.GetInstance<IBusinessAppService>();
            
            var result = bl.AddBusiness(endPoint);
            foreach(var item in result)
            {
                Sb.AppendLine(item);
            }
            return Sb.ToString();
        }
    }
}
