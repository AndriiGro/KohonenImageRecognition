using System.Windows;
using System.Configuration;

namespace Services
{
    public class SettingsService
    {
        public string GetSettingValueByKey(string key)
        {
            string settingValue = "";

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
