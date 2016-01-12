using System.Windows;
using System.Windows.Threading;

namespace AndriiGro.ImageRecognition.KohonenSOM.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void HandleUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // To handle exceptions globally
            MessageBox.Show("Exception message: " + e.Exception.Message, "Unhandled exception");
            e.Handled = true;
        }
    }
}
