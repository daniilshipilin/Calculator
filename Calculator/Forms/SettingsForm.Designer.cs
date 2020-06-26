namespace Calculator
{
    partial class SettingsForm
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
            this.refreshSettingsButton = new System.Windows.Forms.Button();
            this.settingsTextBox = new System.Windows.Forms.TextBox();
            this.deleteConfigFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // refreshSettingsButton
            //
            this.refreshSettingsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.refreshSettingsButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refreshSettingsButton.ForeColor = System.Drawing.Color.Black;
            this.refreshSettingsButton.Location = new System.Drawing.Point(14, 174);
            this.refreshSettingsButton.Margin = new System.Windows.Forms.Padding(5);
            this.refreshSettingsButton.Name = "refreshSettingsButton";
            this.refreshSettingsButton.Size = new System.Drawing.Size(150, 23);
            this.refreshSettingsButton.TabIndex = 0;
            this.refreshSettingsButton.Text = "Refresh Settings";
            this.refreshSettingsButton.UseVisualStyleBackColor = false;
            this.refreshSettingsButton.Click += new System.EventHandler(this.RefreshSettingsButton_Click);
            //
            // settingsTextBox
            //
            this.settingsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.settingsTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsTextBox.ForeColor = System.Drawing.Color.Black;
            this.settingsTextBox.Location = new System.Drawing.Point(14, 14);
            this.settingsTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.settingsTextBox.MaxLength = 2147483647;
            this.settingsTextBox.Multiline = true;
            this.settingsTextBox.Name = "settingsTextBox";
            this.settingsTextBox.ReadOnly = true;
            this.settingsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.settingsTextBox.Size = new System.Drawing.Size(456, 150);
            this.settingsTextBox.TabIndex = 0;
            this.settingsTextBox.TabStop = false;
            this.settingsTextBox.WordWrap = false;
            this.settingsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsTextBox_KeyDown);
            //
            // deleteConfigFileButton
            //
            this.deleteConfigFileButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteConfigFileButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteConfigFileButton.ForeColor = System.Drawing.Color.DarkRed;
            this.deleteConfigFileButton.Location = new System.Drawing.Point(320, 174);
            this.deleteConfigFileButton.Margin = new System.Windows.Forms.Padding(5);
            this.deleteConfigFileButton.Name = "deleteConfigFileButton";
            this.deleteConfigFileButton.Size = new System.Drawing.Size(150, 23);
            this.deleteConfigFileButton.TabIndex = 1;
            this.deleteConfigFileButton.Text = "Delete Config File";
            this.deleteConfigFileButton.UseVisualStyleBackColor = false;
            this.deleteConfigFileButton.Click += new System.EventHandler(this.DeleteConfigFileButton_Click);
            //
            // SettingsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.deleteConfigFileButton);
            this.Controls.Add(this.settingsTextBox);
            this.Controls.Add(this.refreshSettingsButton);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshSettingsButton;
        private System.Windows.Forms.TextBox settingsTextBox;
        private System.Windows.Forms.Button deleteConfigFileButton;
    }
}