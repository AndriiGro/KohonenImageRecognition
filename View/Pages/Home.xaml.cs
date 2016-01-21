using System.Threading.Tasks;
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

        private async void ButtonGroupObjectsByCluster_Click(object sender, RoutedEventArgs e)
        {
            ButtonGroupObjectsByCluster.IsEnabled = false;

            var objectsClassificationTask = new Task(
                () =>
                {
                    _kohonenNetworkService.GroupObjectsByColorFromImageToRecongnize();
                }
                );

            objectsClassificationTask.Start();
            await objectsClassificationTask;

            ButtonGroupObjectsByCluster.IsEnabled = true;

            ImageContainerCarousel.Source = 
                Parameters.FoundObjectsBitmapImages[Parameters.CurrentCarouselImagePosition];
            ButtonNext.IsEnabled = true;
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if (Parameters.CurrentCarouselImagePosition <= Parameters.FoundObjectsBitmapImages.Count)
            {
                Parameters.CurrentCarouselImagePosition++;
            }
            else
            {
                Parameters.CurrentCarouselImagePosition = 0;
            }

            ImageContainerCarousel.Source =
                Parameters.FoundObjectsBitmapImages[Parameters.CurrentCarouselImagePosition];
        }
    }
}
