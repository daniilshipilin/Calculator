namespace Calculator.Forms;

using System;
using System.Windows.Forms;
using Calculator.Helpers;

public partial class KeyboardShortcutsForm : Form
{
    public KeyboardShortcutsForm()
    {
        this.InitializeComponent();
    }

    private void KeyboardShortcutsForm_Load(object sender, EventArgs e)
    {
        this.keyboardShortcutsTextBox.Text = ApplicationInfo.ShortcutsFormatted;

        this.TopMost = AppSettings.TopMost;
    }

    private void KeyboardShortcutsForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }
}
