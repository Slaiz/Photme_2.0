using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Photme_PortableLibrary.Model;
using Photme_PortableLibrary.ViewModel;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace Photme_WPF.Helper
{
    //class Main
    //{
    //    public ICommand AddCommand { get; set; }
    //    public ICommand UploadCommand { get; set; }

    //    MainViewModel vm = new MainViewModel();
    //    BaseViewModel bm = new BaseViewModel();

    //    public Main()
    //    {
    //        UploadCommand = new Command(arg => UploadMethod());
    //        AddCommand = new Command(arg => AddMethod());
    //    }

    //    private void AddMethod()
    //    {
    //        if (vm.TextProperty1 == "" || vm.TextProperty2 == "")
    //        { MessageBox.Show("Please write all fields"); return; }

    //        vm.ItemsList.Add(new PhotoItem(vm.TextProperty1, vm.TextProperty2, vm.ImageBytes));
    //        bm.OnPropertyChanged(nameof(vm.ItemsList));

    //        vm.TextProperty1 = "";
    //        vm.TextProperty2 = "";
    //    }

    //    private void UploadMethod()
    //    {
    //        OpenFileDialog f = new OpenFileDialog();
    //        f.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
    //        if (f.ShowDialog() == true)
    //        {
    //            vm.ImagePathProperty = f.FileName;
    //            ImageConverter(f.FileName);
    //        }
    //    }

    //    private void ImageConverter(string path)
    //    {
    //        FileInfo fileInfo = new FileInfo(path);
    //        long imageFileLength = fileInfo.Length;
    //        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
    //        BinaryReader br = new BinaryReader(fs);
    //        vm.ImageBytes = br.ReadBytes((int)imageFileLength);
    //    }
    //}
}
