using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Calculator.Helpers
{
    public static class AppSettings
    {
        public static bool AssemblyExist()
        {
            return File.Exists(Assembly.GetEntryAssembly().Location + ".config");
        }

        public static void ReadAllKeys()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings are empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading App settings");
            }
        }

        public static string ReadKey(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;

            return appSettings[key] ?? throw new ConfigurationErrorsException(); ;
        }

        public static bool KeyExist(string key)
        {
            return ConfigurationManager.AppSettings.AllKeys.Contains(key);
        }

        public static void UpdateKey(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            RefreshAppSettings();
        }

        public static void AddKey(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            RefreshAppSettings();
        }

        public static void DeleteKey(string key)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.Save(ConfigurationSaveMode.Modified);
            RefreshAppSettings();
        }

        public static void RefreshAppSettings()
        {
            ConfigurationManager.RefreshSection("appSettings");
        }

        #region Custom configuration sections

        // Custom configuration sections
        //public void AddCustomRegionKey(string region, string key, string value)
        //{
        //    var xmlDoc = new XmlDocument();
        //    xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

        //    // create new node <add key="Key" value="1234" />
        //    var nodeRegion = xmlDoc.CreateElement("add");

        //    nodeRegion.SetAttribute("key", key);
        //    nodeRegion.SetAttribute("value", value);

        //    xmlDoc.SelectSingleNode($"//{region}").AppendChild(nodeRegion);
        //    xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

        //    ConfigurationManager.RefreshSection($"{region}");
        //}

        #endregion
    }
}
