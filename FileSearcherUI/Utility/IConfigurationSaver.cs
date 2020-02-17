using FileSearcherUI.Models;

namespace FileSearcherUI.Utility
{
    /// <summary>
    /// Saves configuration to a file.
    /// </summary>
    public interface IConfigurationSaver
    {
        /// <summary>
        /// Loads the model from a file.
        /// </summary>
        /// <returns>Loaded model.</returns>
        ConfigurationModel Load();
        /// <summary>
        /// Saves the model to a file.
        /// </summary>
        /// <param name="configuration">Model to save.</param>
        void Save(ConfigurationModel configuration);
    }
}