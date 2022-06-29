namespace Calculator.Forms
{
    partial class CurrencyConverterForm
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
			this.switchButton = new System.Windows.Forms.Button();
			this.amountFromTextBox = new System.Windows.Forms.TextBox();
			this.amountToTextBox = new System.Windows.Forms.TextBox();
			this.currencyFromComboBox = new System.Windows.Forms.ComboBox();
			this.currencyToComboBox = new System.Windows.Forms.ComboBox();
			this.convertButton = new System.Windows.Forms.Button();
			this.statusLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.baseCurrencyTextBox = new System.Windows.Forms.TextBox();
			this.dateStampTextBox = new System.Windows.Forms.TextBox();
			this.enterLabel = new System.Windows.Forms.Label();
			this.getRatesButton = new System.Windows.Forms.Button();
			this.rateToTextBox = new System.Windows.Forms.TextBox();
			this.rateLabel = new System.Windows.Forms.Label();
			this.currencyLabel = new System.Windows.Forms.Label();
			this.updateCheckBox = new System.Windows.Forms.CheckBox();
			this.autoConvertCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// switchButton
			// 
			this.switchButton.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.switchButton.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.switchButton.Location = new System.Drawing.Point(12, 98);
			this.switchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.switchButton.Name = "switchButton";
			this.switchButton.Size = new System.Drawing.Size(56, 26);
			this.switchButton.TabIndex = 0;
			this.switchButton.TabStop = false;
			this.switchButton.Text = "⇅";
			this.switchButton.UseVisualStyleBackColor = false;
			this.switchButton.Click += new System.EventHandler(this.SwitchButton_Click);
			// 
			// amountFromTextBox
			// 
			this.amountFromTextBox.Location = new System.Drawing.Point(127, 36);
			this.amountFromTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.amountFromTextBox.Name = "amountFromTextBox";
			this.amountFromTextBox.Size = new System.Drawing.Size(100, 23);
			this.amountFromTextBox.TabIndex = 1;
			this.amountFromTextBox.TextChanged += new System.EventHandler(this.AmountFromTextBox_TextChanged);
			// 
			// amountToTextBox
			// 
			this.amountToTextBox.Location = new System.Drawing.Point(127, 68);
			this.amountToTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.amountToTextBox.Name = "amountToTextBox";
			this.amountToTextBox.ReadOnly = true;
			this.amountToTextBox.Size = new System.Drawing.Size(100, 23);
			this.amountToTextBox.TabIndex = 0;
			this.amountToTextBox.TabStop = false;
			// 
			// currencyFromComboBox
			// 
			this.currencyFromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.currencyFromComboBox.FormattingEnabled = true;
			this.currencyFromComboBox.Location = new System.Drawing.Point(12, 36);
			this.currencyFromComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.currencyFromComboBox.Name = "currencyFromComboBox";
			this.currencyFromComboBox.Size = new System.Drawing.Size(56, 23);
			this.currencyFromComboBox.TabIndex = 0;
			this.currencyFromComboBox.TabStop = false;
			this.currencyFromComboBox.SelectedIndexChanged += new System.EventHandler(this.CurrencyFromComboBox_SelectedIndexChanged);
			// 
			// currencyToComboBox
			// 
			this.currencyToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.currencyToComboBox.FormattingEnabled = true;
			this.currencyToComboBox.Location = new System.Drawing.Point(12, 68);
			this.currencyToComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.currencyToComboBox.Name = "currencyToComboBox";
			this.currencyToComboBox.Size = new System.Drawing.Size(56, 23);
			this.currencyToComboBox.TabIndex = 0;
			this.currencyToComboBox.TabStop = false;
			this.currencyToComboBox.SelectedIndexChanged += new System.EventHandler(this.CurrencyToComboBox_SelectedIndexChanged);
			// 
			// convertButton
			// 
			this.convertButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.convertButton.ForeColor = System.Drawing.Color.DarkGreen;
			this.convertButton.Location = new System.Drawing.Point(127, 99);
			this.convertButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.convertButton.Name = "convertButton";
			this.convertButton.Size = new System.Drawing.Size(100, 26);
			this.convertButton.TabIndex = 2;
			this.convertButton.Text = "Convert";
			this.convertButton.UseVisualStyleBackColor = false;
			this.convertButton.Click += new System.EventHandler(this.ConvertButton_Click);
			// 
			// statusLabel
			// 
			this.statusLabel.Location = new System.Drawing.Point(12, 129);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(424, 48);
			this.statusLabel.TabIndex = 0;
			this.statusLabel.Text = "statusLabel";
			this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(243, 39);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 15);
			this.label1.TabIndex = 8;
			this.label1.Text = "Base curr.:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(250, 70);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 15);
			this.label2.TabIndex = 11;
			this.label2.Text = "Timestamp:";
			// 
			// baseCurrencyTextBox
			// 
			this.baseCurrencyTextBox.Location = new System.Drawing.Point(333, 36);
			this.baseCurrencyTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.baseCurrencyTextBox.Name = "baseCurrencyTextBox";
			this.baseCurrencyTextBox.ReadOnly = true;
			this.baseCurrencyTextBox.Size = new System.Drawing.Size(103, 23);
			this.baseCurrencyTextBox.TabIndex = 0;
			this.baseCurrencyTextBox.TabStop = false;
			// 
			// dateStampTextBox
			// 
			this.dateStampTextBox.Location = new System.Drawing.Point(333, 67);
			this.dateStampTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dateStampTextBox.Name = "dateStampTextBox";
			this.dateStampTextBox.ReadOnly = true;
			this.dateStampTextBox.Size = new System.Drawing.Size(103, 23);
			this.dateStampTextBox.TabIndex = 0;
			this.dateStampTextBox.TabStop = false;
			// 
			// enterLabel
			// 
			this.enterLabel.AutoSize = true;
			this.enterLabel.Location = new System.Drawing.Point(124, 13);
			this.enterLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.enterLabel.Name = "enterLabel";
			this.enterLabel.Size = new System.Drawing.Size(91, 15);
			this.enterLabel.TabIndex = 12;
			this.enterLabel.Text = "Enter amount";
			// 
			// getRatesButton
			// 
			this.getRatesButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.getRatesButton.ForeColor = System.Drawing.Color.Indigo;
			this.getRatesButton.Location = new System.Drawing.Point(333, 99);
			this.getRatesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.getRatesButton.Name = "getRatesButton";
			this.getRatesButton.Size = new System.Drawing.Size(103, 26);
			this.getRatesButton.TabIndex = 0;
			this.getRatesButton.TabStop = false;
			this.getRatesButton.Text = "Get rates";
			this.getRatesButton.UseVisualStyleBackColor = false;
			this.getRatesButton.Click += new System.EventHandler(this.GetRatesButton_Click);
			// 
			// rateToTextBox
			// 
			this.rateToTextBox.Location = new System.Drawing.Point(74, 68);
			this.rateToTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rateToTextBox.Name = "rateToTextBox";
			this.rateToTextBox.ReadOnly = true;
			this.rateToTextBox.Size = new System.Drawing.Size(47, 23);
			this.rateToTextBox.TabIndex = 17;
			this.rateToTextBox.TabStop = false;
			this.rateToTextBox.Click += new System.EventHandler(this.RateToTextBox_Click);
			// 
			// rateLabel
			// 
			this.rateLabel.AutoSize = true;
			this.rateLabel.Location = new System.Drawing.Point(71, 13);
			this.rateLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rateLabel.Name = "rateLabel";
			this.rateLabel.Size = new System.Drawing.Size(35, 15);
			this.rateLabel.TabIndex = 18;
			this.rateLabel.Text = "Rate";
			// 
			// currencyLabel
			// 
			this.currencyLabel.AutoSize = true;
			this.currencyLabel.Location = new System.Drawing.Point(9, 13);
			this.currencyLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.currencyLabel.Name = "currencyLabel";
			this.currencyLabel.Size = new System.Drawing.Size(42, 15);
			this.currencyLabel.TabIndex = 19;
			this.currencyLabel.Text = "Curr.";
			// 
			// updateCheckBox
			// 
			this.updateCheckBox.AutoSize = true;
			this.updateCheckBox.Checked = true;
			this.updateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.updateCheckBox.Location = new System.Drawing.Point(291, 180);
			this.updateCheckBox.Name = "updateCheckBox";
			this.updateCheckBox.Size = new System.Drawing.Size(110, 19);
			this.updateCheckBox.TabIndex = 0;
			this.updateCheckBox.TabStop = false;
			this.updateCheckBox.Text = "Update rates";
			this.updateCheckBox.UseVisualStyleBackColor = true;
			// 
			// autoConvertCheckBox
			// 
			this.autoConvertCheckBox.AutoSize = true;
			this.autoConvertCheckBox.Location = new System.Drawing.Point(12, 180);
			this.autoConvertCheckBox.Name = "autoConvertCheckBox";
			this.autoConvertCheckBox.Size = new System.Drawing.Size(110, 19);
			this.autoConvertCheckBox.TabIndex = 20;
			this.autoConvertCheckBox.TabStop = false;
			this.autoConvertCheckBox.Text = "Auto convert";
			this.autoConvertCheckBox.UseVisualStyleBackColor = true;
			// 
			// CurrencyConverterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(448, 211);
			this.Controls.Add(this.autoConvertCheckBox);
			this.Controls.Add(this.updateCheckBox);
			this.Controls.Add(this.currencyLabel);
			this.Controls.Add(this.rateLabel);
			this.Controls.Add(this.rateToTextBox);
			this.Controls.Add(this.getRatesButton);
			this.Controls.Add(this.enterLabel);
			this.Controls.Add(this.dateStampTextBox);
			this.Controls.Add(this.baseCurrencyTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.convertButton);
			this.Controls.Add(this.currencyToComboBox);
			this.Controls.Add(this.currencyFromComboBox);
			this.Controls.Add(this.amountToTextBox);
			this.Controls.Add(this.amountFromTextBox);
			this.Controls.Add(this.switchButton);
			this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CurrencyConverterForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Currency Converter";
			this.Load += new System.EventHandler(this.CurrencyConverterForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrencyConverterForm_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button switchButton;
        private System.Windows.Forms.TextBox amountFromTextBox;
        private System.Windows.Forms.TextBox amountToTextBox;
        private System.Windows.Forms.ComboBox currencyFromComboBox;
        private System.Windows.Forms.ComboBox currencyToComboBox;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox baseCurrencyTextBox;
        private System.Windows.Forms.TextBox dateStampTextBox;
        private System.Windows.Forms.Label enterLabel;
        private System.Windows.Forms.Button getRatesButton;
        private System.Windows.Forms.TextBox rateToTextBox;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.Label currencyLabel;
        private System.Windows.Forms.CheckBox updateCheckBox;
        private System.Windows.Forms.CheckBox autoConvertCheckBox;
    }
}
