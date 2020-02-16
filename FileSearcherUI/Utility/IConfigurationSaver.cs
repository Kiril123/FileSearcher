using FileSearcherUI.Models;

namespace FileSearcherUI.Utility
{
    public interface IConfigurationSaver
    {
        ConfigurationModel Load();
        void Save(ConfigurationModel configuration);
    }
}