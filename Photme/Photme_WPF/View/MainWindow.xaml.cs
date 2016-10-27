using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using Photme_PortableLibrary.Model;
using Photme_PortableLibrary.ViewModel;
using Photme_PortableLibrary.DI;
using Photme_WPF.Helper;

namespace Photme_WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;

        public MainWindow()
        {
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;
            InitializeComponent();
                             
        }
    }
}
