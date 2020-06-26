namespace Calculator
{
    partial class AsciiTableForm
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
            this.asciiTextBox = new System.Windows.Forms.TextBox();
            this.extendedAsciiTextBox = new System.Windows.Forms.TextBox();
            this.extendedAsciiLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.extendedAsciiHeaderTextBox = new System.Windows.Forms.TextBox();
            this.asciiHeaderTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // asciiTextBox
            //
            this.asciiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.asciiTextBox.Location = new System.Drawing.Point(14, 59);
            this.asciiTextBox.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.asciiTextBox.Multiline = true;
            this.asciiTextBox.Name = "asciiTextBox";
            this.asciiTextBox.ReadOnly = true;
            this.asciiTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.asciiTextBox.Size = new System.Drawing.Size(300, 223);
            this.asciiTextBox.TabIndex = 0;
            this.asciiTextBox.TabStop = false;
            this.asciiTextBox.WordWrap = false;
            //
            // extendedAsciiTextBox
            //
            this.extendedAsciiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.extendedAsciiTextBox.Location = new System.Drawing.Point(325, 59);
            this.extendedAsciiTextBox.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.extendedAsciiTextBox.Multiline = true;
            this.extendedAsciiTextBox.Name = "extendedAsciiTextBox";
            this.extendedAsciiTextBox.ReadOnly = true;
            this.extendedAsciiTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.extendedAsciiTextBox.Size = new System.Drawing.Size(300, 223);
            this.extendedAsciiTextBox.TabIndex = 1;
            this.extendedAsciiTextBox.TabStop = false;
            this.extendedAsciiTextBox.WordWrap = false;
            //
            // extendedAsciiLabel
            //
            this.extendedAsciiLabel.AutoSize = true;
            this.extendedAsciiLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.extendedAsciiLabel.ForeColor = System.Drawing.Color.Black;
            this.extendedAsciiLabel.Location = new System.Drawing.Point(322, 14);
            this.extendedAsciiLabel.Margin = new System.Windows.Forms.Padding(5);
            this.extendedAsciiLabel.Name = "extendedAsciiLabel";
            this.extendedAsciiLabel.Size = new System.Drawing.Size(112, 15);
            this.extendedAsciiLabel.TabIndex = 2;
            this.extendedAsciiLabel.Text = "Extended Codes:";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "ASCII Codes:";
            //
            // extendedAsciiHeaderTextBox
            //
            this.extendedAsciiHeaderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.extendedAsciiHeaderTextBox.Location = new System.Drawing.Point(325, 39);
            this.extendedAsciiHeaderTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.extendedAsciiHeaderTextBox.Multiline = true;
            this.extendedAsciiHeaderTextBox.Name = "extendedAsciiHeaderTextBox";
            this.extendedAsciiHeaderTextBox.ReadOnly = true;
            this.extendedAsciiHeaderTextBox.Size = new System.Drawing.Size(300, 20);
            this.extendedAsciiHeaderTextBox.TabIndex = 4;
            this.extendedAsciiHeaderTextBox.TabStop = false;
            this.extendedAsciiHeaderTextBox.WordWrap = false;
            //
            // asciiHeaderTextBox
            //
            this.asciiHeaderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.asciiHeaderTextBox.Location = new System.Drawing.Point(14, 39);
            this.asciiHeaderTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.asciiHeaderTextBox.Multiline = true;
            this.asciiHeaderTextBox.Name = "asciiHeaderTextBox";
            this.asciiHeaderTextBox.ReadOnly = true;
            this.asciiHeaderTextBox.Size = new System.Drawing.Size(300, 20);
            this.asciiHeaderTextBox.TabIndex = 5;
            this.asciiHeaderTextBox.TabStop = false;
            this.asciiHeaderTextBox.WordWrap = false;
            //
            // AsciiTableForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 296);
            this.Controls.Add(this.asciiHeaderTextBox);
            this.Controls.Add(this.extendedAsciiHeaderTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.extendedAsciiLabel);
            this.Controls.Add(this.extendedAsciiTextBox);
            this.Controls.Add(this.asciiTextBox);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AsciiTableForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASCII Table Codes";
            this.Load += new System.EventHandler(this.AsciiTableForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AsciiTableForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox asciiTextBox;
        private System.Windows.Forms.TextBox extendedAsciiTextBox;
        private System.Windows.Forms.Label extendedAsciiLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox extendedAsciiHeaderTextBox;
        private System.Windows.Forms.TextBox asciiHeaderTextBox;
    }
}