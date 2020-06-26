using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class NumberBaseConverterForm : Form
    {
        #region Public properties

        // binaryTextBox text
        public string BinaryTextBoxText
        {
            get { return (binaryTextBox.Text); }
            set { binaryTextBox.Text = value; }
        }

        // octalTextBox text
        public string OctalTextBoxText
        {
            get { return (octalTextBox.Text); }
            set { octalTextBox.Text = value; }
        }

        // decimalTextBox text
        public string DecimalTextBoxText
        {
            get { return (decimalTextBox.Text); }
            set { decimalTextBox.Text = value; }
        }

        // hexadecimalTextBox text
        public string HexadecimalTextBoxText
        {
            get { return (hexadecimalTextBox.Text); }
            set { hexadecimalTextBox.Text = value; }
        }

        #endregion

        #region Private fields

        // locker object
        static readonly object _lockerObj = new object();

        #endregion

        public NumberBaseConverterForm()
        {
            InitializeComponent();
        }

        private void NumberBaseConverterForm_Load(object sender, EventArgs e)
        {
            // textbox tooltips
            numberBaseConverterFormToolTip.SetToolTip(binaryTextBox, "Binary representation of decimal number");
            numberBaseConverterFormToolTip.SetToolTip(octalTextBox, "Octal representation of decimal number");
            numberBaseConverterFormToolTip.SetToolTip(decimalTextBox, "Decimal number stored as long (64bit signed integer)");
            numberBaseConverterFormToolTip.SetToolTip(hexadecimalTextBox, "Hexadecimal representation of decimal number");

            // button tooltips
            numberBaseConverterFormToolTip.SetToolTip(invertValueButton, "Invert current value");

            TopMost = Program.GlobalTopMost;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxFields();
        }

        private void ClearTextBoxFields()
        {
            BinaryTextBoxText = string.Empty;
            OctalTextBoxText = string.Empty;
            DecimalTextBoxText = string.Empty;
            HexadecimalTextBoxText = string.Empty;
        }

        private void BinaryTextBox_TextChanged(object sender, EventArgs e)
        {
            lock (_lockerObj)
            {
                if (BinaryTextBoxText.Length == 0)
                {
                    return;
                }

                try
                {
                    long longVal = Convert.ToInt64(BinaryTextBoxText, 2);

                    // Convert into the octal form
                    OctalTextBoxText = ConvertLongToOctalString(longVal);

                    // Convert into the decimal form
                    DecimalTextBoxText = ConvertLongToDecimalString(longVal);

                    // Convert into the hexadecimal form
                    HexadecimalTextBoxText = ConvertLongToHexadecimalString(longVal);
                }
                catch (Exception)
                {
                    // remove 'messy' char
                    BinaryTextBoxText = BinaryTextBoxText.Substring(0, BinaryTextBoxText.Length - 1);

                    // place caret at the end
                    binaryTextBox.Select(binaryTextBox.Text.Length, 0);
                }
            }
        }

        private void OctalTextBox_TextChanged(object sender, EventArgs e)
        {
            lock (_lockerObj)
            {
                if (OctalTextBoxText.Length == 0)
                {
                    return;
                }

                try
                {
                    long longVal = Convert.ToInt64(OctalTextBoxText, 8);

                    // Convert into the binary form
                    BinaryTextBoxText = ConvertLongToBinaryString(longVal);

                    // Convert into the decimal form
                    DecimalTextBoxText = ConvertLongToDecimalString(longVal);

                    // Convert into the hexadecimal form
                    HexadecimalTextBoxText = ConvertLongToHexadecimalString(longVal);
                }
                catch (Exception)
                {
                    // remove 'messy' char
                    OctalTextBoxText = OctalTextBoxText.Substring(0, OctalTextBoxText.Length - 1);

                    // place caret at the end
                    octalTextBox.Select(octalTextBox.Text.Length, 0);
                }
            }
        }

        private void DecimalTextBox_TextChanged(object sender, EventArgs e)
        {
            lock (_lockerObj)
            {
                if (DecimalTextBoxText.Length == 0)
                {
                    return;
                }

                try
                {
                    long longVal = Convert.ToInt64(DecimalTextBoxText, 10);

                    // Convert into the binary form
                    BinaryTextBoxText = ConvertLongToBinaryString(longVal);

                    // Convert into the octal form
                    OctalTextBoxText = ConvertLongToOctalString(longVal);

                    // Convert into the hexadecimal form
                    HexadecimalTextBoxText = ConvertLongToHexadecimalString(longVal);
                }
                catch (Exception)
                {
                    // remove 'messy' char
                    DecimalTextBoxText = DecimalTextBoxText.Substring(0, DecimalTextBoxText.Length - 1);

                    // place caret at the end
                    decimalTextBox.Select(decimalTextBox.Text.Length, 0);
                }
            }
        }

        private void HexadecimalTextBox_TextChanged(object sender, EventArgs e)
        {
            lock (_lockerObj)
            {
                if (HexadecimalTextBoxText.Length == 0)
                {
                    return;
                }

                try
                {
                    long longVal = Convert.ToInt64(HexadecimalTextBoxText, 16);

                    // Convert into the binary form
                    BinaryTextBoxText = ConvertLongToBinaryString(longVal);

                    // Convert into the octal form
                    OctalTextBoxText = ConvertLongToOctalString(longVal);

                    // Convert into the decimal form
                    DecimalTextBoxText = ConvertLongToDecimalString(longVal);
                }
                catch (Exception)
                {
                    // remove 'messy' char
                    HexadecimalTextBoxText = HexadecimalTextBoxText.Substring(0, HexadecimalTextBoxText.Length - 1);

                    // place caret at the end
                    hexadecimalTextBox.Select(hexadecimalTextBox.Text.Length, 0);
                }
            }
        }

        private string ConvertLongToBinaryString(long longVal)
        {
            // Convert into a binary
            return (Convert.ToString(longVal, 2));
        }

        private string ConvertLongToOctalString(long longVal)
        {
            // Convert into a octal
            return (Convert.ToString(longVal, 8));
        }

        private string ConvertLongToDecimalString(long longVal)
        {
            // Convert into a decimal
            return (Convert.ToString(longVal, 10));
        }

        private string ConvertLongToHexadecimalString(long longVal)
        {
            // Convert into a hexadecimal
            return (Convert.ToString(longVal, 16).ToUpper());
        }

        private void InvertValueButton_Click(object sender, EventArgs e)
        {
            if (DecimalTextBoxText.Length == 0)
            {
                ClearTextBoxFields();

                return;
            }

            try
            {
                long longVal = Convert.ToInt64(DecimalTextBoxText, 10);

                // check if decimal value is not already inverted
                if (longVal > 0)
                {
                    // append '-' sign to decimal value - inverting initial value
                    DecimalTextBoxText = DecimalTextBoxText.Insert(0, "-");
                }
                else
                {
                    DecimalTextBoxText = DecimalTextBoxText.Replace("-", string.Empty);
                }

                longVal = Convert.ToInt64(DecimalTextBoxText, 10);

                // Convert into the decimal form
                DecimalTextBoxText = ConvertLongToDecimalString(longVal);
            }
            catch (Exception)
            {
                decimalTextBox.Focus();
                decimalTextBox.SelectionStart = decimalTextBox.Text.Length;
            }
        }

        private void NumberBaseConverterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
