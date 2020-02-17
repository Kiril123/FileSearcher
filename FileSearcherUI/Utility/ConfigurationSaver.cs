using FileSearcherUI.Models;

namespace FileSearcherUI.Utility
{
    /// <summary>
    /// Saves configuration as xml file.
    /// </summary>
    public class ConfigurationSaver : XMLSaver<ConfigurationModel>, IConfigurationSaver
    {
        /// <summary>
        /// Default save location.
        /// </summary>
        private static readonly string path = "Configuration.xml";
        /// <summary>
        /// Saves the model to an xml file.
        /// </summary>
        /// <param name="configuration">Model to save.</param>
        public void Save(ConfigurationModel configuration)
        {
            base.Save(configuration, path);
        }
        /// <summary>
        /// Loads the model from an xml file.
        /// </summary>
        /// <returns>Loaded model.</returns>
        public ConfigurationModel Load()
        {
            return base.Load(path);
        }
    }
}
