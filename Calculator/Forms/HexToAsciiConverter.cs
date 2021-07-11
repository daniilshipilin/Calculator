namespace Calculator
{
    using System;
    using System.Text;
    using System.Windows.Forms;
    using Calculator.Helpers;

    public partial class HexToAsciiConverterForm : Form
    {
        public string HexTextBoxText
        {
            get => this.hexTextBox.Text;

            set => this.hexTextBox.Text = value;
        }

        public string AsciiTextBoxText
        {
            get => this.asciiTextBox.Text;

            set => this.asciiTextBox.Text = value;
        }

        public string HexDelimiterTextBoxText
        {
            get => this.hexDelimiterTextBox.Text;

            set => this.hexDelimiterTextBox.Text = value;
        }

        public HexToAsciiConverterForm()
        {
            this.InitializeComponent();
        }

        private void HexToAsciiConverterForm_Load(object sender, EventArgs e)
        {
            this.HexDelimiterTextBoxText = string.Empty;

            this.HexDelimiterTextBoxText = AppSettings.HexDelimiter;

            this.TopMost = AppSettings.TopMost;
        }

        private void HexToAsciiConverterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ConvertToAsciiButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.HexTextBoxText))
            {
                MessageBox.Show($"HEX textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                this.AsciiTextBoxText = ConvertHexToAsciiString(this.HexTextBoxText, this.HexDelimiterTextBoxText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConvertToHexButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.AsciiTextBoxText))
            {
                MessageBox.Show($"ASCII textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                this.HexTextBoxText = ConvertAsciiToHexString(this.AsciiTextBoxText, this.HexDelimiterTextBoxText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e) => this.ClearTextBoxes();

        private void ClearTextBoxes()
        {
            this.HexTextBoxText = string.Empty;
            this.AsciiTextBoxText = string.Empty;
        }

        private void HexTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                this.hexTextBox.SelectAll();
            }
        }

        private void AsciiTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                this.asciiTextBox.SelectAll();
            }
        }

        private static string ConvertHexToAsciiString(string hexString, string delimiter)
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

                sb.Append(AsciiTable.AsciiCodesStripped[curChar]);
            }

            return sb.ToString();
        }

        private static string ConvertAsciiToHexString(string asciiString, string delimiter)
        {
            var sb = new StringBuilder();

            foreach (char c in asciiString)
            {
                sb.AppendFormat("{0}{1:X2} ", delimiter, (int)c);
            }

            return sb.ToString().Trim();
        }

        private void HexDelimiterTextBox_TextChanged(object sender, EventArgs e) => AppSettings.HexDelimiter = this.HexDelimiterTextBoxText;
    }
}
