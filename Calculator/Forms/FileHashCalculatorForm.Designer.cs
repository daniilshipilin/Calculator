namespace Calculator.Forms
{
    partial class FileHashCalculatorForm
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
            this.openSingleFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openSingleFileButton = new System.Windows.Forms.Button();
            this.openSingleFileLabel = new System.Windows.Forms.Label();
            this.openSingleFileNameLabel = new System.Windows.Forms.Label();
            this.crc32Label = new System.Windows.Forms.Label();
            this.elf32Label = new System.Windows.Forms.Label();
            this.md5Label = new System.Windows.Forms.Label();
            this.sha1Label = new System.Windows.Forms.Label();
            this.sha256Label = new System.Windows.Forms.Label();
            this.sha512Label = new System.Windows.Forms.Label();
            this.crc32TextBox = new System.Windows.Forms.TextBox();
            this.elf32TextBox = new System.Windows.Forms.TextBox();
            this.md5TextBox = new System.Windows.Forms.TextBox();
            this.sha1TextBox = new System.Windows.Forms.TextBox();
            this.sha256TextBox = new System.Windows.Forms.TextBox();
            this.sha512TextBox = new System.Windows.Forms.TextBox();
            this.calculateHashesButton = new System.Windows.Forms.Button();
            this.crc32CheckBox = new System.Windows.Forms.CheckBox();
            this.elf32CheckBox = new System.Windows.Forms.CheckBox();
            this.md5CheckBox = new System.Windows.Forms.CheckBox();
            this.sha1CheckBox = new System.Windows.Forms.CheckBox();
            this.sha256CheckBox = new System.Windows.Forms.CheckBox();
            this.sha512CheckBox = new System.Windows.Forms.CheckBox();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.resultsButton = new System.Windows.Forms.Button();
            this.calculateFileHashFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.executionStatusLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.sha384TextBox = new System.Windows.Forms.TextBox();
            this.sha384Label = new System.Windows.Forms.Label();
            this.sha384CheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            //
            // openSingleFileButton
            //
            this.openSingleFileButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.openSingleFileButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openSingleFileButton.ForeColor = System.Drawing.Color.Black;
            this.openSingleFileButton.Location = new System.Drawing.Point(14, 39);
            this.openSingleFileButton.Margin = new System.Windows.Forms.Padding(5);
            this.openSingleFileButton.Name = "openSingleFileButton";
            this.openSingleFileButton.Size = new System.Drawing.Size(100, 23);
            this.openSingleFileButton.TabIndex = 0;
            this.openSingleFileButton.Text = "Browse...";
            this.openSingleFileButton.UseVisualStyleBackColor = false;
            this.openSingleFileButton.Click += new System.EventHandler(this.OpenSingleFileAsyncButton_Click);
            //
            // openSingleFileLabel
            //
            this.openSingleFileLabel.AutoSize = true;
            this.openSingleFileLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openSingleFileLabel.ForeColor = System.Drawing.Color.Black;
            this.openSingleFileLabel.Location = new System.Drawing.Point(14, 14);
            this.openSingleFileLabel.Margin = new System.Windows.Forms.Padding(5);
            this.openSingleFileLabel.Name = "openSingleFileLabel";
            this.openSingleFileLabel.Size = new System.Drawing.Size(42, 15);
            this.openSingleFileLabel.TabIndex = 0;
            this.openSingleFileLabel.Text = "File:";
            //
            // openSingleFileNameLabel
            //
            this.openSingleFileNameLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openSingleFileNameLabel.ForeColor = System.Drawing.Color.Black;
            this.openSingleFileNameLabel.Location = new System.Drawing.Point(66, 14);
            this.openSingleFileNameLabel.Margin = new System.Windows.Forms.Padding(5);
            this.openSingleFileNameLabel.Name = "openSingleFileNameLabel";
            this.openSingleFileNameLabel.Size = new System.Drawing.Size(504, 15);
            this.openSingleFileNameLabel.TabIndex = 0;
            //
            // crc32Label
            //
            this.crc32Label.AutoSize = true;
            this.crc32Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crc32Label.ForeColor = System.Drawing.Color.Black;
            this.crc32Label.Location = new System.Drawing.Point(53, 104);
            this.crc32Label.Margin = new System.Windows.Forms.Padding(5);
            this.crc32Label.Name = "crc32Label";
            this.crc32Label.Size = new System.Drawing.Size(49, 15);
            this.crc32Label.TabIndex = 0;
            this.crc32Label.Text = "CRC32:";
            //
            // elf32Label
            //
            this.elf32Label.AutoSize = true;
            this.elf32Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elf32Label.ForeColor = System.Drawing.Color.Black;
            this.elf32Label.Location = new System.Drawing.Point(53, 137);
            this.elf32Label.Margin = new System.Windows.Forms.Padding(5);
            this.elf32Label.Name = "elf32Label";
            this.elf32Label.Size = new System.Drawing.Size(49, 15);
            this.elf32Label.TabIndex = 0;
            this.elf32Label.Text = "ELF32:";
            //
            // md5Label
            //
            this.md5Label.AutoSize = true;
            this.md5Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.md5Label.ForeColor = System.Drawing.Color.Black;
            this.md5Label.Location = new System.Drawing.Point(66, 170);
            this.md5Label.Margin = new System.Windows.Forms.Padding(5);
            this.md5Label.Name = "md5Label";
            this.md5Label.Size = new System.Drawing.Size(35, 15);
            this.md5Label.TabIndex = 0;
            this.md5Label.Text = "MD5:";
            //
            // sha1Label
            //
            this.sha1Label.AutoSize = true;
            this.sha1Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sha1Label.ForeColor = System.Drawing.Color.Black;
            this.sha1Label.Location = new System.Drawing.Point(52, 203);
            this.sha1Label.Margin = new System.Windows.Forms.Padding(5);
            this.sha1Label.Name = "sha1Label";
            this.sha1Label.Size = new System.Drawing.Size(49, 15);
            this.sha1Label.TabIndex = 0;
            this.sha1Label.Text = "SHA-1:";
            //
            // sha256Label
            //
            this.sha256Label.AutoSize = true;
            this.sha256Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sha256Label.ForeColor = System.Drawing.Color.Black;
            this.sha256Label.Location = new System.Drawing.Point(39, 236);
            this.sha256Label.Margin = new System.Windows.Forms.Padding(5);
            this.sha256Label.Name = "sha256Label";
            this.sha256Label.Size = new System.Drawing.Size(63, 15);
            this.sha256Label.TabIndex = 0;
            this.sha256Label.Text = "SHA-256:";
            //
            // sha512Label
            //
            this.sha512Label.AutoSize = true;
            this.sha512Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sha512Label.ForeColor = System.Drawing.Color.Black;
            this.sha512Label.Location = new System.Drawing.Point(39, 302);
            this.sha512Label.Margin = new System.Windows.Forms.Padding(5);
            this.sha512Label.Name = "sha512Label";
            this.sha512Label.Size = new System.Drawing.Size(63, 15);
            this.sha512Label.TabIndex = 0;
            this.sha512Label.Text = "SHA-512:";
            //
            // crc32TextBox
            //
            this.crc32TextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crc32TextBox.ForeColor = System.Drawing.Color.Black;
            this.crc32TextBox.Location = new System.Drawing.Point(112, 101);
            this.crc32TextBox.Margin = new System.Windows.Forms.Padding(5);
            this.crc32TextBox.Name = "crc32TextBox";
            this.crc32TextBox.ReadOnly = true;
            this.crc32TextBox.Size = new System.Drawing.Size(458, 23);
            this.crc32TextBox.TabIndex = 2;
            this.crc32TextBox.WordWrap = false;
            //
            // elf32TextBox
            //
            this.elf32TextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elf32TextBox.ForeColor = System.Drawing.Color.Black;
            this.elf32TextBox.Location = new System.Drawing.Point(112, 134);
            this.elf32TextBox.Margin = new System.Windows.Forms.Padding(5);
            this.elf32TextBox.Name = "elf32TextBox";
            this.elf32TextBox.ReadOnly = true;
            this.elf32TextBox.Size = new System.Drawing.Size(458, 23);
            this.elf32TextBox.TabIndex = 3;
            this.elf32TextBox.WordWrap = false;
            //
            // md5TextBox
            //
            this.md5TextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.md5TextBox.ForeColor = System.Drawing.Color.Black;
            this.md5TextBox.Location = new System.Drawing.Point(112, 167);
            this.md5TextBox.Margin = new System.Windows.Forms.Padding(5);
            this.md5TextBox.Name = "md5TextBox";
            this.md5TextBox.ReadOnly = true;
            this.md5TextBox.Size = new System.Drawing.Size(458, 23);
            this.md5TextBox.TabIndex = 4;
            this.md5TextBox.WordWrap = false;
            //
            // sha1TextBox
            //
            this.sha1TextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sha1TextBox.ForeColor = System.Drawing.Color.Black;
            this.sha1TextBox.Location = new System.Drawing.Point(112, 200);
            this.sha1TextBox.Margin = new System.Windows.Forms.Padding(5);
            this.sha1TextBox.Name = "sha1TextBox";
            this.sha1TextBox.ReadOnly = true;
            this.sha1TextBox.Size = new System.Drawing.Size(458, 23);
            this.sha1TextBox.TabIndex = 5;
            this.sha1TextBox.WordWrap = false;
            //
            // sha256TextBox
            //
            this.sha256TextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sha256TextBox.ForeColor = System.Drawing.Color.Black;
            this.sha256TextBox.Location = new System.Drawing.Point(112, 233);
            this.sha256TextBox.Margin = new System.Windows.Forms.Padding(5);
            this.sha256TextBox.Name = "sha256TextBox";
            this.sha256TextBox.ReadOnly = true;
            this.sha256TextBox.Size = new System.Drawing.Size(458, 23);
            this.sha256TextBox.TabIndex = 6;
            this.sha256TextBox.WordWrap = false;
            //
            // sha512TextBox
            //
            this.sha512TextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sha512TextBox.ForeColor = System.Drawing.Color.Black;
            this.sha512TextBox.Location = new System.Drawing.Point(112, 299);
            this.sha512TextBox.Margin = new System.Windows.Forms.Padding(5);
            this.sha512TextBox.Name = "sha512TextBox";
            this.sha512TextBox.ReadOnly = true;
            this.sha512TextBox.Size = new System.Drawing.Size(458, 23);
            this.sha512TextBox.TabIndex = 7;
            this.sha512TextBox.WordWrap = false;
            //
            // calculateHashesButton
            //
            this.calculateHashesButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.calculateHashesButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculateHashesButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.calculateHashesButton.Location = new System.Drawing.Point(187, 39);
            this.calculateHashesButton.Margin = new System.Windows.Forms.Padding(5);
            this.calculateHashesButton.Name = "calculateHashesButton";
            this.calculateHashesButton.Size = new System.Drawing.Size(100, 23);
            this.calculateHashesButton.TabIndex = 1;
            this.calculateHashesButton.Text = "Calculate ▼";
            this.calculateHashesButton.UseVisualStyleBackColor = false;
            this.calculateHashesButton.Click += new System.EventHandler(this.CalculateHashesAsyncButton_Click);
            //
            // crc32CheckBox
            //
            this.crc32CheckBox.AutoSize = true;
            this.crc32CheckBox.Checked = true;
            this.crc32CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.crc32CheckBox.Location = new System.Drawing.Point(14, 105);
            this.crc32CheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.crc32CheckBox.Name = "crc32CheckBox";
            this.crc32CheckBox.Size = new System.Drawing.Size(15, 14);
            this.crc32CheckBox.TabIndex = 0;
            this.crc32CheckBox.TabStop = false;
            this.crc32CheckBox.UseVisualStyleBackColor = true;
            this.crc32CheckBox.Click += new System.EventHandler(this.SelectedCheckBox_Click);
            //
            // elf32CheckBox
            //
            this.elf32CheckBox.AutoSize = true;
            this.elf32CheckBox.Checked = true;
            this.elf32CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.elf32CheckBox.Location = new System.Drawing.Point(14, 138);
            this.elf32CheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.elf32CheckBox.Name = "elf32CheckBox";
            this.elf32CheckBox.Size = new System.Drawing.Size(15, 14);
            this.elf32CheckBox.TabIndex = 0;
            this.elf32CheckBox.TabStop = false;
            this.elf32CheckBox.UseVisualStyleBackColor = true;
            this.elf32CheckBox.Click += new System.EventHandler(this.SelectedCheckBox_Click);
            //
            // md5CheckBox
            //
            this.md5CheckBox.AutoSize = true;
            this.md5CheckBox.Checked = true;
            this.md5CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.md5CheckBox.Location = new System.Drawing.Point(14, 171);
            this.md5CheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.md5CheckBox.Name = "md5CheckBox";
            this.md5CheckBox.Size = new System.Drawing.Size(15, 14);
            this.md5CheckBox.TabIndex = 0;
            this.md5CheckBox.TabStop = false;
            this.md5CheckBox.UseVisualStyleBackColor = true;
            this.md5CheckBox.Click += new System.EventHandler(this.SelectedCheckBox_Click);
            //
            // sha1CheckBox
            //
            this.sha1CheckBox.AutoSize = true;
            this.sha1CheckBox.Checked = true;
            this.sha1CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sha1CheckBox.Location = new System.Drawing.Point(14, 204);
            this.sha1CheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.sha1CheckBox.Name = "sha1CheckBox";
            this.sha1CheckBox.Size = new System.Drawing.Size(15, 14);
            this.sha1CheckBox.TabIndex = 0;
            this.sha1CheckBox.TabStop = false;
            this.sha1CheckBox.UseVisualStyleBackColor = true;
            this.sha1CheckBox.Click += new System.EventHandler(this.SelectedCheckBox_Click);
            //
            // sha256CheckBox
            //
            this.sha256CheckBox.AutoSize = true;
            this.sha256CheckBox.Checked = true;
            this.sha256CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sha256CheckBox.Location = new System.Drawing.Point(14, 237);
            this.sha256CheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.sha256CheckBox.Name = "sha256CheckBox";
            this.sha256CheckBox.Size = new System.Drawing.Size(15, 14);
            this.sha256CheckBox.TabIndex = 0;
            this.sha256CheckBox.TabStop = false;
            this.sha256CheckBox.UseVisualStyleBackColor = true;
            this.sha256CheckBox.Click += new System.EventHandler(this.SelectedCheckBox_Click);
            //
            // sha512CheckBox
            //
            this.sha512CheckBox.AutoSize = true;
            this.sha512CheckBox.Checked = true;
            this.sha512CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sha512CheckBox.Location = new System.Drawing.Point(14, 303);
            this.sha512CheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.sha512CheckBox.Name = "sha512CheckBox";
            this.sha512CheckBox.Size = new System.Drawing.Size(15, 14);
            this.sha512CheckBox.TabIndex = 0;
            this.sha512CheckBox.TabStop = false;
            this.sha512CheckBox.UseVisualStyleBackColor = true;
            this.sha512CheckBox.Click += new System.EventHandler(this.SelectedCheckBox_Click);
            //
            // selectAllCheckBox
            //
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllCheckBox.Location = new System.Drawing.Point(14, 74);
            this.selectAllCheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(47, 19);
            this.selectAllCheckBox.TabIndex = 0;
            this.selectAllCheckBox.TabStop = false;
            this.selectAllCheckBox.Text = "All";
            this.selectAllCheckBox.ThreeState = true;
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.Click += new System.EventHandler(this.SelectAllCheckBox_Click);
            //
            // clearAllButton
            //
            this.clearAllButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clearAllButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearAllButton.ForeColor = System.Drawing.Color.DarkRed;
            this.clearAllButton.Location = new System.Drawing.Point(470, 39);
            this.clearAllButton.Margin = new System.Windows.Forms.Padding(5);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(100, 23);
            this.clearAllButton.TabIndex = 9;
            this.clearAllButton.Text = "Clear All";
            this.clearAllButton.UseVisualStyleBackColor = false;
            this.clearAllButton.Click += new System.EventHandler(this.ClearAllButton_Click);
            //
            // resultsButton
            //
            this.resultsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.resultsButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsButton.ForeColor = System.Drawing.Color.Black;
            this.resultsButton.Location = new System.Drawing.Point(360, 39);
            this.resultsButton.Margin = new System.Windows.Forms.Padding(5);
            this.resultsButton.Name = "resultsButton";
            this.resultsButton.Size = new System.Drawing.Size(100, 23);
            this.resultsButton.TabIndex = 8;
            this.resultsButton.Text = "Results";
            this.resultsButton.UseVisualStyleBackColor = false;
            this.resultsButton.Click += new System.EventHandler(this.ResultsButton_Click);
            //
            // calculateFileHashFormToolTip
            //
            this.calculateFileHashFormToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            //
            // executionStatusLabel
            //
            this.executionStatusLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executionStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.executionStatusLabel.Location = new System.Drawing.Point(112, 72);
            this.executionStatusLabel.Margin = new System.Windows.Forms.Padding(5);
            this.executionStatusLabel.Name = "executionStatusLabel";
            this.executionStatusLabel.Size = new System.Drawing.Size(240, 19);
            this.executionStatusLabel.TabIndex = 0;
            //
            // progressBar
            //
            this.progressBar.Location = new System.Drawing.Point(360, 70);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(210, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            //
            // sha384TextBox
            //
            this.sha384TextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sha384TextBox.ForeColor = System.Drawing.Color.Black;
            this.sha384TextBox.Location = new System.Drawing.Point(112, 266);
            this.sha384TextBox.Margin = new System.Windows.Forms.Padding(5);
            this.sha384TextBox.Name = "sha384TextBox";
            this.sha384TextBox.ReadOnly = true;
            this.sha384TextBox.Size = new System.Drawing.Size(458, 23);
            this.sha384TextBox.TabIndex = 10;
            this.sha384TextBox.WordWrap = false;
            //
            // sha384Label
            //
            this.sha384Label.AutoSize = true;
            this.sha384Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sha384Label.ForeColor = System.Drawing.Color.Black;
            this.sha384Label.Location = new System.Drawing.Point(39, 269);
            this.sha384Label.Margin = new System.Windows.Forms.Padding(5);
            this.sha384Label.Name = "sha384Label";
            this.sha384Label.Size = new System.Drawing.Size(63, 15);
            this.sha384Label.TabIndex = 11;
            this.sha384Label.Text = "SHA-384:";
            //
            // sha384CheckBox
            //
            this.sha384CheckBox.AutoSize = true;
            this.sha384CheckBox.Checked = true;
            this.sha384CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sha384CheckBox.Location = new System.Drawing.Point(14, 270);
            this.sha384CheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.sha384CheckBox.Name = "sha384CheckBox";
            this.sha384CheckBox.Size = new System.Drawing.Size(15, 14);
            this.sha384CheckBox.TabIndex = 12;
            this.sha384CheckBox.TabStop = false;
            this.sha384CheckBox.UseVisualStyleBackColor = true;
            //
            // FileHashCalculatorForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 339);
            this.Controls.Add(this.sha384CheckBox);
            this.Controls.Add(this.sha384Label);
            this.Controls.Add(this.sha384TextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.executionStatusLabel);
            this.Controls.Add(this.resultsButton);
            this.Controls.Add(this.clearAllButton);
            this.Controls.Add(this.selectAllCheckBox);
            this.Controls.Add(this.sha512CheckBox);
            this.Controls.Add(this.sha256CheckBox);
            this.Controls.Add(this.sha1CheckBox);
            this.Controls.Add(this.md5CheckBox);
            this.Controls.Add(this.elf32CheckBox);
            this.Controls.Add(this.crc32CheckBox);
            this.Controls.Add(this.calculateHashesButton);
            this.Controls.Add(this.sha512TextBox);
            this.Controls.Add(this.sha256TextBox);
            this.Controls.Add(this.sha1TextBox);
            this.Controls.Add(this.md5TextBox);
            this.Controls.Add(this.elf32TextBox);
            this.Controls.Add(this.crc32TextBox);
            this.Controls.Add(this.sha512Label);
            this.Controls.Add(this.sha256Label);
            this.Controls.Add(this.sha1Label);
            this.Controls.Add(this.md5Label);
            this.Controls.Add(this.elf32Label);
            this.Controls.Add(this.crc32Label);
            this.Controls.Add(this.openSingleFileNameLabel);
            this.Controls.Add(this.openSingleFileLabel);
            this.Controls.Add(this.openSingleFileButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileHashCalculatorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Hash Calculator";
            this.Load += new System.EventHandler(this.CalculateFileHashForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CalculateFileHashForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openSingleFileDialog;
        private System.Windows.Forms.Button openSingleFileButton;
        private System.Windows.Forms.Label openSingleFileLabel;
        private System.Windows.Forms.Label openSingleFileNameLabel;
        private System.Windows.Forms.Label crc32Label;
        private System.Windows.Forms.Label elf32Label;
        private System.Windows.Forms.Label md5Label;
        private System.Windows.Forms.Label sha1Label;
        private System.Windows.Forms.Label sha256Label;
        private System.Windows.Forms.Label sha512Label;
        private System.Windows.Forms.TextBox crc32TextBox;
        private System.Windows.Forms.TextBox elf32TextBox;
        private System.Windows.Forms.TextBox md5TextBox;
        private System.Windows.Forms.TextBox sha1TextBox;
        private System.Windows.Forms.TextBox sha256TextBox;
        private System.Windows.Forms.TextBox sha512TextBox;
        private System.Windows.Forms.Button calculateHashesButton;
        private System.Windows.Forms.CheckBox crc32CheckBox;
        private System.Windows.Forms.CheckBox elf32CheckBox;
        private System.Windows.Forms.CheckBox md5CheckBox;
        private System.Windows.Forms.CheckBox sha1CheckBox;
        private System.Windows.Forms.CheckBox sha256CheckBox;
        private System.Windows.Forms.CheckBox sha512CheckBox;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.Button resultsButton;
        private System.Windows.Forms.ToolTip calculateFileHashFormToolTip;
        private System.Windows.Forms.Label executionStatusLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox sha384TextBox;
        private System.Windows.Forms.Label sha384Label;
        private System.Windows.Forms.CheckBox sha384CheckBox;
    }
}
