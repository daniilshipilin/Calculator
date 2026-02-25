namespace Calculator.Forms;

using System;
using System.Windows.Forms;

public partial class AboutForm : Form
{
    public AboutForm()
    {
        this.InitializeComponent();
    }

    private void AboutForm_Load(object sender, EventArgs e)
    {
        this.aboutTextBox.Text = ApplicationInfo.AppInfoFormatted;
    }

    private void AboutForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }
}
