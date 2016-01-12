using System.Windows.Media;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;

namespace AndriiGro.ImageRecognition.KohonenSOM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            //to change default accent color
            AppearanceManager.Current.AccentColor = Color.FromRgb(0x00, 0x8a, 0x00);

            InitializeComponent();
        }
    }
}
