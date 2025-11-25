using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Lemon_resource_monitor
{
    public class Settings
    {
        public bool AutoStart { get; set; } = true;
        public bool Background { get; set; } = true;
        public bool AutoPort { get; set; } = true;
        public string Port { get; set; } = "";

        public bool Scrolling { get; set; } = true;
        public bool Dividers { get; set; } = false;
        public bool Sound { get; set; } = false;
        public string KeyLeft1 { get; set; } = "Alt";
        public string KeyRight1 { get; set; } = "Alt";
        public Keys KeyLeft2 { get; set; } = Keys.Q;
        public Keys KeyRight2 { get; set; } = Keys.E;

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

            this.Scrolling = other.Scrolling;
            this.Dividers = other.Dividers;
            this.Sound = other.Sound;
            this.KeyLeft1 = other.KeyLeft1;
            this.KeyRight1 = other.KeyRight1;
            this.KeyLeft2 = other.KeyLeft2;
            this.KeyRight2 = other.KeyRight2;
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
