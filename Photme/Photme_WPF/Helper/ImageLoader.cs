using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Photme_PortableLibrary.Model;
using Photme_PortableLibrary.DI;
using Photme_PortableLibrary.ViewModel;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace Photme_WPF.Helper
{
    class ImageLoader:IImageLoader
    {
        public ICommand AddCommand { get; set; }
        public ICommand UploadCommand { get; set; }

        public ImageLoader()
        {
            UploadCommand = new Command(arg => ImageLoad());
            //AddCommand = new Command(arg => ImageConverter<T>(T path));
        }

        public void ImageLoad()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
            //if (f.ShowDialog() == true)
            //{
            //    ImagePathProperty = f.FileName;
            //    ImageConverter(f.FileName);
            //}
        }

        //public void ImageConverter<T>(T path)
        //{
        //    string _path = path as string;

        //    FileInfo fileInfo = new FileInfo(_path);
        //    long imageFileLength = fileInfo.Length;
        //    FileStream fs = new FileStream(_path, FileMode.Open, FileAccess.Read);
        //    BinaryReader br = new BinaryReader(fs);
        //    ImageBytes = br.ReadBytes((int)imageFileLength);
        //}

        public string SayHello()
        {
            return "Hello!";
        }
    }
}
