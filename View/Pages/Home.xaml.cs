using System.Windows;
using AndriiGro.ImageRecognition.KohonenSOM.Services;

namespace AndriiGro.ImageRecognition.KohonenSOM.View.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home
    {
        private readonly FileService _fileService = new FileService();
        private readonly KohonenNetworkService _kohonenNetworkService 
            = new KohonenNetworkService();

        public Home()
        {
            InitializeComponent();
            ImageContainerKononenNetwork.Source =
                _fileService.GetKononenNetworkImageFromDefaultPath();
        }

        private void ButtonLoadImage_Click(object sender, RoutedEventArgs e)
        {
            _fileService.SaveBitmapImageForRecognitionToParameters();
            ImageContainerMain.Source = Parameters.LoadedBitmapImageToRecognize;
        }

        private void ButtonGroupObjectsByCluster_Click(object sender, RoutedEventArgs e)
        {
            _kohonenNetworkService.GroupObjectsByColorFromImageToRecongnize();
        }
    }
}
