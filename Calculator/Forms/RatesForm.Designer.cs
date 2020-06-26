namespace Calculator.Forms
{
    partial class RatesForm
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
            this.ratesTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // ratesTextBox
            //
            this.ratesTextBox.AcceptsReturn = true;
            this.ratesTextBox.AcceptsTab = true;
            this.ratesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ratesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ratesTextBox.Location = new System.Drawing.Point(5, 5);
            this.ratesTextBox.Multiline = true;
            this.ratesTextBox.Name = "ratesTextBox";
            this.ratesTextBox.ReadOnly = true;
            this.ratesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ratesTextBox.Size = new System.Drawing.Size(224, 351);
            this.ratesTextBox.TabIndex = 0;
            this.ratesTextBox.TabStop = false;
            this.ratesTextBox.WordWrap = false;
            //
            // RatesForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 361);
            this.Controls.Add(this.ratesTextBox);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Name = "RatesForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox ratesTextBox;
    }
}