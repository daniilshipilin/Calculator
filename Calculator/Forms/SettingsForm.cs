using Calculator.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class SettingsForm : Form
    {
        #region AppSettings

        static readonly Dictionary<string, string> _settings = new Dictionary<string, string>
        {
            { "ConfigurationVer", "5" },
            { "HexDelimiter", "0x" },
            { "Base64Mode", "Text"},
            { "Crc32Checked", "True"},
            { "Elf32Checked", "True"},
            { "Md5Checked", "True"},
            { "Sha1Checked", "True"},
            { "Sha256Checked", "True"},
            { "Sha384Checked", "True"},
            { "Sha512Checked", "True"},
            { "RandomQty", "1000"},
            { "RandomMin", "-1000000"},
            { "RandomMax", "1000000"},
            { "DateTimeStringFormat", "dddd dd MMMM yyyy HH:mm:ss zzz" },
            { "PasswordQty", "10" },
            { "PasswordLength", "10" },
            { "PasswordCharset", "MIXALPHA_NUMERIC_ALL" }
        };

        #endregion

        #region Properties

        public string SettingsTextBoxText
        {
            get { return (settingsTextBox.Text); }
            set { settingsTextBox.Text = value; }
        }

        // flag, that indicates, if form should be loaded/shown
        public bool ShowForm { get; private set; } = true;

        #endregion

        public SettingsForm()
        {
            InitializeComponent();

            if (!AppSettings.AssemblyExist())
            {
                DialogResult dialogResult = MessageBox.Show("Configuration file doesn't exist!\n\nCreate default configuration file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        CreateConfigurationFile();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}\n{ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // let know the caller, that this form loading/displaying should be aborted
                    ShowForm = false;
                }
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            TopMost = Program.GlobalTopMost;

            try
            {
                ParseAppConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            PrintSettings();
        }

        private void CreateConfigurationFile()
        {
            var sb = new StringBuilder();

            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.AppendLine("<configuration>");
            sb.AppendLine("    <startup>");
            sb.AppendLine("        <supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.8\"/>");
            sb.AppendLine("    </startup>");
            sb.AppendLine("    <appSettings>");

            foreach (var pair in _settings)
            {
                sb.AppendLine($"        <add key=\"{pair.Key}\" value=\"{pair.Value}\"/>");
            }

            sb.AppendLine("    </appSettings>");
            sb.AppendLine("</configuration>");

            File.WriteAllText(string.Concat(Assembly.GetEntryAssembly().Location, ".config"), sb.ToString());

            AppSettings.RefreshAppSettings();
        }

        private void DeleteConfigurationFile()
        {
            File.Delete(string.Concat(Assembly.GetEntryAssembly().Location, ".config"));
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        /// <summary>
        /// Parse settings.
        /// </summary>
        private void ParseAppConfig()
        {
            // refresh appSettings section
            AppSettings.RefreshAppSettings();

            // check if app.config version is up to date
            if (AppSettings.ReadKey("ConfigurationVer") != _settings["ConfigurationVer"])
            {
                DialogResult dialogResult = MessageBox.Show("Configuration file is outdated!\n\nUpdate configuration file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    CreateConfigurationFile();
                }
                else
                {
                    // close the form
                    Close();
                    return;
                }
            }

            // copy settings keys to temporary list,
            // so that settings dictionary can be modified in the foreach loop
            List<string> tmpKeys = new List<string>(_settings.Keys);

            foreach (string key in tmpKeys)
            {
                _settings[key] = AppSettings.ReadKey(key);
            }
        }

        private void PrintSettings()
        {
            string output = string.Empty;
            int pairCounter = 0;

            foreach (var pair in _settings)
            {
                output += string.Format($"{pair.Key} = {pair.Value}");
                pairCounter++;

                // check, if it's not the last settings pair (append CR+LF)
                if (pairCounter < _settings.Count)
                {
                    output += Environment.NewLine;
                }
            }

            SettingsTextBoxText = output;
        }

        private void RefreshSettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                ParseAppConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            PrintSettings();
        }

        private void SettingsTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                settingsTextBox.SelectAll();
            }
        }

        private void DeleteConfigFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppSettings.AssemblyExist())
                {
                    DialogResult dialogResult = MessageBox.Show("Delete configuration file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        DeleteConfigurationFile();

                        MessageBox.Show("Configuration file deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void UpdateSettingsButton_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Test");

        //if (!AppSettings.KeyExist("TestKey"))
        //{
        //    AppSettings.AddKey("TestKey", "Test value");
        //}
        //else
        //{
        //    AppSettings.UpdateKey("TestKey", "Ho-ho-ho!");
        //}

        // Test add custom region key
        //AppSettings.AddCustomRegionKey("NewTestRegion", "TestKey", "Test value");
        //}
    }
}