using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace View
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
