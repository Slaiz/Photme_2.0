using System.Collections.ObjectModel;
using System.Windows.Input;
using Photme_PortableLibrary.Model;

namespace Photme_PortableLibrary.ViewModel
{
    public class MainViewModel : PropertyChanger
    {

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

    }
}
