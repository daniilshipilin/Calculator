namespace Calculator.Forms;

using System;
using System.Windows.Forms;

public partial class NumberBaseConverterForm : Form
{
    // locker object
    private static readonly object lockerObj = new();

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
    }

    private void ClearButton_Click(object sender, EventArgs e) => this.ClearTextBoxFields();

    private void ClearTextBoxFields()
    {
        this.binaryTextBox.Text = string.Empty;
        this.octalTextBox.Text = string.Empty;
        this.decimalTextBox.Text = string.Empty;
        this.hexadecimalTextBox.Text = string.Empty;
    }

    private void BinaryTextBox_TextChanged(object sender, EventArgs e)
    {
        lock (lockerObj)
        {
            if (this.binaryTextBox.Text.Length == 0)
            {
                return;
            }

            try
            {
                long longVal = Convert.ToInt64(this.binaryTextBox.Text, 2);

                // Convert into the octal form
                this.octalTextBox.Text = ConvertLongToOctalString(longVal);

                // Convert into the decimal form
                this.decimalTextBox.Text = ConvertLongToDecimalString(longVal);

                // Convert into the hexadecimal form
                this.hexadecimalTextBox.Text = ConvertLongToHexadecimalString(longVal);
            }
            catch (Exception)
            {
                // remove 'messy' char
                this.binaryTextBox.Text = this.binaryTextBox.Text[0..^1];

                // place caret at the end
                this.binaryTextBox.Select(this.binaryTextBox.Text.Length, 0);
            }
        }
    }

    private void OctalTextBox_TextChanged(object sender, EventArgs e)
    {
        lock (lockerObj)
        {
            if (this.octalTextBox.Text.Length == 0)
            {
                return;
            }

            try
            {
                long longVal = Convert.ToInt64(this.octalTextBox.Text, 8);

                // Convert into the binary form
                this.binaryTextBox.Text = ConvertLongToBinaryString(longVal);

                // Convert into the decimal form
                this.decimalTextBox.Text = ConvertLongToDecimalString(longVal);

                // Convert into the hexadecimal form
                this.hexadecimalTextBox.Text = ConvertLongToHexadecimalString(longVal);
            }
            catch (Exception)
            {
                // remove 'messy' char
                this.octalTextBox.Text = this.octalTextBox.Text[0..^1];

                // place caret at the end
                this.octalTextBox.Select(this.octalTextBox.Text.Length, 0);
            }
        }
    }

    private void DecimalTextBox_TextChanged(object sender, EventArgs e)
    {
        lock (lockerObj)
        {
            if (this.decimalTextBox.Text.Length == 0)
            {
                return;
            }

            try
            {
                long longVal = Convert.ToInt64(this.decimalTextBox.Text, 10);

                // Convert into the binary form
                this.binaryTextBox.Text = ConvertLongToBinaryString(longVal);

                // Convert into the octal form
                this.octalTextBox.Text = ConvertLongToOctalString(longVal);

                // Convert into the hexadecimal form
                this.hexadecimalTextBox.Text = ConvertLongToHexadecimalString(longVal);
            }
            catch (Exception)
            {
                // remove 'messy' char
                this.decimalTextBox.Text = this.decimalTextBox.Text[0..^1];

                // place caret at the end
                this.decimalTextBox.Select(this.decimalTextBox.Text.Length, 0);
            }
        }
    }

    private void HexadecimalTextBox_TextChanged(object sender, EventArgs e)
    {
        lock (lockerObj)
        {
            if (this.hexadecimalTextBox.Text.Length == 0)
            {
                return;
            }

            try
            {
                long longVal = Convert.ToInt64(this.hexadecimalTextBox.Text, 16);

                // Convert into the binary form
                this.binaryTextBox.Text = ConvertLongToBinaryString(longVal);

                // Convert into the octal form
                this.octalTextBox.Text = ConvertLongToOctalString(longVal);

                // Convert into the decimal form
                this.decimalTextBox.Text = ConvertLongToDecimalString(longVal);
            }
            catch (Exception)
            {
                // remove 'messy' char
                this.hexadecimalTextBox.Text = this.hexadecimalTextBox.Text[0..^1];

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
        if (this.decimalTextBox.Text.Length == 0)
        {
            this.ClearTextBoxFields();

            return;
        }

        try
        {
            long longVal = Convert.ToInt64(this.decimalTextBox.Text, 10);

            // check if decimal value is not already inverted
            if (longVal > 0)
            {
                // append '-' sign to decimal value - inverting initial value
                this.decimalTextBox.Text = this.decimalTextBox.Text.Insert(0, "-");
            }
            else
            {
                this.decimalTextBox.Text = this.decimalTextBox.Text.Replace("-", string.Empty);
            }

            longVal = Convert.ToInt64(this.decimalTextBox.Text, 10);

            // Convert into the decimal form
            this.decimalTextBox.Text = ConvertLongToDecimalString(longVal);
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
