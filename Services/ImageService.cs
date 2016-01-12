using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace AndriiGro.ImageRecognition.KohonenSOM.Services
{
    public class ImageService
    {
        public byte[] ConvertBitmapImageToByteArray(BitmapImage image)
        {
            int stride = image.PixelWidth * 4;
            int size = image.PixelHeight * stride;
            byte[] pixels = new byte[size];

            image.CopyPixels(pixels, stride, 0);

            return pixels;
        }

        public Bitmap ConvertBitmapImageToBitmap(BitmapImage bitmapImage)
        {
            using (var outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }
    }
}
