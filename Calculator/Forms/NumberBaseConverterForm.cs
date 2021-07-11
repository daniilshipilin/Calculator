namespace Calculator
{
    using System;
    using System.Windows.Forms;
    using Calculator.Helpers;

    public partial class NumberBaseConverterForm : Form
    {
        public string BinaryTextBoxText
        {
            get => this.binaryTextBox.Text;

            set => this.binaryTextBox.Text = value;
        }

        public string OctalTextBoxText
        {
            get => this.octalTextBox.Text;

            set => this.octalTextBox.Text = value;
        }

        public string DecimalTextBoxText
        {
            get => this.decimalTextBox.Text;

            set => this.decimalTextBox.Text = value;
        }

        public string HexadecimalTextBoxText
        {
            get => this.hexadecimalTextBox.Text;

            set => this.hexadecimalTextBox.Text = value;
        }

        // locker object
        private static readonly object _lockerObj = new();

        public NumberBaseConverterForm()
        {
            this.InitializeComponent();
        }

        private void NumberBaseConverterForm_Load(object sender, EventArgs e)
        {
            // textbox tooltips
            this.numberBaseConverterFormToolTip.SetToolTip(this.binaryTextBox, "Binary representation of decimal number");
            this.numberBaseConverterFormToolTip.SetToolTip(this.octalTextBox, "Octal representation of decimal number");
            this.numberBaseConverterFormToolTip.SetToolTip(this.decimalTextBox, "Decimal number stored as long (64bit signed integer)");
            this.numberBaseConverterFormToolTip.SetToolTip(this.hexadecimalTextBox, "Hexadecimal representation of decimal number");

            // button tooltips
            this.numberBaseConverterFormToolTip.SetToolTip(this.invertValueButton, "Invert current value");

            this.TopMost = AppSettings.TopMost;
        }

        private void ClearButton_Click(object sender, EventArgs e) => this.ClearTextBoxFields();

        private void ClearTextBoxFields()
        {
            this.BinaryTextBoxText = string.Empty;
            this.OctalTextBoxText = string.Empty;
            this.DecimalTextBoxText = string.Empty;
            this.HexadecimalTextBoxText = string.Empty;
        }

        private void BinaryTextBox_TextChanged(object sender, EventArgs e)
        {
            lock (_lockerObj)
            {
                if (this.BinaryTextBoxText.Length == 0)
                {
                    return;
                }

                try
                {
                    long longVal = Convert.ToInt64(this.BinaryTextBoxText, 2);

                    // Convert into the octal form
                    this.OctalTextBoxText = ConvertLongToOctalString(longVal);

                    // Convert into the decimal form
                    this.DecimalTextBoxText = ConvertLongToDecimalString(longVal);

                    // Convert into the hexadecimal form
                    this.HexadecimalTextBoxText = ConvertLongToHexadecimalString(longVal);
                }
                catch (Exception)
                {
                    // remove 'messy' char
                    this.BinaryTextBoxText = this.BinaryTextBoxText[0..^1];

                    // place caret at the end
                    this.binaryTextBox.Select(this.binaryTextBox.Text.Length, 0);
                }
            }
        }

        private void OctalTextBox_TextChanged(object sender, EventArgs e)
        {
            lock (_lockerObj)
            {
                if (this.OctalTextBoxText.Length == 0)
                {
                    return;
                }

                try
                {
                    long longVal = Convert.ToInt64(this.OctalTextBoxText, 8);

                    // Convert into the binary form
                    this.BinaryTextBoxText = ConvertLongToBinaryString(longVal);

                    // Convert into the decimal form
                    this.DecimalTextBoxText = ConvertLongToDecimalString(longVal);

                    // Convert into the hexadecimal form
                    this.HexadecimalTextBoxText = ConvertLongToHexadecimalString(longVal);
                }
                catch (Exception)
                {
                    // remove 'messy' char
                    this.OctalTextBoxText = this.OctalTextBoxText[0..^1];

                    // place caret at the end
                    this.octalTextBox.Select(this.octalTextBox.Text.Length, 0);
                }
            }
        }

        private void DecimalTextBox_TextChanged(object sender, EventArgs e)
        {
            lock (_lockerObj)
            {
                if (this.DecimalTextBoxText.Length == 0)
                {
                    return;
                }

                try
                {
                    long longVal = Convert.ToInt64(this.DecimalTextBoxText, 10);

                    // Convert into the binary form
                    this.BinaryTextBoxText = ConvertLongToBinaryString(longVal);

                    // Convert into the octal form
                    this.OctalTextBoxText = ConvertLongToOctalString(longVal);

                    // Convert into the hexadecimal form
                    this.HexadecimalTextBoxText = ConvertLongToHexadecimalString(longVal);
                }
                catch (Exception)
                {
                    // remove 'messy' char
                    this.DecimalTextBoxText = this.DecimalTextBoxText[0..^1];

                    // place caret at the end
                    this.decimalTextBox.Select(this.decimalTextBox.Text.Length, 0);
                }
            }
        }

        private void HexadecimalTextBox_TextChanged(object sender, EventArgs e)
        {
            lock (_lockerObj)
            {
                if (this.HexadecimalTextBoxText.Length == 0)
                {
                    return;
                }

                try
                {
                    long longVal = Convert.ToInt64(this.HexadecimalTextBoxText, 16);

                    // Convert into the binary form
                    this.BinaryTextBoxText = ConvertLongToBinaryString(longVal);

                    // Convert into the octal form
                    this.OctalTextBoxText = ConvertLongToOctalString(longVal);

                    // Convert into the decimal form
                    this.DecimalTextBoxText = ConvertLongToDecimalString(longVal);
                }
                catch (Exception)
                {
                    // remove 'messy' char
                    this.HexadecimalTextBoxText = this.HexadecimalTextBoxText[0..^1];

                    // place caret at the end
                    this.hexadecimalTextBox.Select(this.hexadecimalTextBox.Text.Length, 0);
                }
            }
        }

        private static string ConvertLongToBinaryString(long longVal) => Convert.ToString(longVal, 2);

        private static string ConvertLongToOctalString(long longVal) => Convert.ToString(longVal, 8);

        private static string ConvertLongToDecimalString(long longVal) => Convert.ToString(longVal, 10);

        private static string ConvertLongToHexadecimalString(long longVal) => Convert.ToString(longVal, 16).ToUpper();

        private void InvertValueButton_Click(object sender, EventArgs e)
        {
            if (this.DecimalTextBoxText.Length == 0)
            {
                this.ClearTextBoxFields();

                return;
            }

            try
            {
                long longVal = Convert.ToInt64(this.DecimalTextBoxText, 10);

                // check if decimal value is not already inverted
                if (longVal > 0)
                {
                    // append '-' sign to decimal value - inverting initial value
                    this.DecimalTextBoxText = this.DecimalTextBoxText.Insert(0, "-");
                }
                else
                {
                    this.DecimalTextBoxText = this.DecimalTextBoxText.Replace("-", string.Empty);
                }

                longVal = Convert.ToInt64(this.DecimalTextBoxText, 10);

                // Convert into the decimal form
                this.DecimalTextBoxText = ConvertLongToDecimalString(longVal);
            }
            catch (Exception)
            {
                this.decimalTextBox.Focus();
                this.decimalTextBox.SelectionStart = this.decimalTextBox.Text.Length;
            }
        }

        private void NumberBaseConverterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
