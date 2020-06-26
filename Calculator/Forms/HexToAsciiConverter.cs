using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Calculator.Helpers;

namespace Calculator
{
    public partial class HexToAsciiConverterForm : Form
    {
        #region Public properties

        // hexTextBox text
        public string HexTextBoxText
        {
            get { return (hexTextBox.Text); }
            set { hexTextBox.Text = value; }
        }

        // asciiTextBox text
        public string AsciiTextBoxText
        {
            get { return (asciiTextBox.Text); }
            set { asciiTextBox.Text = value; }
        }

        // asciiTextBox text
        public string HexDelimiterTextBoxText
        {
            get { return (hexDelimiterTextBox.Text); }
            set { hexDelimiterTextBox.Text = value; }
        }

        #endregion

        #region AppSettings

        static readonly List<string> _keys = new List<string>
        {
            "HexDelimiter"
        };

        #endregion

        #region Private fields

        // flag to activate settings update
        bool _settingsUpdateEnabled = false;

        #endregion

        public HexToAsciiConverterForm()
        {
            InitializeComponent();
        }

        private void HexToAsciiConverterForm_Load(object sender, EventArgs e)
        {
            HexDelimiterTextBoxText = string.Empty;

            // configuration check
            if (AppSettings.AssemblyExist())
            {
                if (AppSettings.KeyExist(_keys[0]))
                {
                    HexDelimiterTextBoxText = AppSettings.ReadKey(_keys[0]);
                }
            }

            _settingsUpdateEnabled = true;

            TopMost = Program.GlobalTopMost;
        }

        private void HexToAsciiConverterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void ConvertToAsciiButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HexTextBoxText))
            {
                MessageBox.Show($"HEX textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                AsciiTextBoxText = ConvertHexToAsciiString(HexTextBoxText, HexDelimiterTextBoxText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConvertToHexButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AsciiTextBoxText))
            {
                MessageBox.Show($"ASCII textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                HexTextBoxText = ConvertAsciiToHexString(AsciiTextBoxText, HexDelimiterTextBoxText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            HexTextBoxText = string.Empty;
            AsciiTextBoxText = string.Empty;
        }

        private void HexTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                hexTextBox.SelectAll();
            }
        }

        private void AsciiTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                asciiTextBox.SelectAll();
            }
        }

        #region HEX & ASCII convert methods

        private string ConvertHexToAsciiString(string hexString, string delimiter)
        {
            var sb = new StringBuilder();

            // remove whitespace chars
            hexString = hexString.Replace(" ", string.Empty);

            if (!string.IsNullOrEmpty(delimiter))
            {
                hexString = hexString.Replace(delimiter, string.Empty);
            }

            for (int i = 0; i < hexString.Length - 1; i += 2)
            {
                string hexStr = hexString.Substring(i, 2);

                char curChar = Convert.ToChar(Convert.ToUInt32(hexStr, 16));

                sb.Append(AsciiTable.AsciiCodesStripped[(int)curChar]);
            }

            return (sb.ToString());
        }

        private string ConvertAsciiToHexString(string asciiString, string delimiter)
        {
            var sb = new StringBuilder();

            foreach (char c in asciiString)
            {
                sb.AppendFormat("{0}{1:X2} ", delimiter, (int)c);
            }

            return (sb.ToString().Trim());
        }

        #endregion

        private void HexDelimiterTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_settingsUpdateEnabled)
            {
                UpdateSettings(_keys[0]);
            }
        }

        private void UpdateSettings(string key)
        {
            // update settings
            if (AppSettings.AssemblyExist())
            {
                if (AppSettings.KeyExist(key))
                {
                    if (HexDelimiterTextBoxText != AppSettings.ReadKey(_keys[0]))
                    {
                        AppSettings.UpdateKey(key, HexDelimiterTextBoxText);
                    }
                }
            }
        }
    }
}
