using Bank.Business.Portifolio.InfraStructure.Ioc;
using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;

namespace Bank.Business.Portifolio.Presenter.App_Start
{
    public class SimpleInjectorInitializer
    {
        public static Container container;
        public static Container Initialize()
        {
            container = new Container();
            container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();
            InitializeContainer(container);

            container.Verify();
            return container;
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}
