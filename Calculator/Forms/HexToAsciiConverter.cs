namespace Calculator.Forms;

using System;
using System.Text;
using System.Windows.Forms;
using Calculator.Configuration;
using Calculator.Helpers;

public partial class HexToAsciiConverterForm : Form
{
    public HexToAsciiConverterForm()
    {
        this.InitializeComponent();
    }

    private void HexToAsciiConverterForm_Load(object sender, EventArgs e)
    {
        this.hexDelimiterTextBox.Text = string.Empty;

        this.hexDelimiterTextBox.Text = AppSettings.HexDelimiter;
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
        if (string.IsNullOrEmpty(this.hexTextBox.Text))
        {
            MessageBox.Show($"HEX textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return;
        }

        try
        {
            this.asciiTextBox.Text = ConvertHexToAsciiString(this.hexTextBox.Text, this.hexDelimiterTextBox.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ConvertToHexButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.asciiTextBox.Text))
        {
            MessageBox.Show($"ASCII textbox is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return;
        }

        try
        {
            this.hexTextBox.Text = ConvertAsciiToHexString(this.asciiTextBox.Text, this.hexDelimiterTextBox.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ClearButton_Click(object sender, EventArgs e) => this.ClearTextBoxes();

    private void ClearTextBoxes()
    {
        this.hexTextBox.Text = string.Empty;
        this.asciiTextBox.Text = string.Empty;
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

    private void HexDelimiterTextBox_TextChanged(object sender, EventArgs e) => AppSettings.HexDelimiter = this.hexDelimiterTextBox.Text;
}
