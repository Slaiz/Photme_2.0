using System.Windows;
using Photme_WPF.Helper;
using Photme_WPF.View;
using Photme_PortableLibrary.DI;

namespace Photme_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityConteiner container = new IUnityConteiner();

            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
