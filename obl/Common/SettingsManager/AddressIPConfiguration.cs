using System;
using System.Configuration;

namespace Common.SettingsManager
{
    public class AddressIPConfiguration : ISettingsManager
    {
        public string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key] ?? string.Empty;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                return string.Empty;
            }
        }
    }
}