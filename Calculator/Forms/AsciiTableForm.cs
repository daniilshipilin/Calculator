namespace Calculator.Forms;

using System;
using System.Windows.Forms;
using Calculator.Helpers;

public partial class AsciiTableForm : Form
{
    public AsciiTableForm()
    {
        this.InitializeComponent();
    }

    private void AsciiTableForm_Load(object sender, EventArgs e)
    {
        string ascii = string.Empty;
        string extended = string.Empty;

        for (int i = 0; i < 128; i++)
        {
            ascii += $"{i}\t{Convert.ToString(i, 16).ToUpper()}\t{AsciiTable.AsciiCodes[i]}";

            // remove CR & LF from the last line
            if (i != 127)
            {
                ascii += Environment.NewLine;
            }
        }

        for (int i = 128; i < 256; i++)
        {
            extended += $"{i}\t{Convert.ToString(i, 16).ToUpper()}\t{AsciiTable.AsciiCodes[i]}";

            if (i != 255)
            {
                extended += Environment.NewLine;
            }
        }

        this.asciiHeaderTextBox.Text = "DEC\tHEX\tCHAR";
        this.extendedAsciiHeaderTextBox.Text = "DEC\tHEX\tCHAR";
        this.asciiTextBox.Text = ascii;
        this.extendedAsciiTextBox.Text = extended;

        this.TopMost = AppSettings.TopMost;
    }

    private void AsciiTableForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }
}
