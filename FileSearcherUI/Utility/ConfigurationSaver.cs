using FileSearcherUI.Models;
using System;
using System.IO;
using System.Xml.Serialization;

namespace FileSearcherUI.Utility
{
    public class ConfigurationSaver : IConfigurationSaver
    {
        private static readonly string path = "Configuration.xml";
        public void Save(ConfigurationModel configuration)
        {
            XmlSerializer serializer = new XmlSerializer(configuration.GetType());
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, configuration);
            }
        }

        public ConfigurationModel Load()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ConfigurationModel));
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    ConfigurationModel configuration = deserializer.Deserialize(file) as ConfigurationModel;
                    return configuration;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
