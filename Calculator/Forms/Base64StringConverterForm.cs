using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Calculator.Helpers;

namespace Calculator
{
    public partial class Base64StringConverterForm : Form
    {
        #region Properties

        // utf8StringTextBox text
        string Utf8StringTextBoxText
        {
            get { return (utf8StringTextBox.Text); }
            set { utf8StringTextBox.Text = value; }
        }

        // base64EncodedStringTextBox text
        string Base64EncodedStringTextBoxText
        {
            get { return (base64EncodedStringTextBox.Text); }
            set { base64EncodedStringTextBox.Text = value; }
        }

        // modeSelectComboBox text
        string ModeSelectComboBoxText
        {
            get { return (modeSelectComboBox.Text); }
            set { modeSelectComboBox.Text = value; }
        }

        #endregion

        #region AppSettings

        static readonly List<string> _keys = new List<string>
        {
            "Base64Mode"
        };

        #endregion

        #region Private fields

        // flag to activate settings update
        bool _settingsUpdateEnabled = false;

        #endregion

        public Base64StringConverterForm()
        {
            InitializeComponent();
        }

        private void Base64StringConverterForm_Load(object sender, EventArgs e)
        {
            ModeSelectComboBoxText = "Text";

            // configuration check
            if (AppSettings.AssemblyExist())
            {
                if (AppSettings.KeyExist(_keys[0]))
                {
                    ModeSelectComboBoxText = AppSettings.ReadKey(_keys[0]);
                }
            }

            _settingsUpdateEnabled = true;

            TopMost = Program.GlobalTopMost;
        }

        private void Base64StringConverterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void ModeSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            // if 'Text' selected
            if (ModeSelectComboBoxText == "Text")
            {
                encodeButton.Enabled = true;
                decodeButton.Enabled = true;
                openSingleFileButton.Enabled = false;
                saveToFileButton.Enabled = false;
            }
            // if 'File' selected
            else if (ModeSelectComboBoxText == "File")
            {
                encodeButton.Enabled = false;
                decodeButton.Enabled = false;
                openSingleFileButton.Enabled = true;
                saveToFileButton.Enabled = true;
            }

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
                    if (ModeSelectComboBoxText != AppSettings.ReadKey(_keys[0]))
                    {
                        AppSettings.UpdateKey(key, ModeSelectComboBoxText);
                    }
                }
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            byte[] bytes = OpenFile();

            // check if OpenFile() returned not null
            if (bytes == null)
            {
                return;
            }

            try
            {
                Base64EncodedStringTextBoxText = GetEncodedBase64Bytes(bytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] OpenFile()
        {
            // buffer to store file contents
            byte[] _openedFileBytes = null;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using var br = new BinaryReader(File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read));

                if (br.BaseStream.Length > int.MaxValue || br.BaseStream.Length == 0)
                {
                    throw new IndexOutOfRangeException("File is empty or its size is bigger than 2GB");
                }

                _openedFileBytes = br.ReadBytes((int)br.BaseStream.Length);
            }

            return (_openedFileBytes);
        }

        /// <summary>
        /// This method converts passed in bytes to Base64 scheme represented as an ASCII byte sequence.
        /// </summary>
        private string GetEncodedBase64Bytes(byte[] bytes) => (Convert.ToBase64String(bytes, Base64FormattingOptions.InsertLineBreaks));

        /// <summary>
        /// This method converts passed in UTF-8 string to Base64 scheme represented as an ASCII byte sequence.
        /// </summary>
        private string GetEncodedBase64String(string str) => (Convert.ToBase64String(Encoding.UTF8.GetBytes(str), Base64FormattingOptions.InsertLineBreaks));

        /// <summary>
        /// This method decodes Base64 scheme represented ASCII byte sequence to UTF-8 string.
        /// </summary>
        private string GetDecodedBase64String(string str) => (Encoding.UTF8.GetString(Convert.FromBase64String(str)));

        private void EncodeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Utf8StringTextBoxText))
            {
                MessageBox.Show($"UTF-8 String textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                Base64EncodedStringTextBoxText = GetEncodedBase64String(Utf8StringTextBoxText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Base64EncodedStringTextBoxText))
            {
                MessageBox.Show($"Base64 Encoded String textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                Utf8StringTextBoxText = GetDecodedBase64String(Base64EncodedStringTextBoxText);
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
            Utf8StringTextBoxText = string.Empty;
            Base64EncodedStringTextBoxText = string.Empty;
        }

        private void Utf8StringTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                utf8StringTextBox.SelectAll();
            }
        }

        private void Base64EncodedStringTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                base64EncodedStringTextBox.SelectAll();
            }
        }

        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Base64EncodedStringTextBoxText))
            {
                MessageBox.Show($"Base64 Encoded String textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                SaveFile(Convert.FromBase64String(Base64EncodedStringTextBoxText));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void SaveFile(byte[] bytes)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;

                File.WriteAllBytes(fileName, bytes);

                MessageBox.Show($"File saved as {fileName}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
