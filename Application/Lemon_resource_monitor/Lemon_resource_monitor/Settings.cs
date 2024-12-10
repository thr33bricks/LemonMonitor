using System.IO;
using System.Text.Json;

namespace Lemon_resource_monitor
{
    public class Settings
    {
        public bool AutoStart { get; set; } = true;
        public bool Background { get; set; } = true;
        public bool AutoPort { get; set; } = true;
        public string Port { get; set; } = "";

        private string settingsFilePath;

        public Settings(){}

        public Settings(string settingsFilePath)
        {
            this.settingsFilePath = settingsFilePath;

            if (!File.Exists(settingsFilePath))
            {
                SaveSettings();
            }

            CopyFrom(LoadSettings());
        }

        private void CopyFrom(Settings other)
        {
            this.AutoStart = other.AutoStart;
            this.Background = other.Background;
            this.AutoPort = other.AutoPort;
            this.Port = other.Port;
        }

        private Settings LoadSettings()
        {
            string json = File.ReadAllText(settingsFilePath);
            return JsonSerializer.Deserialize<Settings>(json);
        }

        public void SaveSettings()
        {
            string json = JsonSerializer.Serialize(
                this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(settingsFilePath, json);
        }
    }
 }
