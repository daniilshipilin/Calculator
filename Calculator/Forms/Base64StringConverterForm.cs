namespace Calculator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using Calculator.Helpers;

    public partial class Base64StringConverterForm : Form
    {
        private string Utf8StringTextBoxText
        {
            get => this.utf8StringTextBox.Text;

            set => this.utf8StringTextBox.Text = value;
        }

        private string Base64EncodedStringTextBoxText
        {
            get => this.base64EncodedStringTextBox.Text;

            set => this.base64EncodedStringTextBox.Text = value;
        }

        private string ModeSelectComboBoxText
        {
            get => this.modeSelectComboBox.Text;

            set => this.modeSelectComboBox.Text = value;
        }

        public Base64StringConverterForm()
        {
            this.InitializeComponent();
        }

        private void Base64StringConverterForm_Load(object sender, EventArgs e)
        {
            this.ModeSelectComboBoxText = AppSettings.Base64Mode;
            this.TopMost = AppSettings.TopMost;
        }

        private void Base64StringConverterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ModeSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            // if 'Text' selected
            if (this.ModeSelectComboBoxText == "Text")
            {
                this.encodeButton.Enabled = true;
                this.decodeButton.Enabled = true;
                this.openSingleFileButton.Enabled = false;
                this.saveToFileButton.Enabled = false;
            }
            // if 'File' selected
            else if (this.ModeSelectComboBoxText == "File")
            {
                this.encodeButton.Enabled = false;
                this.decodeButton.Enabled = false;
                this.openSingleFileButton.Enabled = true;
                this.saveToFileButton.Enabled = true;
            }

            AppSettings.Base64Mode = this.ModeSelectComboBoxText;
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            byte[]? bytes = this.OpenFile();

            // check if OpenFile() returned not null
            if (bytes is null)
            {
                return;
            }

            try
            {
                this.Base64EncodedStringTextBoxText = GetEncodedBase64Bytes(bytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[]? OpenFile()
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using var br = new BinaryReader(File.Open(this.openFileDialog.FileName, FileMode.Open, FileAccess.Read));

                return br.BaseStream.Length is > int.MaxValue or 0
                    ? throw new IndexOutOfRangeException("File is empty or its size is bigger than 2GB")
                    : br.ReadBytes((int)br.BaseStream.Length);
            }

            return null;
        }

        /// <summary>
        /// This method converts passed in bytes to Base64 scheme represented as an ASCII byte sequence.
        /// </summary>
        private static string GetEncodedBase64Bytes(byte[] bytes) => Convert.ToBase64String(bytes, Base64FormattingOptions.InsertLineBreaks);

        /// <summary>
        /// This method converts passed in UTF-8 string to Base64 scheme represented as an ASCII byte sequence.
        /// </summary>
        private static string GetEncodedBase64String(string str) => Convert.ToBase64String(Encoding.UTF8.GetBytes(str), Base64FormattingOptions.InsertLineBreaks);

        /// <summary>
        /// This method decodes Base64 scheme represented ASCII byte sequence to UTF-8 string.
        /// </summary>
        private static string GetDecodedBase64String(string str) => Encoding.UTF8.GetString(Convert.FromBase64String(str));

        private void EncodeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Utf8StringTextBoxText))
            {
                MessageBox.Show($"UTF-8 String textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                this.Base64EncodedStringTextBoxText = GetEncodedBase64String(this.Utf8StringTextBoxText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Base64EncodedStringTextBoxText))
            {
                MessageBox.Show($"Base64 Encoded String textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                this.Utf8StringTextBoxText = GetDecodedBase64String(this.Base64EncodedStringTextBoxText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e) => this.ClearTextBoxes();

        private void ClearTextBoxes()
        {
            this.Utf8StringTextBoxText = string.Empty;
            this.Base64EncodedStringTextBoxText = string.Empty;
        }

        private void Utf8StringTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                this.utf8StringTextBox.SelectAll();
            }
        }

        private void Base64EncodedStringTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                this.base64EncodedStringTextBox.SelectAll();
            }
        }

        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Base64EncodedStringTextBoxText))
            {
                MessageBox.Show($"Base64 Encoded String textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                this.SaveFile(Convert.FromBase64String(this.Base64EncodedStringTextBoxText));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void SaveFile(byte[] bytes)
        {
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = this.saveFileDialog.FileName;

                File.WriteAllBytes(fileName, bytes);

                MessageBox.Show($"File saved as {fileName}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
