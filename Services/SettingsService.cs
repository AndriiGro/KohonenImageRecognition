using System.Configuration;
using System.Windows;

namespace AndriiGro.ImageRecognition.KohonenSOM.Services
{
    public class SettingsService
    {
        public string GetSettingValueByKey(string key)
        {
            string settingValue = string.Empty;

            try
            {
                settingValue = ConfigurationManager.AppSettings[key];
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error reading app settings");
            }
            
            return settingValue;
        }
    }
}
