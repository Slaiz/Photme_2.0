using System.Windows;
using Photme_WPF.View;
using Photme_WPF.ViewModel;

namespace Photme_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            var mw = new MainWindow
            {
                DataContext = new MainViewModel()
            };

            mw.Show();
        }
    }
}
