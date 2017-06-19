using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace ACEManager
{
    
    public struct Config
    {
        [DefaultValue("%SYSTEMROOT%//ACEmulator//")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AppRootDirectory { get; set; }

        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool SaveLogFile { get; set; }

        [DefaultValue(@"ACEManagerLog_")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LocalLogPath { get; set; }

        [DefaultValue("yyyy-M-dd_HH-mm-ss")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LogFilenameFormat { get; set; }

        [DefaultValue("yyyy-M-dd_HH-mm-ss.ffff")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LogDataFormat { get; set; }

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool EnableAutoRestart { get; set; }

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool AnnounceEvents { get; set; }
    }

    public static class ConfigManager
    {
        public static bool ConfigurationLoaded { get; set; } = false;

        public static Config Configuration { get; set; }

        public static string ConfigFile { get; private set; }

        public static void Initialize()
        {
            ConfigFile = @"Config.json";
            
            if (!File.Exists(ConfigFile))
            {
                ApplyDefaults();
                Save();
            }
            else
            {
                try
                {
                    Configuration = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigFile));
                }
                //catch (System.IO.IOException exception)
                //{
                //    MessageBox.Show("Please verify that your Config.json file is in the proper format (json) and is placed in the same folder, as this application. You may use the Config.json.example file, too create a new config.\n\nError Details:\n\n" + exception.ToString(), "Configuration missing error", MessageBoxButtons.OK);
                //}
                catch (Exception exception)
                {
                    Console.WriteLine("An exception occured while loading the configuration file!");
                    Console.WriteLine($"Exception: {exception.Message}");
                    throw;
                }
                finally
                {
                    ConfigurationLoaded = true;
                }
            }
        }

        public static void ApplyDefaults()
        {
            Configuration = new Config() { AppRootDirectory = "%SYSTEMROOT%//ACEmulator//", EnableAutoRestart = false, AnnounceEvents = false, SaveLogFile = true, LocalLogPath = @"ACEManagerLog_", LogDataFormat = "yyyy-M-dd_HH-mm-ss.ffff", LogFilenameFormat = "yyyy-M-dd_HH-mm-ss" };
            ConfigurationLoaded = true;
        }

        public static void Save()
        {
            try
            {
                File.WriteAllText(ConfigFile, JsonConvert.SerializeObject(Configuration, Formatting.Indented));
            }
            catch (Exception exception)
            {
                Console.WriteLine("An exception occured while saving the configuration file!");
                Console.WriteLine($"Exception: {exception.Message}");
                throw;
            }
        }
    }
}