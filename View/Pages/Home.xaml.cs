using System.Windows;
using Services;

namespace View.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home
    {
        private readonly FileService _fileService = new FileService();
        public Home()
        {
            InitializeComponent();
            ImageContainerKononenNetwork.Source =
                _fileService.GetKononenNetworkImageFromDefaultPath();
        }

        private void buttonLoadImage_Click(object sender, RoutedEventArgs e)
        {
            _fileService.SaveBitmapImageForRecognitionToParameters();
            ImageContainerMain.Source = Parameters.LoadedBitmapImageToRecognize;
        }
    }
}
