namespace Photme_PortableLibrary.Model
{
    public class PhotoItem
    {
        private string _Name;
        private string _Note;
        private byte[] _image;

        public PhotoItem()
        {
        }

        public PhotoItem(string name, string note, byte[] image)
        {
            Name = name;
            Note = note;
            Image = image;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        public byte[] Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
