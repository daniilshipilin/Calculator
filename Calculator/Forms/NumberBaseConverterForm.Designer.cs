namespace Calculator.Forms
{
    partial class NumberBaseConverterForm
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
            this.components = new System.ComponentModel.Container();
            this.binaryLabel = new System.Windows.Forms.Label();
            this.octalLabel = new System.Windows.Forms.Label();
            this.decimalLabel = new System.Windows.Forms.Label();
            this.hexadecimalLabel = new System.Windows.Forms.Label();
            this.octalTextBox = new System.Windows.Forms.TextBox();
            this.binaryTextBox = new System.Windows.Forms.TextBox();
            this.decimalTextBox = new System.Windows.Forms.TextBox();
            this.hexadecimalTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.invertValueButton = new System.Windows.Forms.Button();
            this.numberBaseConverterFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            //
            // binaryLabel
            //
            this.binaryLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.binaryLabel.ForeColor = System.Drawing.Color.Black;
            this.binaryLabel.Location = new System.Drawing.Point(14, 43);
            this.binaryLabel.Margin = new System.Windows.Forms.Padding(5);
            this.binaryLabel.Name = "binaryLabel";
            this.binaryLabel.Size = new System.Drawing.Size(65, 15);
            this.binaryLabel.TabIndex = 0;
            this.binaryLabel.Text = "Binary:";
            this.binaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // octalLabel
            //
            this.octalLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.octalLabel.ForeColor = System.Drawing.Color.Black;
            this.octalLabel.Location = new System.Drawing.Point(14, 76);
            this.octalLabel.Margin = new System.Windows.Forms.Padding(5);
            this.octalLabel.Name = "octalLabel";
            this.octalLabel.Size = new System.Drawing.Size(65, 15);
            this.octalLabel.TabIndex = 0;
            this.octalLabel.Text = "Octal:";
            this.octalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // decimalLabel
            //
            this.decimalLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decimalLabel.ForeColor = System.Drawing.Color.Black;
            this.decimalLabel.Location = new System.Drawing.Point(14, 109);
            this.decimalLabel.Margin = new System.Windows.Forms.Padding(5);
            this.decimalLabel.Name = "decimalLabel";
            this.decimalLabel.Size = new System.Drawing.Size(65, 15);
            this.decimalLabel.TabIndex = 0;
            this.decimalLabel.Text = "Decimal:";
            this.decimalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // hexadecimalLabel
            //
            this.hexadecimalLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexadecimalLabel.ForeColor = System.Drawing.Color.Black;
            this.hexadecimalLabel.Location = new System.Drawing.Point(14, 142);
            this.hexadecimalLabel.Margin = new System.Windows.Forms.Padding(5);
            this.hexadecimalLabel.Name = "hexadecimalLabel";
            this.hexadecimalLabel.Size = new System.Drawing.Size(65, 15);
            this.hexadecimalLabel.TabIndex = 0;
            this.hexadecimalLabel.Text = "Hex:";
            this.hexadecimalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // octalTextBox
            //
            this.octalTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.octalTextBox.ForeColor = System.Drawing.Color.Black;
            this.octalTextBox.Location = new System.Drawing.Point(89, 73);
            this.octalTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.octalTextBox.Name = "octalTextBox";
            this.octalTextBox.Size = new System.Drawing.Size(381, 23);
            this.octalTextBox.TabIndex = 4;
            this.octalTextBox.TextChanged += new System.EventHandler(this.OctalTextBox_TextChanged);
            //
            // binaryTextBox
            //
            this.binaryTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.binaryTextBox.ForeColor = System.Drawing.Color.Black;
            this.binaryTextBox.Location = new System.Drawing.Point(89, 40);
            this.binaryTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.binaryTextBox.Name = "binaryTextBox";
            this.binaryTextBox.Size = new System.Drawing.Size(381, 23);
            this.binaryTextBox.TabIndex = 3;
            this.binaryTextBox.TextChanged += new System.EventHandler(this.BinaryTextBox_TextChanged);
            //
            // decimalTextBox
            //
            this.decimalTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decimalTextBox.ForeColor = System.Drawing.Color.Black;
            this.decimalTextBox.Location = new System.Drawing.Point(89, 106);
            this.decimalTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.decimalTextBox.Name = "decimalTextBox";
            this.decimalTextBox.Size = new System.Drawing.Size(381, 23);
            this.decimalTextBox.TabIndex = 0;
            this.decimalTextBox.TextChanged += new System.EventHandler(this.DecimalTextBox_TextChanged);
            //
            // hexadecimalTextBox
            //
            this.hexadecimalTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hexadecimalTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexadecimalTextBox.ForeColor = System.Drawing.Color.Black;
            this.hexadecimalTextBox.Location = new System.Drawing.Point(89, 139);
            this.hexadecimalTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.hexadecimalTextBox.Name = "hexadecimalTextBox";
            this.hexadecimalTextBox.Size = new System.Drawing.Size(381, 23);
            this.hexadecimalTextBox.TabIndex = 1;
            this.hexadecimalTextBox.TextChanged += new System.EventHandler(this.HexadecimalTextBox_TextChanged);
            //
            // clearButton
            //
            this.clearButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clearButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.DarkRed;
            this.clearButton.Location = new System.Drawing.Point(199, 172);
            this.clearButton.Margin = new System.Windows.Forms.Padding(5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 25);
            this.clearButton.TabIndex = 0;
            this.clearButton.TabStop = false;
            this.clearButton.Text = "Clear all";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            //
            // infoLabel
            //
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(85, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(279, 19);
            this.infoLabel.TabIndex = 5;
            this.infoLabel.Text = "Enter a value in any box below";
            //
            // invertValueButton
            //
            this.invertValueButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.invertValueButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invertValueButton.ForeColor = System.Drawing.Color.Black;
            this.invertValueButton.Location = new System.Drawing.Point(89, 172);
            this.invertValueButton.Margin = new System.Windows.Forms.Padding(5);
            this.invertValueButton.Name = "invertValueButton";
            this.invertValueButton.Size = new System.Drawing.Size(100, 25);
            this.invertValueButton.TabIndex = 6;
            this.invertValueButton.TabStop = false;
            this.invertValueButton.Text = "Invert";
            this.invertValueButton.UseVisualStyleBackColor = false;
            this.invertValueButton.Click += new System.EventHandler(this.InvertValueButton_Click);
            //
            // numberBaseConverterFormToolTip
            //
            this.numberBaseConverterFormToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            //
            // NumberBaseConverterForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.invertValueButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.hexadecimalTextBox);
            this.Controls.Add(this.decimalTextBox);
            this.Controls.Add(this.binaryTextBox);
            this.Controls.Add(this.octalTextBox);
            this.Controls.Add(this.hexadecimalLabel);
            this.Controls.Add(this.decimalLabel);
            this.Controls.Add(this.octalLabel);
            this.Controls.Add(this.binaryLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NumberBaseConverterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Number Base Converter";
            this.Load += new System.EventHandler(this.NumberBaseConverterForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumberBaseConverterForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label binaryLabel;
        private System.Windows.Forms.Label octalLabel;
        private System.Windows.Forms.Label decimalLabel;
        private System.Windows.Forms.Label hexadecimalLabel;
        private System.Windows.Forms.TextBox octalTextBox;
        private System.Windows.Forms.TextBox binaryTextBox;
        private System.Windows.Forms.TextBox decimalTextBox;
        private System.Windows.Forms.TextBox hexadecimalTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button invertValueButton;
        private System.Windows.Forms.ToolTip numberBaseConverterFormToolTip;
    }
}
