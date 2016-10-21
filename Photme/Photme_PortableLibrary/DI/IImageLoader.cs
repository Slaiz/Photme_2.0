using System.Runtime.InteropServices.ComTypes;

namespace Photme_PortableLibrary.DI
{
    public interface IImageLoader
    {
        void ImageLoad();
        //void ImageConverter<T>(T other);
        string SayHello();
    }
}