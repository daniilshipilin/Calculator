namespace Calculator
{
    partial class KeyboardShortcutsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.keyboardShortcutsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // keyboardShortcutsTextBox
            //
            this.keyboardShortcutsTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.keyboardShortcutsTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.keyboardShortcutsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.keyboardShortcutsTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.keyboardShortcutsTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyboardShortcutsTextBox.ForeColor = System.Drawing.Color.Black;
            this.keyboardShortcutsTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.keyboardShortcutsTextBox.Location = new System.Drawing.Point(16, 14);
            this.keyboardShortcutsTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.keyboardShortcutsTextBox.Multiline = true;
            this.keyboardShortcutsTextBox.Name = "keyboardShortcutsTextBox";
            this.keyboardShortcutsTextBox.ReadOnly = true;
            this.keyboardShortcutsTextBox.ShortcutsEnabled = false;
            this.keyboardShortcutsTextBox.Size = new System.Drawing.Size(454, 233);
            this.keyboardShortcutsTextBox.TabIndex = 7;
            this.keyboardShortcutsTextBox.TabStop = false;
            //
            // KeyboardShortcutsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.keyboardShortcutsTextBox);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyboardShortcutsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shortcuts";
            this.Load += new System.EventHandler(this.KeyboardShortcutsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboardShortcutsForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox keyboardShortcutsTextBox;
    }
}