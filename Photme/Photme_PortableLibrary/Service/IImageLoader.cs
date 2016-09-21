using System.Runtime.InteropServices.ComTypes;

namespace Photme_PortableLibrary.Service
{
    public interface IImageLoader
    {
        void ImageLoad();

        void ImageConverter<T>(T other);
    }
}