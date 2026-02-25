namespace Calculator.Forms
{
    partial class Base64StringConverterForm
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
            this.utf8StringTextBox = new System.Windows.Forms.TextBox();
            this.base64EncodedStringTextBox = new System.Windows.Forms.TextBox();
            this.encodeButton = new System.Windows.Forms.Button();
            this.decodeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.utf8StringLabel = new System.Windows.Forms.Label();
            this.base64EncodedStringLabel = new System.Windows.Forms.Label();
            this.modeSelectLabel = new System.Windows.Forms.Label();
            this.modeSelectComboBox = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openSingleFileButton = new System.Windows.Forms.Button();
            this.saveToFileButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // utf8StringTextBox
            // 
            this.utf8StringTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.utf8StringTextBox.ForeColor = System.Drawing.Color.Black;
            this.utf8StringTextBox.Location = new System.Drawing.Point(16, 45);
            this.utf8StringTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.utf8StringTextBox.MaxLength = int.MaxValue;
            this.utf8StringTextBox.Multiline = true;
            this.utf8StringTextBox.Name = "utf8StringTextBox";
            this.utf8StringTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.utf8StringTextBox.Size = new System.Drawing.Size(531, 92);
            this.utf8StringTextBox.TabIndex = 0;
            this.utf8StringTextBox.WordWrap = false;
            this.utf8StringTextBox.KeyDown += this.Utf8StringTextBox_KeyDown;
            // 
            // base64EncodedStringTextBox
            // 
            this.base64EncodedStringTextBox.AcceptsReturn = true;
            this.base64EncodedStringTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.base64EncodedStringTextBox.ForeColor = System.Drawing.Color.Black;
            this.base64EncodedStringTextBox.Location = new System.Drawing.Point(16, 225);
            this.base64EncodedStringTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.base64EncodedStringTextBox.MaxLength = int.MaxValue;
            this.base64EncodedStringTextBox.Multiline = true;
            this.base64EncodedStringTextBox.Name = "base64EncodedStringTextBox";
            this.base64EncodedStringTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.base64EncodedStringTextBox.Size = new System.Drawing.Size(531, 92);
            this.base64EncodedStringTextBox.TabIndex = 2;
            this.base64EncodedStringTextBox.WordWrap = false;
            this.base64EncodedStringTextBox.KeyDown += this.Base64EncodedStringTextBox_KeyDown;
            // 
            // encodeButton
            // 
            this.encodeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.encodeButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.encodeButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.encodeButton.Location = new System.Drawing.Point(303, 187);
            this.encodeButton.Margin = new System.Windows.Forms.Padding(6);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(117, 27);
            this.encodeButton.TabIndex = 1;
            this.encodeButton.Text = "Encode ▼";
            this.encodeButton.UseVisualStyleBackColor = false;
            this.encodeButton.Click += this.EncodeButton_Click;
            // 
            // decodeButton
            // 
            this.decodeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.decodeButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.decodeButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.decodeButton.Location = new System.Drawing.Point(303, 149);
            this.decodeButton.Margin = new System.Windows.Forms.Padding(6);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(117, 27);
            this.decodeButton.TabIndex = 3;
            this.decodeButton.Text = "Decode ▲";
            this.decodeButton.UseVisualStyleBackColor = false;
            this.decodeButton.Click += this.DecodeButton_Click;
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clearButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.clearButton.ForeColor = System.Drawing.Color.DarkRed;
            this.clearButton.Location = new System.Drawing.Point(432, 149);
            this.clearButton.Margin = new System.Windows.Forms.Padding(6);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(117, 27);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear All";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += this.ClearButton_Click;
            // 
            // utf8StringLabel
            // 
            this.utf8StringLabel.AutoSize = true;
            this.utf8StringLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.utf8StringLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            this.utf8StringLabel.ForeColor = System.Drawing.Color.Black;
            this.utf8StringLabel.Location = new System.Drawing.Point(16, 16);
            this.utf8StringLabel.Margin = new System.Windows.Forms.Padding(6);
            this.utf8StringLabel.Name = "utf8StringLabel";
            this.utf8StringLabel.Size = new System.Drawing.Size(98, 15);
            this.utf8StringLabel.TabIndex = 2;
            this.utf8StringLabel.Text = "UTF-8 String:";
            // 
            // base64EncodedStringLabel
            // 
            this.base64EncodedStringLabel.AutoSize = true;
            this.base64EncodedStringLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.base64EncodedStringLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            this.base64EncodedStringLabel.ForeColor = System.Drawing.Color.Black;
            this.base64EncodedStringLabel.Location = new System.Drawing.Point(16, 196);
            this.base64EncodedStringLabel.Margin = new System.Windows.Forms.Padding(6);
            this.base64EncodedStringLabel.Name = "base64EncodedStringLabel";
            this.base64EncodedStringLabel.Size = new System.Drawing.Size(161, 15);
            this.base64EncodedStringLabel.TabIndex = 3;
            this.base64EncodedStringLabel.Text = "Base64 Encoded String:";
            // 
            // modeSelectLabel
            // 
            this.modeSelectLabel.AutoSize = true;
            this.modeSelectLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.modeSelectLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            this.modeSelectLabel.ForeColor = System.Drawing.Color.Black;
            this.modeSelectLabel.Location = new System.Drawing.Point(16, 153);
            this.modeSelectLabel.Margin = new System.Windows.Forms.Padding(6);
            this.modeSelectLabel.Name = "modeSelectLabel";
            this.modeSelectLabel.Size = new System.Drawing.Size(42, 15);
            this.modeSelectLabel.TabIndex = 0;
            this.modeSelectLabel.Text = "Mode:";
            // 
            // modeSelectComboBox
            // 
            this.modeSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeSelectComboBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            this.modeSelectComboBox.ForeColor = System.Drawing.Color.Black;
            this.modeSelectComboBox.FormattingEnabled = true;
            this.modeSelectComboBox.Items.AddRange(new object[] { "Text", "File" });
            this.modeSelectComboBox.Location = new System.Drawing.Point(77, 150);
            this.modeSelectComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.modeSelectComboBox.Name = "modeSelectComboBox";
            this.modeSelectComboBox.Size = new System.Drawing.Size(69, 23);
            this.modeSelectComboBox.TabIndex = 0;
            this.modeSelectComboBox.TabStop = false;
            this.modeSelectComboBox.SelectedValueChanged += this.ModeSelectComboBox_SelectedValueChanged;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All files|*.*";
            // 
            // openSingleFileButton
            // 
            this.openSingleFileButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.openSingleFileButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.openSingleFileButton.ForeColor = System.Drawing.Color.Black;
            this.openSingleFileButton.Location = new System.Drawing.Point(159, 149);
            this.openSingleFileButton.Margin = new System.Windows.Forms.Padding(6);
            this.openSingleFileButton.Name = "openSingleFileButton";
            this.openSingleFileButton.Size = new System.Drawing.Size(117, 27);
            this.openSingleFileButton.TabIndex = 5;
            this.openSingleFileButton.Text = "Browse...";
            this.openSingleFileButton.UseVisualStyleBackColor = false;
            this.openSingleFileButton.Click += this.OpenFileButton_Click;
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.saveToFileButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.saveToFileButton.ForeColor = System.Drawing.Color.Black;
            this.saveToFileButton.Location = new System.Drawing.Point(432, 187);
            this.saveToFileButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(117, 27);
            this.saveToFileButton.TabIndex = 6;
            this.saveToFileButton.Text = "Save To File";
            this.saveToFileButton.UseVisualStyleBackColor = false;
            this.saveToFileButton.Click += this.SaveToFileButton_Click;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "All files|*.*";
            // 
            // Base64StringConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(565, 336);
            this.Controls.Add(this.saveToFileButton);
            this.Controls.Add(this.openSingleFileButton);
            this.Controls.Add(this.modeSelectComboBox);
            this.Controls.Add(this.modeSelectLabel);
            this.Controls.Add(this.base64EncodedStringLabel);
            this.Controls.Add(this.utf8StringLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.encodeButton);
            this.Controls.Add(this.base64EncodedStringTextBox);
            this.Controls.Add(this.utf8StringTextBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Base64StringConverterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base64 String Converter";
            this.Load += this.Base64StringConverterForm_Load;
            this.KeyDown += this.Base64StringConverterForm_KeyDown;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox utf8StringTextBox;
        private System.Windows.Forms.TextBox base64EncodedStringTextBox;
        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label utf8StringLabel;
        private System.Windows.Forms.Label base64EncodedStringLabel;
        private System.Windows.Forms.Label modeSelectLabel;
        private System.Windows.Forms.ComboBox modeSelectComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button openSingleFileButton;
        private System.Windows.Forms.Button saveToFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}
