namespace Calculator.Forms
{

    partial class FuelcostCalculatorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tripDistanceTextBox = new System.Windows.Forms.TextBox();
            this.fuelEfficiencyTextBox = new System.Windows.Forms.TextBox();
            this.fuelPriceLiterTextBox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trip Distance (KM):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fuel Efficiency (L/100KM):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Price (EUR/L):";
            // 
            // tripDistanceTextBox
            // 
            this.tripDistanceTextBox.Location = new System.Drawing.Point(214, 10);
            this.tripDistanceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tripDistanceTextBox.Name = "tripDistanceTextBox";
            this.tripDistanceTextBox.Size = new System.Drawing.Size(100, 23);
            this.tripDistanceTextBox.TabIndex = 1;
            // 
            // fuelEfficiencyTextBox
            // 
            this.fuelEfficiencyTextBox.Location = new System.Drawing.Point(214, 41);
            this.fuelEfficiencyTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fuelEfficiencyTextBox.Name = "fuelEfficiencyTextBox";
            this.fuelEfficiencyTextBox.Size = new System.Drawing.Size(100, 23);
            this.fuelEfficiencyTextBox.TabIndex = 2;
            // 
            // fuelPriceLiterTextBox
            // 
            this.fuelPriceLiterTextBox.Location = new System.Drawing.Point(214, 72);
            this.fuelPriceLiterTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fuelPriceLiterTextBox.Name = "fuelPriceLiterTextBox";
            this.fuelPriceLiterTextBox.Size = new System.Drawing.Size(100, 23);
            this.fuelPriceLiterTextBox.TabIndex = 3;
            // 
            // calculateButton
            // 
            this.calculateButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.calculateButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.calculateButton.Location = new System.Drawing.Point(351, 70);
            this.calculateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(100, 25);
            this.calculateButton.TabIndex = 4;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = false;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(12, 103);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(460, 95);
            this.resultLabel.TabIndex = 0;
            this.resultLabel.Text = "resultLabel";
            // 
            // FuelcostCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.fuelPriceLiterTextBox);
            this.Controls.Add(this.fuelEfficiencyTextBox);
            this.Controls.Add(this.tripDistanceTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FuelcostCalculatorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fuelcost Calculator";
            this.Load += new System.EventHandler(this.FuelcostCalculatorForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FuelcostCalculatorForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tripDistanceTextBox;
        private System.Windows.Forms.TextBox fuelEfficiencyTextBox;
        private System.Windows.Forms.TextBox fuelPriceLiterTextBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label resultLabel;
    }
}
