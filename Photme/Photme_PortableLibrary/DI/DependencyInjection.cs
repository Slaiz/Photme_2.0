using System.Dynamic;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Photme_PortableLibrary.ViewModel;


namespace Photme_PortableLibrary.DI
{
    public static class DependencyInjection
    {
        public static IUnityContainer _unityContainer { get; private set; }

        public static void Initialize(IUnityContainer container)
        {
            _unityContainer = container;

            _unityContainer.RegisterType<IImageLoader, ImageLoader>(new ContainerControlledLifetimeManager());

            _unityContainer.Resolve<ImageLoader>();
        }
    }
}