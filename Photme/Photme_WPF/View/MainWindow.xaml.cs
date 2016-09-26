using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using Photme_PortableLibrary.Model;
using Photme_PortableLibrary.ViewModel;

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
             
            //Buttton1.Click+=Buttton1OnClick;
            //Button2.Click += Button2OnClick;          
        }

        //private void Button2OnClick(object sender, RoutedEventArgs routedEventArgs)
        //{
        //    if (_mainViewModel.TextProperty1 == "" || _mainViewModel.TextProperty2 == "")
        //    { MessageBox.Show("Please write all fields"); return; }

        //    _mainViewModel.AddPhoto();
        //    bm.OnPropertyChanged(nameof(_mainViewModel.ItemsList));

        //    _mainViewModel.TextProperty1 = "";
        //    _mainViewModel.TextProperty2 = "";
        //}

        //private void Buttton1OnClick(object sender, RoutedEventArgs routedEventArgs)
        //{
        //    OpenFileDialog f = new OpenFileDialog();
        //    f.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
        //    if (f.ShowDialog() == true)
        //    {
        //        _mainViewModel.ImagePathProperty = f.FileName;
        //        ImageConverter(f.FileName);
        //    }
        //}

        //private void ImageConverter(string path)
        //{
        //    FileInfo fileInfo = new FileInfo(path);
        //    long imageFileLength = fileInfo.Length;
        //    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        //    BinaryReader br = new BinaryReader(fs);
        //    _mainViewModel.ImageBytes = br.ReadBytes((int)imageFileLength);
        //}
    }
}
