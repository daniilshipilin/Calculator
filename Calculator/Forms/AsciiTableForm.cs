using System;
using System.Windows.Forms;
using Calculator.Helpers;

namespace Calculator
{
    public partial class AsciiTableForm : Form
    {
        #region Public properties

        public string AsciiTextBoxText
        {
            get { return (asciiTextBox.Text); }
            set { asciiTextBox.Text = value; }
        }

        public string ExtendedAsciiTextBoxText
        {
            get { return (extendedAsciiTextBox.Text); }
            set { extendedAsciiTextBox.Text = value; }
        }

        public string AsciiHeaderTextBoxText
        {
            get { return (asciiHeaderTextBox.Text); }
            set { asciiHeaderTextBox.Text = value; }
        }

        public string ExtendedAsciiHeaderTextBoxText
        {
            get { return (extendedAsciiHeaderTextBox.Text); }
            set { extendedAsciiHeaderTextBox.Text = value; }
        }

        #endregion

        public AsciiTableForm()
        {
            InitializeComponent();
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

            AsciiHeaderTextBoxText = "DEC\tHEX\tCHAR";
            ExtendedAsciiHeaderTextBoxText = "DEC\tHEX\tCHAR";
            AsciiTextBoxText = ascii;
            ExtendedAsciiTextBoxText = extended;

            TopMost = Program.GlobalTopMost;
        }

        private void AsciiTableForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
