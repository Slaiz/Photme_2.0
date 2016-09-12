using System.Windows;
using Photme_WPF.Helper;
using Photme_WPF.View;

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
                DataContext = new Main()
            };

            mw.Show();
        }
    }
}
