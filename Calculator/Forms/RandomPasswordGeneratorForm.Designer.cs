namespace Calculator
{
    partial class RandomPasswordGeneratorForm
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
            this.qtyLabel = new System.Windows.Forms.Label();
            this.qtyTextBox = new System.Windows.Forms.TextBox();
            this.charsetSelectComboBox = new System.Windows.Forms.ComboBox();
            this.charsetLabel = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.charsetCharsTextBox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.charsetCharsCountLabel = new System.Windows.Forms.Label();
            this.passwordLengthLabel = new System.Windows.Forms.Label();
            this.passwordLengthTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.editCheckBox = new System.Windows.Forms.CheckBox();
            this.uniqueSequenceCheckBox = new System.Windows.Forms.CheckBox();
            this.saveToFileButton = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // qtyLabel
            //
            this.qtyLabel.AutoSize = true;
            this.qtyLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.qtyLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qtyLabel.ForeColor = System.Drawing.Color.Black;
            this.qtyLabel.Location = new System.Drawing.Point(42, 14);
            this.qtyLabel.Margin = new System.Windows.Forms.Padding(5);
            this.qtyLabel.Name = "qtyLabel";
            this.qtyLabel.Size = new System.Drawing.Size(35, 15);
            this.qtyLabel.TabIndex = 1;
            this.qtyLabel.Text = "Qty:";
            //
            // qtyTextBox
            //
            this.qtyTextBox.ForeColor = System.Drawing.Color.Black;
            this.qtyTextBox.Location = new System.Drawing.Point(87, 11);
            this.qtyTextBox.Name = "qtyTextBox";
            this.qtyTextBox.Size = new System.Drawing.Size(100, 23);
            this.qtyTextBox.TabIndex = 1;
            this.qtyTextBox.TextChanged += new System.EventHandler(this.QtyTextBox_TextChanged);
            //
            // charsetSelectComboBox
            //
            this.charsetSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.charsetSelectComboBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.charsetSelectComboBox.ForeColor = System.Drawing.Color.Black;
            this.charsetSelectComboBox.FormattingEnabled = true;
            this.charsetSelectComboBox.Items.AddRange(new object[]
            {
                "NUMERIC",
                "SYMBOLS14",
                "SYMBOLS_ALL",
                "HEX_LOWER",
                "HEX_UPPER",
                "LALPHA",
                "LALPHA_NUMERIC",
                "LALPHA_NUMERIC_ALL",
                "LALPHA_NUMERIC_SYMBOL14",
                "UALPHA",
                "UALPHA_NUMERIC",
                "UALPHA_NUMERIC_ALL",
                "UALPHA_NUMERIC_SYMBOL14",
                "MIXALPHA",
                "MIXALPHA_NUMERIC",
                "MIXALPHA_NUMERIC_ALL",
                "MIXALPHA_NUMERIC_SYMBOL14"
            });
            this.charsetSelectComboBox.Location = new System.Drawing.Point(268, 11);
            this.charsetSelectComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.charsetSelectComboBox.Name = "charsetSelectComboBox";
            this.charsetSelectComboBox.Size = new System.Drawing.Size(202, 23);
            this.charsetSelectComboBox.TabIndex = 3;
            this.charsetSelectComboBox.SelectedValueChanged += new System.EventHandler(this.CharsetSelectComboBox_SelectedValueChanged);
            //
            // charsetLabel
            //
            this.charsetLabel.AutoSize = true;
            this.charsetLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.charsetLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.charsetLabel.ForeColor = System.Drawing.Color.Black;
            this.charsetLabel.Location = new System.Drawing.Point(195, 14);
            this.charsetLabel.Margin = new System.Windows.Forms.Padding(5);
            this.charsetLabel.Name = "charsetLabel";
            this.charsetLabel.Size = new System.Drawing.Size(63, 15);
            this.charsetLabel.TabIndex = 4;
            this.charsetLabel.Text = "Charset:";
            //
            // generateButton
            //
            this.generateButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.generateButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.generateButton.Location = new System.Drawing.Point(14, 75);
            this.generateButton.Margin = new System.Windows.Forms.Padding(5);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(100, 23);
            this.generateButton.TabIndex = 4;
            this.generateButton.Text = "Generate ▼";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            //
            // outputTextBox
            //
            this.outputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.ForeColor = System.Drawing.Color.Black;
            this.outputTextBox.Location = new System.Drawing.Point(14, 112);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.outputTextBox.MaxLength = 2147483647;
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(456, 102);
            this.outputTextBox.TabIndex = 5;
            this.outputTextBox.WordWrap = false;
            //
            // clearButton
            //
            this.clearButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clearButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.DarkRed;
            this.clearButton.Location = new System.Drawing.Point(370, 224);
            this.clearButton.Margin = new System.Windows.Forms.Padding(5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            //
            // charsetCharsTextBox
            //
            this.charsetCharsTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charsetCharsTextBox.ForeColor = System.Drawing.Color.Black;
            this.charsetCharsTextBox.Location = new System.Drawing.Point(268, 42);
            this.charsetCharsTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.charsetCharsTextBox.MaxLength = 2147483647;
            this.charsetCharsTextBox.Multiline = true;
            this.charsetCharsTextBox.Name = "charsetCharsTextBox";
            this.charsetCharsTextBox.ReadOnly = true;
            this.charsetCharsTextBox.Size = new System.Drawing.Size(202, 56);
            this.charsetCharsTextBox.TabIndex = 0;
            this.charsetCharsTextBox.TabStop = false;
            this.charsetCharsTextBox.TextChanged += new System.EventHandler(this.CharsetCharsTextBox_TextChanged);
            //
            // progressBar
            //
            this.progressBar.Location = new System.Drawing.Point(12, 255);
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(460, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 0;
            //
            // charsetCharsCountLabel
            //
            this.charsetCharsCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.charsetCharsCountLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.charsetCharsCountLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.charsetCharsCountLabel.ForeColor = System.Drawing.Color.Black;
            this.charsetCharsCountLabel.Location = new System.Drawing.Point(158, 79);
            this.charsetCharsCountLabel.Margin = new System.Windows.Forms.Padding(5);
            this.charsetCharsCountLabel.Name = "charsetCharsCountLabel";
            this.charsetCharsCountLabel.Size = new System.Drawing.Size(100, 15);
            this.charsetCharsCountLabel.TabIndex = 12;
            this.charsetCharsCountLabel.Text = "0 char(s)";
            this.charsetCharsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // passwordLengthLabel
            //
            this.passwordLengthLabel.AutoSize = true;
            this.passwordLengthLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.passwordLengthLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordLengthLabel.ForeColor = System.Drawing.Color.Black;
            this.passwordLengthLabel.Location = new System.Drawing.Point(23, 43);
            this.passwordLengthLabel.Margin = new System.Windows.Forms.Padding(5);
            this.passwordLengthLabel.Name = "passwordLengthLabel";
            this.passwordLengthLabel.Size = new System.Drawing.Size(56, 15);
            this.passwordLengthLabel.TabIndex = 13;
            this.passwordLengthLabel.Text = "Length:";
            //
            // passwordLengthTextBox
            //
            this.passwordLengthTextBox.ForeColor = System.Drawing.Color.Black;
            this.passwordLengthTextBox.Location = new System.Drawing.Point(87, 40);
            this.passwordLengthTextBox.Name = "passwordLengthTextBox";
            this.passwordLengthTextBox.Size = new System.Drawing.Size(100, 23);
            this.passwordLengthTextBox.TabIndex = 2;
            this.passwordLengthTextBox.TextChanged += new System.EventHandler(this.PasswordLengthTextBox_TextChanged);
            //
            // statusStrip
            //
            this.statusStrip.BackColor = System.Drawing.Color.Gainsboro;
            this.statusStrip.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.toolStripStatusLabel
            });
            this.statusStrip.Location = new System.Drawing.Point(0, 285);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(484, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            //
            // toolStripStatusLabel
            //
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            //
            // editCheckBox
            //
            this.editCheckBox.AutoSize = true;
            this.editCheckBox.Location = new System.Drawing.Point(206, 44);
            this.editCheckBox.Name = "editCheckBox";
            this.editCheckBox.Size = new System.Drawing.Size(54, 19);
            this.editCheckBox.TabIndex = 14;
            this.editCheckBox.Text = "Edit";
            this.editCheckBox.UseVisualStyleBackColor = true;
            this.editCheckBox.CheckedChanged += new System.EventHandler(this.EditCheckBox_CheckedChanged);
            //
            // uniqueSequenceCheckBox
            //
            this.uniqueSequenceCheckBox.AutoSize = true;
            this.uniqueSequenceCheckBox.Checked = true;
            this.uniqueSequenceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uniqueSequenceCheckBox.Location = new System.Drawing.Point(14, 222);
            this.uniqueSequenceCheckBox.Name = "uniqueSequenceCheckBox";
            this.uniqueSequenceCheckBox.Size = new System.Drawing.Size(187, 19);
            this.uniqueSequenceCheckBox.TabIndex = 15;
            this.uniqueSequenceCheckBox.Text = "Unique char(s) sequence";
            this.uniqueSequenceCheckBox.UseVisualStyleBackColor = true;
            //
            // saveToFileButton
            //
            this.saveToFileButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.saveToFileButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveToFileButton.Location = new System.Drawing.Point(260, 224);
            this.saveToFileButton.Margin = new System.Windows.Forms.Padding(5);
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(100, 23);
            this.saveToFileButton.TabIndex = 16;
            this.saveToFileButton.Text = "Save To File";
            this.saveToFileButton.UseVisualStyleBackColor = false;
            this.saveToFileButton.Click += new System.EventHandler(this.SaveToFileButton_Click);
            //
            // RandomPasswordGeneratorForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 307);
            this.Controls.Add(this.saveToFileButton);
            this.Controls.Add(this.uniqueSequenceCheckBox);
            this.Controls.Add(this.editCheckBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.passwordLengthTextBox);
            this.Controls.Add(this.passwordLengthLabel);
            this.Controls.Add(this.charsetCharsCountLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.charsetCharsTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.charsetLabel);
            this.Controls.Add(this.charsetSelectComboBox);
            this.Controls.Add(this.qtyTextBox);
            this.Controls.Add(this.qtyLabel);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandomPasswordGeneratorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Random Password Generator";
            this.Load += new System.EventHandler(this.RandomPasswordGeneratorForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RandomPasswordGeneratorForm_KeyDown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label qtyLabel;
        private System.Windows.Forms.TextBox qtyTextBox;
        private System.Windows.Forms.ComboBox charsetSelectComboBox;
        private System.Windows.Forms.Label charsetLabel;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox charsetCharsTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label charsetCharsCountLabel;
        private System.Windows.Forms.Label passwordLengthLabel;
        private System.Windows.Forms.TextBox passwordLengthTextBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.CheckBox editCheckBox;
        private System.Windows.Forms.CheckBox uniqueSequenceCheckBox;
        private System.Windows.Forms.Button saveToFileButton;
    }
}