using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Photme_PortableLibrary.Model;
using Photme_PortableLibrary.ViewModel;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace Photme_WPF.Helper
{
    class Main
    {
        public ICommand ClickCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UploadCommand { get; set; }

        public Main()
        {
            UploadCommand = new Command(arg => UploadMethod());
            AddCommand = new Command(arg => AddMethod());
        }

        private void AddMethod()
        {
            if (TextProperty1 == "" || TextProperty2 == "")
            { MessageBox.Show("Please write all fields"); return; }

            itemsList.Add(new PhotoItem(TextProperty1, TextProperty2, ImageBytes));
            OnPropertyChanged(nameof(ItemsList));

            TextProperty1 = "";
            TextProperty2 = "";
        }

        private void UploadMethod()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
            if (f.ShowDialog() == true)
            {
                ImagePathProperty = f.FileName;
                ImageConverter(f.FileName);
            }
        }

        private void ImageConverter(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageBytes = br.ReadBytes((int)imageFileLength);
        }
    }
}
