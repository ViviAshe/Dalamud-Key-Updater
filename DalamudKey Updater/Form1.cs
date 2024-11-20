using DalamudKey_Updater.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DalamudKey_Updater
{
    public partial class Form1 : Form
    {

        private const string BranchInfoUrl = "https://kamori.goats.dev/Dalamud/Release/Meta";
        private Dictionary<string, VersionEntry> branches;
        private string rawjson;
        private bool ready = false;
        private List<VersionEntry> versions = new List<VersionEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        private void requesttimer_Tick(object sender, EventArgs e)
        {
            if (!ready)
            {
                label1.Text = "Loading branches...";
                return;
            }

            BranchComboBox.Items.AddRange(versions.ToArray());
            BranchComboBox.SelectedIndex = 0;

            requesttimer.Enabled = false;

            label1.Text = "Select a branch";
            //MessageBox.Show(rawjson);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                using (WebClient wc = new WebClient())
                {
                    rawjson = wc.DownloadString(BranchInfoUrl);
                    Console.WriteLine(rawjson);

                    branches = JsonConvert.DeserializeObject<Dictionary<string, VersionEntry>>(rawjson);
                    Console.WriteLine(branches);


                    foreach(var item in branches)
                    {
                        versions.Add(item.Value);
                    }

                    Console.WriteLine($"{versions.Count} versions to select");

                    ready = true;
                }
            });
        }


        private class VersionEntry
        {
            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("track")]
            public string Track { get; set; }

            [JsonProperty("assemblyVersion")]
            public string AssemblyVersion { get; set; }

            [JsonProperty("runtimeVersion")]
            public string RuntimeVersion { get; set; }

            [JsonProperty("runtimeRequired")]
            public bool RuntimeRequired { get; set; }

            [JsonProperty("supportedGameVer")]
            public string SupportedGameVer { get; set; }

            [JsonProperty("downloadUrl")]
            public string DownloadUrl { get; set; }

            [JsonProperty("gitSha")]
            public string GitSha { get; set; }

            public override string ToString()
            {
                return Track.ToString();
            }
        }

        private void SaveBranchButton_Click(object sender, EventArgs e)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.Combine(appDataPath, "XIVLauncher", "DalamudConfig.json");
            VersionEntry selected = BranchComboBox.SelectedItem as VersionEntry;

            try
            {
                string jsonContent = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(jsonContent);

                jsonObject["DalamudBetaKey"] = selected.Key;
                jsonObject["DalamudBetaKind"] = selected.Track;

                string updatedJsonContent = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

                File.WriteAllText(filePath, updatedJsonContent);

                Console.WriteLine("JSON file updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
