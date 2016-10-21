using System.Dynamic;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Photme_PortableLibrary.ViewModel;


namespace Photme_PortableLibrary.DI
{
    public static class DependencyInjection
    {
        private static UnityContainer _unityContainer { get; set; }

        public static void Initialize()
        {
            _unityContainer = new UnityContainer();

            _unityContainer.RegisterType<IImageLoader, Main>(new ContainerControlledLifetimeManager());

            _unityContainer.Resolve<MainViewModel>();
        }
    }
}