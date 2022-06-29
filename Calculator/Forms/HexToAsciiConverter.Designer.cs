namespace Calculator.Forms
{
    partial class HexToAsciiConverterForm
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
            this.hexLabel = new System.Windows.Forms.Label();
            this.hexTextBox = new System.Windows.Forms.TextBox();
            this.convertToAsciiButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.convertToHexButton = new System.Windows.Forms.Button();
            this.asciiLabel = new System.Windows.Forms.Label();
            this.asciiTextBox = new System.Windows.Forms.TextBox();
            this.hexDelimiterLabel = new System.Windows.Forms.Label();
            this.hexDelimiterTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // hexLabel
            //
            this.hexLabel.AutoSize = true;
            this.hexLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hexLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hexLabel.ForeColor = System.Drawing.Color.Black;
            this.hexLabel.Location = new System.Drawing.Point(14, 14);
            this.hexLabel.Margin = new System.Windows.Forms.Padding(5);
            this.hexLabel.Name = "hexLabel";
            this.hexLabel.Size = new System.Drawing.Size(35, 15);
            this.hexLabel.TabIndex = 0;
            this.hexLabel.Text = "HEX:";
            //
            // hexTextBox
            //
            this.hexTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexTextBox.ForeColor = System.Drawing.Color.Black;
            this.hexTextBox.Location = new System.Drawing.Point(14, 39);
            this.hexTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.hexTextBox.MaxLength = 2147483647;
            this.hexTextBox.Multiline = true;
            this.hexTextBox.Name = "hexTextBox";
            this.hexTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.hexTextBox.Size = new System.Drawing.Size(456, 80);
            this.hexTextBox.TabIndex = 0;
            this.hexTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HexTextBox_KeyDown);
            //
            // convertToAsciiButton
            //
            this.convertToAsciiButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.convertToAsciiButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.convertToAsciiButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.convertToAsciiButton.Location = new System.Drawing.Point(14, 129);
            this.convertToAsciiButton.Margin = new System.Windows.Forms.Padding(5);
            this.convertToAsciiButton.Name = "convertToAsciiButton";
            this.convertToAsciiButton.Size = new System.Drawing.Size(150, 23);
            this.convertToAsciiButton.TabIndex = 1;
            this.convertToAsciiButton.Text = "Convert to ASCII ▼";
            this.convertToAsciiButton.UseVisualStyleBackColor = false;
            this.convertToAsciiButton.Click += new System.EventHandler(this.ConvertToAsciiButton_Click);
            //
            // clearButton
            //
            this.clearButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clearButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.DarkRed;
            this.clearButton.Location = new System.Drawing.Point(370, 129);
            this.clearButton.Margin = new System.Windows.Forms.Padding(5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear All";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            //
            // convertToHexButton
            //
            this.convertToHexButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.convertToHexButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.convertToHexButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.convertToHexButton.Location = new System.Drawing.Point(174, 129);
            this.convertToHexButton.Margin = new System.Windows.Forms.Padding(5);
            this.convertToHexButton.Name = "convertToHexButton";
            this.convertToHexButton.Size = new System.Drawing.Size(150, 23);
            this.convertToHexButton.TabIndex = 3;
            this.convertToHexButton.Text = "Convert to HEX ▲";
            this.convertToHexButton.UseVisualStyleBackColor = false;
            this.convertToHexButton.Click += new System.EventHandler(this.ConvertToHexButton_Click);
            //
            // asciiLabel
            //
            this.asciiLabel.AutoSize = true;
            this.asciiLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.asciiLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.asciiLabel.ForeColor = System.Drawing.Color.Black;
            this.asciiLabel.Location = new System.Drawing.Point(14, 162);
            this.asciiLabel.Margin = new System.Windows.Forms.Padding(5);
            this.asciiLabel.Name = "asciiLabel";
            this.asciiLabel.Size = new System.Drawing.Size(84, 15);
            this.asciiLabel.TabIndex = 0;
            this.asciiLabel.Text = "ASCII Text:";
            //
            // asciiTextBox
            //
            this.asciiTextBox.AcceptsReturn = true;
            this.asciiTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asciiTextBox.ForeColor = System.Drawing.Color.Black;
            this.asciiTextBox.Location = new System.Drawing.Point(14, 187);
            this.asciiTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.asciiTextBox.MaxLength = 2147483647;
            this.asciiTextBox.Multiline = true;
            this.asciiTextBox.Name = "asciiTextBox";
            this.asciiTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.asciiTextBox.Size = new System.Drawing.Size(456, 80);
            this.asciiTextBox.TabIndex = 2;
            this.asciiTextBox.WordWrap = false;
            this.asciiTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AsciiTextBox_KeyDown);
            //
            // hexDelimiterLabel
            //
            this.hexDelimiterLabel.AutoSize = true;
            this.hexDelimiterLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hexDelimiterLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hexDelimiterLabel.ForeColor = System.Drawing.Color.Black;
            this.hexDelimiterLabel.Location = new System.Drawing.Point(327, 14);
            this.hexDelimiterLabel.Margin = new System.Windows.Forms.Padding(5);
            this.hexDelimiterLabel.Name = "hexDelimiterLabel";
            this.hexDelimiterLabel.Size = new System.Drawing.Size(105, 15);
            this.hexDelimiterLabel.TabIndex = 0;
            this.hexDelimiterLabel.Text = "HEX delimiter:";
            //
            // hexDelimiterTextBox
            //
            this.hexDelimiterTextBox.ForeColor = System.Drawing.Color.Black;
            this.hexDelimiterTextBox.Location = new System.Drawing.Point(440, 11);
            this.hexDelimiterTextBox.Name = "hexDelimiterTextBox";
            this.hexDelimiterTextBox.Size = new System.Drawing.Size(30, 23);
            this.hexDelimiterTextBox.TabIndex = 0;
            this.hexDelimiterTextBox.TabStop = false;
            this.hexDelimiterTextBox.TextChanged += new System.EventHandler(this.HexDelimiterTextBox_TextChanged);
            //
            // HexToAsciiConverterForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 284);
            this.Controls.Add(this.hexDelimiterTextBox);
            this.Controls.Add(this.hexDelimiterLabel);
            this.Controls.Add(this.asciiTextBox);
            this.Controls.Add(this.asciiLabel);
            this.Controls.Add(this.convertToHexButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.convertToAsciiButton);
            this.Controls.Add(this.hexTextBox);
            this.Controls.Add(this.hexLabel);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HexToAsciiConverterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HEX To ASCII Converter";
            this.Load += new System.EventHandler(this.HexToAsciiConverterForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HexToAsciiConverterForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hexLabel;
        private System.Windows.Forms.TextBox hexTextBox;
        private System.Windows.Forms.Button convertToAsciiButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button convertToHexButton;
        private System.Windows.Forms.Label asciiLabel;
        private System.Windows.Forms.TextBox asciiTextBox;
        private System.Windows.Forms.Label hexDelimiterLabel;
        private System.Windows.Forms.TextBox hexDelimiterTextBox;
    }
}
