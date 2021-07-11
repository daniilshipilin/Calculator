namespace Calculator
{
    using System;
    using System.Windows.Forms;
    using Calculator.Helpers;

    public partial class AsciiTableForm : Form
    {
        public string AsciiTextBoxText
        {
            get => this.asciiTextBox.Text;

            set => this.asciiTextBox.Text = value;
        }

        public string ExtendedAsciiTextBoxText
        {
            get => this.extendedAsciiTextBox.Text;

            set => this.extendedAsciiTextBox.Text = value;
        }

        public string AsciiHeaderTextBoxText
        {
            get => this.asciiHeaderTextBox.Text;

            set => this.asciiHeaderTextBox.Text = value;
        }

        public string ExtendedAsciiHeaderTextBoxText
        {
            get => this.extendedAsciiHeaderTextBox.Text;

            set => this.extendedAsciiHeaderTextBox.Text = value;
        }

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

            this.AsciiHeaderTextBoxText = "DEC\tHEX\tCHAR";
            this.ExtendedAsciiHeaderTextBoxText = "DEC\tHEX\tCHAR";
            this.AsciiTextBoxText = ascii;
            this.ExtendedAsciiTextBoxText = extended;

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
}
