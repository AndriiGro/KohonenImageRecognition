using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace AndriiGro.ImageRecognition.KohonenSOM.Services
{
    public static class Parameters
    {
        private static readonly ImageService ImageService = new ImageService();
        
        public static Bitmap LoadedBitmapToRecognize { get; set; } = new Bitmap(1, 1);

        private static BitmapImage _loadedBitmapImageToRecognize = new BitmapImage();

        public static BitmapImage LoadedBitmapImageToRecognize
        {
            get
            {
                return _loadedBitmapImageToRecognize;
            }

            set
            {
                _loadedBitmapImageToRecognize = value;
                LoadedBitmapToRecognize = 
                    ImageService.ConvertBitmapImageToBitmap(value);
            }
        }

        public static Bitmap CurrentKohonenNetworkBitmap { get; set; } = new Bitmap(1, 1);

        private static BitmapImage _currentKohonenNetworkBitmapImage = new BitmapImage();

        public static BitmapImage CurrentKohonenNetworkBitmapImage
        {
            get
            {
                return _currentKohonenNetworkBitmapImage;
            }

            set
            {
                _currentKohonenNetworkBitmapImage = value;
                CurrentKohonenNetworkBitmap = ImageService.ConvertBitmapImageToBitmap(value);
            }
        }

        private static List<Bitmap> _foundObjectsImagesList = new List<Bitmap>();

        public static List<Bitmap> FoundObjectsImagesList
        {
            get
            {
                return _foundObjectsImagesList;
            }
            set
            {
                _foundObjectsImagesList = value;
                FoundObjectsBitmapImages = 
                    ImageService.ConvertBitmapsToBitmapImages(value);
            }
        }

        public static List<BitmapImage> FoundObjectsBitmapImages { get; set; } = new List<BitmapImage>();

        public static int CurrentCarouselImagePosition = 0;
    }
}
