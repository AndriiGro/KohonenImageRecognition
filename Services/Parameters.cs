using System.Drawing;
using System.Windows.Media.Imaging;

namespace Services
{
    public static class Parameters
    {
        private static readonly ImageService _imageService = new ImageService();

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
                    _imageService.ConvertBitmapImageToBitmap(value);
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
                CurrentKohonenNetworkBitmap = _imageService.ConvertBitmapImageToBitmap(value);
            }
        }
    }
}
