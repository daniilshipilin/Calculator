using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class KeyboardShortcutsForm : Form
    {
        public KeyboardShortcutsForm()
        {
            InitializeComponent();
        }

        private void KeyboardShortcutsForm_Load(object sender, EventArgs e)
        {
            keyboardShortcutsTextBox.Text = Program.GetShortcuts();

            TopMost = Program.GlobalTopMost;
        }

        private void KeyboardShortcutsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
