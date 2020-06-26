namespace Calculator
{
    partial class RandomNumberGeneratorForm
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
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.qtyLabel = new System.Windows.Forms.Label();
            this.minLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.qtyTextBox = new System.Windows.Forms.TextBox();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.clearButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.randomNumberGeneratorFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.generateRandomPictureButton = new System.Windows.Forms.Button();
            this.statusToolStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.rngCheckBox = new System.Windows.Forms.CheckBox();
            this.statusToolStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // outputTextBox
            //
            this.outputTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.ForeColor = System.Drawing.Color.Black;
            this.outputTextBox.Location = new System.Drawing.Point(14, 76);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.outputTextBox.MaxLength = 2147483647;
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(456, 130);
            this.outputTextBox.TabIndex = 4;
            this.outputTextBox.WordWrap = false;
            this.outputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OutputTextBox_KeyDown);
            //
            // qtyLabel
            //
            this.qtyLabel.AutoSize = true;
            this.qtyLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.qtyLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qtyLabel.ForeColor = System.Drawing.Color.Black;
            this.qtyLabel.Location = new System.Drawing.Point(14, 15);
            this.qtyLabel.Margin = new System.Windows.Forms.Padding(5);
            this.qtyLabel.Name = "qtyLabel";
            this.qtyLabel.Size = new System.Drawing.Size(35, 15);
            this.qtyLabel.TabIndex = 0;
            this.qtyLabel.Text = "Qty:";
            //
            // minLabel
            //
            this.minLabel.AutoSize = true;
            this.minLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.minLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minLabel.ForeColor = System.Drawing.Color.Black;
            this.minLabel.Location = new System.Drawing.Point(155, 15);
            this.minLabel.Margin = new System.Windows.Forms.Padding(5);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(56, 15);
            this.minLabel.TabIndex = 0;
            this.minLabel.Text = "Min(X):";
            //
            // maxLabel
            //
            this.maxLabel.AutoSize = true;
            this.maxLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.maxLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxLabel.ForeColor = System.Drawing.Color.Black;
            this.maxLabel.Location = new System.Drawing.Point(317, 15);
            this.maxLabel.Margin = new System.Windows.Forms.Padding(5);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(56, 15);
            this.maxLabel.TabIndex = 0;
            this.maxLabel.Text = "Max(Y):";
            //
            // qtyTextBox
            //
            this.qtyTextBox.ForeColor = System.Drawing.Color.Black;
            this.qtyTextBox.Location = new System.Drawing.Point(57, 12);
            this.qtyTextBox.Name = "qtyTextBox";
            this.qtyTextBox.Size = new System.Drawing.Size(90, 23);
            this.qtyTextBox.TabIndex = 0;
            this.qtyTextBox.TextChanged += new System.EventHandler(this.QtyTextBox_TextChanged);
            //
            // minTextBox
            //
            this.minTextBox.ForeColor = System.Drawing.Color.Black;
            this.minTextBox.Location = new System.Drawing.Point(219, 12);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.Size = new System.Drawing.Size(90, 23);
            this.minTextBox.TabIndex = 1;
            this.minTextBox.TextChanged += new System.EventHandler(this.MinTextBox_TextChanged);
            //
            // maxTextBox
            //
            this.maxTextBox.ForeColor = System.Drawing.Color.Black;
            this.maxTextBox.Location = new System.Drawing.Point(381, 12);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.Size = new System.Drawing.Size(90, 23);
            this.maxTextBox.TabIndex = 2;
            this.maxTextBox.TextChanged += new System.EventHandler(this.MaxTextBox_TextChanged);
            //
            // outputLabel
            //
            this.outputLabel.AutoSize = true;
            this.outputLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.outputLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputLabel.ForeColor = System.Drawing.Color.Black;
            this.outputLabel.Location = new System.Drawing.Point(14, 51);
            this.outputLabel.Margin = new System.Windows.Forms.Padding(5);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(56, 15);
            this.outputLabel.TabIndex = 0;
            this.outputLabel.Text = "Output:";
            //
            // progressBar
            //
            this.progressBar.Location = new System.Drawing.Point(12, 214);
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(458, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 0;
            //
            // clearButton
            //
            this.clearButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clearButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.DarkRed;
            this.clearButton.Location = new System.Drawing.Point(370, 43);
            this.clearButton.Margin = new System.Windows.Forms.Padding(5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 23);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            //
            // generateButton
            //
            this.generateButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.generateButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.generateButton.Location = new System.Drawing.Point(80, 43);
            this.generateButton.Margin = new System.Windows.Forms.Padding(5);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(100, 23);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate ▼";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.GenerateButtonAsync_Click);
            //
            // generateRandomPictureButton
            //
            this.generateRandomPictureButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.generateRandomPictureButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateRandomPictureButton.ForeColor = System.Drawing.Color.Indigo;
            this.generateRandomPictureButton.Location = new System.Drawing.Point(260, 43);
            this.generateRandomPictureButton.Margin = new System.Windows.Forms.Padding(5);
            this.generateRandomPictureButton.Name = "generateRandomPictureButton";
            this.generateRandomPictureButton.Size = new System.Drawing.Size(100, 23);
            this.generateRandomPictureButton.TabIndex = 7;
            this.generateRandomPictureButton.Text = "Random Pic.";
            this.generateRandomPictureButton.UseVisualStyleBackColor = false;
            this.generateRandomPictureButton.Click += new System.EventHandler(this.GenerateRandomPictureButton_Click);
            //
            // statusToolStrip
            //
            this.statusToolStrip.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.toolStripStatusLabel
            });
            this.statusToolStrip.Location = new System.Drawing.Point(0, 245);
            this.statusToolStrip.Name = "statusToolStrip";
            this.statusToolStrip.Size = new System.Drawing.Size(484, 22);
            this.statusToolStrip.SizingGrip = false;
            this.statusToolStrip.TabIndex = 0;
            //
            // toolStripStatusLabel
            //
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            //
            // rngCheckBox
            //
            this.rngCheckBox.AutoSize = true;
            this.rngCheckBox.Checked = true;
            this.rngCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rngCheckBox.Location = new System.Drawing.Point(205, 46);
            this.rngCheckBox.Name = "rngCheckBox";
            this.rngCheckBox.Size = new System.Drawing.Size(47, 19);
            this.rngCheckBox.TabIndex = 8;
            this.rngCheckBox.Text = "RNG";
            this.rngCheckBox.UseVisualStyleBackColor = true;
            //
            // RandomNumberGeneratorForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 267);
            this.Controls.Add(this.rngCheckBox);
            this.Controls.Add(this.statusToolStrip);
            this.Controls.Add(this.generateRandomPictureButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.maxTextBox);
            this.Controls.Add(this.minTextBox);
            this.Controls.Add(this.qtyTextBox);
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.qtyLabel);
            this.Controls.Add(this.outputTextBox);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandomNumberGeneratorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Random Number Generator";
            this.Load += new System.EventHandler(this.RandomNumberGeneratorForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RandomNumberGeneratorForm_KeyDown);
            this.statusToolStrip.ResumeLayout(false);
            this.statusToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label qtyLabel;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.TextBox qtyTextBox;
        private System.Windows.Forms.TextBox minTextBox;
        private System.Windows.Forms.TextBox maxTextBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.ToolTip randomNumberGeneratorFormToolTip;
        private System.Windows.Forms.Button generateRandomPictureButton;
        private System.Windows.Forms.StatusStrip statusToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.CheckBox rngCheckBox;
    }
}