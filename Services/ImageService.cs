using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using AndriiGro.ImageRecognition.KohonenSOM.Entities;

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

        public List<BitmapImage> ConvertBitmapsToBitmapImages(List<Bitmap> bitmaps)
        {
            var bitmapImagesList = new List<BitmapImage>();

            bitmaps.ForEach(bitmap =>
            {
                bitmapImagesList.Add(ConvertBitmapToBitmapImage(bitmap));
            });

            return bitmapImagesList;
        }

        public BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        public List<Bitmap> ConvertObjectImagestoBitmaps(List<ObjectImage> images)
        {
            var bitmaps = new List<Bitmap>();

            images.ForEach(image =>
            {
                bitmaps.Add(ConvertObjectImageToBitmap(image));
            });

            return bitmaps;
        }

        public Bitmap ConvertObjectImageToBitmap(ObjectImage image)
        {
            //max possible size of object
            var bitmap = new Bitmap(
                Parameters.LoadedBitmapToRecognize.Width, 
                Parameters.LoadedBitmapToRecognize.Height);

            image.ObjectPixelsList.ForEach(pixel =>
            {
                bitmap.SetPixel(
                    pixel.ImagePixelPosition.X, 
                    pixel.ImagePixelPosition.Y, 
                    pixel.ImagePixelColor);
            });

            return bitmap;
        }
    }
}
