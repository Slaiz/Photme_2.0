using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Photme_PortableLibrary.ViewModel;


namespace Photme_PortableLibrary.Service
{
    public sealed class Service
    {
        private readonly UnityContainer _unityContainer;

        public MainViewModel MainViewModel
        {
            get { return _unityContainer.Resolve<MainViewModel>(); }
        }

        public Service()
        {
            _unityContainer = new UnityContainer();

            _unityContainer.RegisterType<IImageLoader, Main>();

            _unityContainer.Resolve<IImageLoader>();
        }
    }
}