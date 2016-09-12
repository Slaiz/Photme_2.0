using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Photme_PortableLibrary.Model;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace Photme_WPF.ViewModel
{
    class MainViewModel : PropertyChanger
    {
        public ICommand ClickCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UploadCommand { get; set; }

        private ObservableCollection<PhotoItem> itemsList = new ObservableCollection<PhotoItem>();

        public ObservableCollection<PhotoItem> ItemsList
        {
            get { return itemsList; }
        }

        private string _textProperty1;

        private string _textProperty2;

        private string _imagePathProperty;

        private byte[] _imageBytes;

        public string TextProperty1
        {
            get
            {
                return _textProperty1;
            }
            set
            {
                if (_textProperty1 != value)
                {
                    _textProperty1 = value;
                    OnPropertyChanged(nameof(TextProperty1));
                }
            }
        }

        public string TextProperty2
        {
            get
            {
                return _textProperty2;
            }
            set
            {
                if (_textProperty2 != value)
                {
                    _textProperty2 = value;
                    OnPropertyChanged(nameof(TextProperty2));
                }
            }
        }

        public string ImagePathProperty
        {
            get { return _imagePathProperty; }
            set
            {
                _imagePathProperty = value;
                OnPropertyChanged(nameof(ImagePathProperty));
            }
        }

        public byte[] ImageBytes
        {
            get { return _imageBytes; }
            set
            {
                _imageBytes = value;
                OnPropertyChanged(nameof(ImageBytes));
            }
        }

        public MainViewModel()
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
