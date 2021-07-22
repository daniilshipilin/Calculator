namespace Calculator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.resultOutputLabel = new System.Windows.Forms.Label();
            this.sevenButton = new System.Windows.Forms.Button();
            this.eightButton = new System.Windows.Forms.Button();
            this.nineButton = new System.Windows.Forms.Button();
            this.fourButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.sixButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.twoButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.zeroButton = new System.Windows.Forms.Button();
            this.decimalButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.equalsButton = new System.Windows.Forms.Button();
            this.clearEntryButton = new System.Windows.Forms.Button();
            this.bracketCloseButton = new System.Windows.Forms.Button();
            this.bracketOpenButton = new System.Windows.Forms.Button();
            this.exponentiationButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numberBaseConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringBase64ConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileHashCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexToAsciiConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomNumberGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomPasswordGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currencyConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.asciiTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqrtButton = new System.Windows.Forms.Button();
            this.moduloButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.backspaceButton = new System.Windows.Forms.Button();
            this.previousCommandLabel = new System.Windows.Forms.Label();
            this.memoryLabel = new System.Windows.Forms.Label();
            this.memoryClearButton = new System.Windows.Forms.Button();
            this.memoryStoreButton = new System.Windows.Forms.Button();
            this.memoryRecallButton = new System.Windows.Forms.Button();
            this.allClearButton = new System.Windows.Forms.Button();
            this.memoryOutputLabel = new System.Windows.Forms.Label();
            this.mainFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.dateTimeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimeUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.funnyTimer = new System.Windows.Forms.Timer(this.components);
            this.dummyLabel = new System.Windows.Forms.Label();
            this.fuelcostCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultOutputLabel
            // 
            this.resultOutputLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.resultOutputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultOutputLabel.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resultOutputLabel.ForeColor = System.Drawing.Color.Black;
            this.resultOutputLabel.Location = new System.Drawing.Point(14, 61);
            this.resultOutputLabel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.resultOutputLabel.Name = "resultOutputLabel";
            this.resultOutputLabel.Size = new System.Drawing.Size(450, 63);
            this.resultOutputLabel.TabIndex = 0;
            this.resultOutputLabel.Text = "0";
            this.resultOutputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sevenButton
            // 
            this.sevenButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sevenButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sevenButton.Location = new System.Drawing.Point(14, 132);
            this.sevenButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(58, 58);
            this.sevenButton.TabIndex = 0;
            this.sevenButton.TabStop = false;
            this.sevenButton.Text = "7";
            this.sevenButton.UseVisualStyleBackColor = false;
            this.sevenButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // eightButton
            // 
            this.eightButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.eightButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.eightButton.Location = new System.Drawing.Point(79, 132);
            this.eightButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.eightButton.Name = "eightButton";
            this.eightButton.Size = new System.Drawing.Size(58, 58);
            this.eightButton.TabIndex = 0;
            this.eightButton.TabStop = false;
            this.eightButton.Text = "8";
            this.eightButton.UseVisualStyleBackColor = false;
            this.eightButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // nineButton
            // 
            this.nineButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nineButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nineButton.Location = new System.Drawing.Point(145, 132);
            this.nineButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(58, 58);
            this.nineButton.TabIndex = 0;
            this.nineButton.TabStop = false;
            this.nineButton.Text = "9";
            this.nineButton.UseVisualStyleBackColor = false;
            this.nineButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // fourButton
            // 
            this.fourButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fourButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fourButton.Location = new System.Drawing.Point(14, 196);
            this.fourButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(58, 58);
            this.fourButton.TabIndex = 0;
            this.fourButton.TabStop = false;
            this.fourButton.Text = "4";
            this.fourButton.UseVisualStyleBackColor = false;
            this.fourButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // fiveButton
            // 
            this.fiveButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fiveButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fiveButton.Location = new System.Drawing.Point(79, 196);
            this.fiveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(58, 58);
            this.fiveButton.TabIndex = 0;
            this.fiveButton.TabStop = false;
            this.fiveButton.Text = "5";
            this.fiveButton.UseVisualStyleBackColor = false;
            this.fiveButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // sixButton
            // 
            this.sixButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sixButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sixButton.Location = new System.Drawing.Point(145, 196);
            this.sixButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(58, 58);
            this.sixButton.TabIndex = 0;
            this.sixButton.TabStop = false;
            this.sixButton.Text = "6";
            this.sixButton.UseVisualStyleBackColor = false;
            this.sixButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // oneButton
            // 
            this.oneButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.oneButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.oneButton.Location = new System.Drawing.Point(14, 261);
            this.oneButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(58, 58);
            this.oneButton.TabIndex = 0;
            this.oneButton.TabStop = false;
            this.oneButton.Text = "1";
            this.oneButton.UseVisualStyleBackColor = false;
            this.oneButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // twoButton
            // 
            this.twoButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.twoButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.twoButton.Location = new System.Drawing.Point(79, 261);
            this.twoButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(58, 58);
            this.twoButton.TabIndex = 0;
            this.twoButton.TabStop = false;
            this.twoButton.Text = "2";
            this.twoButton.UseVisualStyleBackColor = false;
            this.twoButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // threeButton
            // 
            this.threeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.threeButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.threeButton.Location = new System.Drawing.Point(145, 261);
            this.threeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(58, 58);
            this.threeButton.TabIndex = 0;
            this.threeButton.TabStop = false;
            this.threeButton.Text = "3";
            this.threeButton.UseVisualStyleBackColor = false;
            this.threeButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // zeroButton
            // 
            this.zeroButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zeroButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.zeroButton.Location = new System.Drawing.Point(14, 325);
            this.zeroButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(124, 58);
            this.zeroButton.TabIndex = 0;
            this.zeroButton.TabStop = false;
            this.zeroButton.Text = "0";
            this.zeroButton.UseVisualStyleBackColor = false;
            this.zeroButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // decimalButton
            // 
            this.decimalButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.decimalButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.decimalButton.Location = new System.Drawing.Point(145, 325);
            this.decimalButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.decimalButton.Name = "decimalButton";
            this.decimalButton.Size = new System.Drawing.Size(58, 58);
            this.decimalButton.TabIndex = 0;
            this.decimalButton.TabStop = false;
            this.decimalButton.Text = ".";
            this.decimalButton.UseVisualStyleBackColor = false;
            this.decimalButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // divideButton
            // 
            this.divideButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.divideButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.divideButton.Location = new System.Drawing.Point(210, 325);
            this.divideButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(58, 58);
            this.divideButton.TabIndex = 0;
            this.divideButton.TabStop = false;
            this.divideButton.Text = "/";
            this.divideButton.UseVisualStyleBackColor = false;
            this.divideButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // multiplyButton
            // 
            this.multiplyButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.multiplyButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.multiplyButton.Location = new System.Drawing.Point(210, 261);
            this.multiplyButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(58, 58);
            this.multiplyButton.TabIndex = 0;
            this.multiplyButton.TabStop = false;
            this.multiplyButton.Text = "*";
            this.multiplyButton.UseVisualStyleBackColor = false;
            this.multiplyButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // minusButton
            // 
            this.minusButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.minusButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minusButton.Location = new System.Drawing.Point(210, 196);
            this.minusButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(58, 58);
            this.minusButton.TabIndex = 0;
            this.minusButton.TabStop = false;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = false;
            this.minusButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // plusButton
            // 
            this.plusButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.plusButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusButton.Location = new System.Drawing.Point(210, 132);
            this.plusButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(58, 58);
            this.plusButton.TabIndex = 0;
            this.plusButton.TabStop = false;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = false;
            this.plusButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // equalsButton
            // 
            this.equalsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.equalsButton.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.equalsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.equalsButton.Location = new System.Drawing.Point(14, 390);
            this.equalsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.equalsButton.Name = "equalsButton";
            this.equalsButton.Size = new System.Drawing.Size(450, 58);
            this.equalsButton.TabIndex = 0;
            this.equalsButton.TabStop = false;
            this.equalsButton.Text = "=";
            this.equalsButton.UseVisualStyleBackColor = false;
            this.equalsButton.Click += new System.EventHandler(this.EqualsButton_Click);
            // 
            // clearEntryButton
            // 
            this.clearEntryButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clearEntryButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.clearEntryButton.ForeColor = System.Drawing.Color.DarkRed;
            this.clearEntryButton.Location = new System.Drawing.Point(341, 132);
            this.clearEntryButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clearEntryButton.Name = "clearEntryButton";
            this.clearEntryButton.Size = new System.Drawing.Size(58, 58);
            this.clearEntryButton.TabIndex = 0;
            this.clearEntryButton.TabStop = false;
            this.clearEntryButton.Text = "CE";
            this.clearEntryButton.UseVisualStyleBackColor = false;
            this.clearEntryButton.Click += new System.EventHandler(this.ClearEntryButton_Click);
            // 
            // bracketCloseButton
            // 
            this.bracketCloseButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bracketCloseButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bracketCloseButton.Location = new System.Drawing.Point(341, 325);
            this.bracketCloseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bracketCloseButton.Name = "bracketCloseButton";
            this.bracketCloseButton.Size = new System.Drawing.Size(58, 58);
            this.bracketCloseButton.TabIndex = 0;
            this.bracketCloseButton.TabStop = false;
            this.bracketCloseButton.Text = ")";
            this.bracketCloseButton.UseVisualStyleBackColor = false;
            this.bracketCloseButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // bracketOpenButton
            // 
            this.bracketOpenButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bracketOpenButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bracketOpenButton.Location = new System.Drawing.Point(275, 325);
            this.bracketOpenButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bracketOpenButton.Name = "bracketOpenButton";
            this.bracketOpenButton.Size = new System.Drawing.Size(58, 58);
            this.bracketOpenButton.TabIndex = 0;
            this.bracketOpenButton.TabStop = false;
            this.bracketOpenButton.Text = "(";
            this.bracketOpenButton.UseVisualStyleBackColor = false;
            this.bracketOpenButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // exponentiationButton
            // 
            this.exponentiationButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.exponentiationButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exponentiationButton.Location = new System.Drawing.Point(275, 196);
            this.exponentiationButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.exponentiationButton.Name = "exponentiationButton";
            this.exponentiationButton.Size = new System.Drawing.Size(58, 58);
            this.exponentiationButton.TabIndex = 0;
            this.exponentiationButton.TabStop = false;
            this.exponentiationButton.Text = "^";
            this.exponentiationButton.UseVisualStyleBackColor = false;
            this.exponentiationButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(3);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.updatesMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.menuStrip.Size = new System.Drawing.Size(478, 25);
            this.menuStrip.TabIndex = 0;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topmostToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(75, 19);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // topmostToolStripMenuItem
            // 
            this.topmostToolStripMenuItem.CheckOnClick = true;
            this.topmostToolStripMenuItem.Name = "topmostToolStripMenuItem";
            this.topmostToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.topmostToolStripMenuItem.Text = "&Topmost";
            this.topmostToolStripMenuItem.CheckedChanged += new System.EventHandler(this.TopmostToolStripMenuItem_CheckedChanged);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numberBaseConverterToolStripMenuItem,
            this.stringBase64ConverterToolStripMenuItem,
            this.fileHashCalculatorToolStripMenuItem,
            this.hexToAsciiConverterToolStripMenuItem,
            this.randomNumberGeneratorToolStripMenuItem,
            this.randomPasswordGeneratorToolStripMenuItem,
            this.currencyConverterToolStripMenuItem,
            this.fuelcostCalculatorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(54, 19);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // numberBaseConverterToolStripMenuItem
            // 
            this.numberBaseConverterToolStripMenuItem.Name = "numberBaseConverterToolStripMenuItem";
            this.numberBaseConverterToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1);
            this.numberBaseConverterToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.numberBaseConverterToolStripMenuItem.Text = "&Number Base Converter";
            this.numberBaseConverterToolStripMenuItem.Click += new System.EventHandler(this.NumberBaseConverterToolStripMenuItem_Click);
            // 
            // stringBase64ConverterToolStripMenuItem
            // 
            this.stringBase64ConverterToolStripMenuItem.Name = "stringBase64ConverterToolStripMenuItem";
            this.stringBase64ConverterToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1);
            this.stringBase64ConverterToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.stringBase64ConverterToolStripMenuItem.Text = "&Base64 String Converter";
            this.stringBase64ConverterToolStripMenuItem.Click += new System.EventHandler(this.Base64StringConverterToolStripMenuItem_Click);
            // 
            // fileHashCalculatorToolStripMenuItem
            // 
            this.fileHashCalculatorToolStripMenuItem.Name = "fileHashCalculatorToolStripMenuItem";
            this.fileHashCalculatorToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1);
            this.fileHashCalculatorToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.fileHashCalculatorToolStripMenuItem.Text = "File &Hash Calculator";
            this.fileHashCalculatorToolStripMenuItem.Click += new System.EventHandler(this.FileHashCalculatorToolStripMenuItem_Click);
            // 
            // hexToAsciiConverterToolStripMenuItem
            // 
            this.hexToAsciiConverterToolStripMenuItem.Name = "hexToAsciiConverterToolStripMenuItem";
            this.hexToAsciiConverterToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1);
            this.hexToAsciiConverterToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.hexToAsciiConverterToolStripMenuItem.Text = "Hex To &Ascii Converter";
            this.hexToAsciiConverterToolStripMenuItem.Click += new System.EventHandler(this.HexToAsciiConverterToolStripMenuItem_Click);
            // 
            // randomNumberGeneratorToolStripMenuItem
            // 
            this.randomNumberGeneratorToolStripMenuItem.Name = "randomNumberGeneratorToolStripMenuItem";
            this.randomNumberGeneratorToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1);
            this.randomNumberGeneratorToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.randomNumberGeneratorToolStripMenuItem.Text = "Random Number &Generator";
            this.randomNumberGeneratorToolStripMenuItem.Click += new System.EventHandler(this.RandomNumberGeneratorToolStripMenuItem_Click);
            // 
            // randomPasswordGeneratorToolStripMenuItem
            // 
            this.randomPasswordGeneratorToolStripMenuItem.Name = "randomPasswordGeneratorToolStripMenuItem";
            this.randomPasswordGeneratorToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.randomPasswordGeneratorToolStripMenuItem.Text = "Random &Password Generator";
            this.randomPasswordGeneratorToolStripMenuItem.Click += new System.EventHandler(this.RandomPasswordGeneratorToolStripMenuItem_Click);
            // 
            // currencyConverterToolStripMenuItem
            // 
            this.currencyConverterToolStripMenuItem.Name = "currencyConverterToolStripMenuItem";
            this.currencyConverterToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.currencyConverterToolStripMenuItem.Text = "Cu&rrency Converter";
            this.currencyConverterToolStripMenuItem.Click += new System.EventHandler(this.CurrencyConverterToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.keyboardShortcutsToolStripMenuItem,
            this.helpToolStripSeparator,
            this.asciiTableToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 19);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1);
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // keyboardShortcutsToolStripMenuItem
            // 
            this.keyboardShortcutsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.keyboardShortcutsToolStripMenuItem.Name = "keyboardShortcutsToolStripMenuItem";
            this.keyboardShortcutsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1);
            this.keyboardShortcutsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.keyboardShortcutsToolStripMenuItem.Text = "Keyboard &Shortcuts";
            this.keyboardShortcutsToolStripMenuItem.Click += new System.EventHandler(this.KeyboardShortcutsToolStripMenuItem_Click);
            // 
            // helpToolStripSeparator
            // 
            this.helpToolStripSeparator.Name = "helpToolStripSeparator";
            this.helpToolStripSeparator.Size = new System.Drawing.Size(197, 6);
            // 
            // asciiTableToolStripMenuItem
            // 
            this.asciiTableToolStripMenuItem.Name = "asciiTableToolStripMenuItem";
            this.asciiTableToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1);
            this.asciiTableToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.asciiTableToolStripMenuItem.Text = "ASCII &Table";
            this.asciiTableToolStripMenuItem.Click += new System.EventHandler(this.AsciiTableToolStripMenuItem_Click);
            // 
            // updatesMenuItem
            // 
            this.updatesMenuItem.Name = "updatesMenuItem";
            this.updatesMenuItem.Size = new System.Drawing.Size(68, 19);
            this.updatesMenuItem.Text = "&Updates";
            this.updatesMenuItem.Click += new System.EventHandler(this.UpdatesMenuItem_Click);
            // 
            // sqrtButton
            // 
            this.sqrtButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sqrtButton.Location = new System.Drawing.Point(341, 196);
            this.sqrtButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sqrtButton.Name = "sqrtButton";
            this.sqrtButton.Size = new System.Drawing.Size(58, 58);
            this.sqrtButton.TabIndex = 0;
            this.sqrtButton.TabStop = false;
            this.sqrtButton.Text = "√";
            this.sqrtButton.UseVisualStyleBackColor = false;
            this.sqrtButton.Click += new System.EventHandler(this.CalculateSqrt);
            // 
            // moduloButton
            // 
            this.moduloButton.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.moduloButton.Location = new System.Drawing.Point(275, 261);
            this.moduloButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.moduloButton.Name = "moduloButton";
            this.moduloButton.Size = new System.Drawing.Size(58, 58);
            this.moduloButton.TabIndex = 0;
            this.moduloButton.TabStop = false;
            this.moduloButton.Text = "Mod";
            this.moduloButton.UseVisualStyleBackColor = false;
            this.moduloButton.Click += new System.EventHandler(this.AnalyzeButtonPressed);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(341, 261);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 58);
            this.button3.TabIndex = 0;
            this.button3.TabStop = false;
            this.button3.Text = "1/x";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.CalculateOneDividedByX);
            // 
            // backspaceButton
            // 
            this.backspaceButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backspaceButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.backspaceButton.Location = new System.Drawing.Point(275, 132);
            this.backspaceButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.backspaceButton.Name = "backspaceButton";
            this.backspaceButton.Size = new System.Drawing.Size(58, 58);
            this.backspaceButton.TabIndex = 0;
            this.backspaceButton.TabStop = false;
            this.backspaceButton.Text = "<<";
            this.backspaceButton.UseVisualStyleBackColor = false;
            this.backspaceButton.Click += new System.EventHandler(this.BackspaceButton_Click);
            // 
            // previousCommandLabel
            // 
            this.previousCommandLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.previousCommandLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.previousCommandLabel.Location = new System.Drawing.Point(260, 29);
            this.previousCommandLabel.Margin = new System.Windows.Forms.Padding(0);
            this.previousCommandLabel.Name = "previousCommandLabel";
            this.previousCommandLabel.Size = new System.Drawing.Size(204, 29);
            this.previousCommandLabel.TabIndex = 0;
            this.previousCommandLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // memoryLabel
            // 
            this.memoryLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.memoryLabel.ForeColor = System.Drawing.Color.Black;
            this.memoryLabel.Location = new System.Drawing.Point(14, 29);
            this.memoryLabel.Margin = new System.Windows.Forms.Padding(0);
            this.memoryLabel.Name = "memoryLabel";
            this.memoryLabel.Size = new System.Drawing.Size(42, 29);
            this.memoryLabel.TabIndex = 0;
            this.memoryLabel.Text = "MEM:";
            this.memoryLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // memoryClearButton
            // 
            this.memoryClearButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.memoryClearButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.memoryClearButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.memoryClearButton.Location = new System.Drawing.Point(406, 196);
            this.memoryClearButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.memoryClearButton.Name = "memoryClearButton";
            this.memoryClearButton.Size = new System.Drawing.Size(58, 58);
            this.memoryClearButton.TabIndex = 0;
            this.memoryClearButton.TabStop = false;
            this.memoryClearButton.Text = "MC";
            this.memoryClearButton.UseVisualStyleBackColor = false;
            this.memoryClearButton.Click += new System.EventHandler(this.MemoryClearButton_Click);
            // 
            // memoryStoreButton
            // 
            this.memoryStoreButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.memoryStoreButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.memoryStoreButton.Location = new System.Drawing.Point(406, 261);
            this.memoryStoreButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.memoryStoreButton.Name = "memoryStoreButton";
            this.memoryStoreButton.Size = new System.Drawing.Size(58, 58);
            this.memoryStoreButton.TabIndex = 0;
            this.memoryStoreButton.TabStop = false;
            this.memoryStoreButton.Text = "MS";
            this.memoryStoreButton.UseVisualStyleBackColor = false;
            this.memoryStoreButton.Click += new System.EventHandler(this.MemoryStoreButton_Click);
            // 
            // memoryRecallButton
            // 
            this.memoryRecallButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.memoryRecallButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.memoryRecallButton.Location = new System.Drawing.Point(406, 325);
            this.memoryRecallButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.memoryRecallButton.Name = "memoryRecallButton";
            this.memoryRecallButton.Size = new System.Drawing.Size(58, 58);
            this.memoryRecallButton.TabIndex = 0;
            this.memoryRecallButton.TabStop = false;
            this.memoryRecallButton.Text = "MR";
            this.memoryRecallButton.UseVisualStyleBackColor = false;
            this.memoryRecallButton.Click += new System.EventHandler(this.MemoryRecallButton_Click);
            // 
            // allClearButton
            // 
            this.allClearButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.allClearButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.allClearButton.ForeColor = System.Drawing.Color.DarkRed;
            this.allClearButton.Location = new System.Drawing.Point(406, 132);
            this.allClearButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.allClearButton.Name = "allClearButton";
            this.allClearButton.Size = new System.Drawing.Size(58, 58);
            this.allClearButton.TabIndex = 0;
            this.allClearButton.TabStop = false;
            this.allClearButton.Text = "AC";
            this.allClearButton.UseVisualStyleBackColor = false;
            this.allClearButton.Click += new System.EventHandler(this.AllClearButton_Click);
            // 
            // memoryOutputLabel
            // 
            this.memoryOutputLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.memoryOutputLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.memoryOutputLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.memoryOutputLabel.Location = new System.Drawing.Point(56, 29);
            this.memoryOutputLabel.Margin = new System.Windows.Forms.Padding(0);
            this.memoryOutputLabel.Name = "memoryOutputLabel";
            this.memoryOutputLabel.Size = new System.Drawing.Size(204, 29);
            this.memoryOutputLabel.TabIndex = 0;
            this.memoryOutputLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // mainFormToolTip
            // 
            this.mainFormToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.Gainsboro;
            this.statusStrip.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusStrip.GripMargin = new System.Windows.Forms.Padding(1);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateTimeToolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 458);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(478, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            // 
            // dateTimeToolStripStatusLabel
            // 
            this.dateTimeToolStripStatusLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimeToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.dateTimeToolStripStatusLabel.Name = "dateTimeToolStripStatusLabel";
            this.dateTimeToolStripStatusLabel.Size = new System.Drawing.Size(0, 0);
            this.dateTimeToolStripStatusLabel.Spring = true;
            // 
            // dummyLabel
            // 
            this.dummyLabel.Location = new System.Drawing.Point(0, 0);
            this.dummyLabel.Margin = new System.Windows.Forms.Padding(0);
            this.dummyLabel.Name = "dummyLabel";
            this.dummyLabel.Size = new System.Drawing.Size(0, 0);
            this.dummyLabel.TabIndex = 0;
            // 
            // fuelcostCalculatorToolStripMenuItem
            // 
            this.fuelcostCalculatorToolStripMenuItem.Name = "fuelcostCalculatorToolStripMenuItem";
            this.fuelcostCalculatorToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.fuelcostCalculatorToolStripMenuItem.Text = "&Fuelcost Calculator";
            this.fuelcostCalculatorToolStripMenuItem.Click += new System.EventHandler(this.FuelcostCalculatorToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(478, 480);
            this.Controls.Add(this.dummyLabel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.memoryOutputLabel);
            this.Controls.Add(this.allClearButton);
            this.Controls.Add(this.memoryRecallButton);
            this.Controls.Add(this.memoryStoreButton);
            this.Controls.Add(this.memoryClearButton);
            this.Controls.Add(this.memoryLabel);
            this.Controls.Add(this.previousCommandLabel);
            this.Controls.Add(this.backspaceButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.moduloButton);
            this.Controls.Add(this.sqrtButton);
            this.Controls.Add(this.exponentiationButton);
            this.Controls.Add(this.bracketOpenButton);
            this.Controls.Add(this.bracketCloseButton);
            this.Controls.Add(this.clearEntryButton);
            this.Controls.Add(this.equalsButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.multiplyButton);
            this.Controls.Add(this.divideButton);
            this.Controls.Add(this.decimalButton);
            this.Controls.Add(this.zeroButton);
            this.Controls.Add(this.threeButton);
            this.Controls.Add(this.twoButton);
            this.Controls.Add(this.oneButton);
            this.Controls.Add(this.sixButton);
            this.Controls.Add(this.fiveButton);
            this.Controls.Add(this.fourButton);
            this.Controls.Add(this.nineButton);
            this.Controls.Add(this.eightButton);
            this.Controls.Add(this.sevenButton);
            this.Controls.Add(this.resultOutputLabel);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.CalculatorForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CalculatorForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CalculatorForm_KeyPress);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resultOutputLabel;
        private System.Windows.Forms.Button sevenButton;
        private System.Windows.Forms.Button eightButton;
        private System.Windows.Forms.Button nineButton;
        private System.Windows.Forms.Button fourButton;
        private System.Windows.Forms.Button fiveButton;
        private System.Windows.Forms.Button sixButton;
        private System.Windows.Forms.Button oneButton;
        private System.Windows.Forms.Button twoButton;
        private System.Windows.Forms.Button threeButton;
        private System.Windows.Forms.Button zeroButton;
        private System.Windows.Forms.Button decimalButton;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button equalsButton;
        private System.Windows.Forms.Button clearEntryButton;
        private System.Windows.Forms.Button bracketCloseButton;
        private System.Windows.Forms.Button bracketOpenButton;
        private System.Windows.Forms.Button exponentiationButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button sqrtButton;
        private System.Windows.Forms.Button moduloButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button backspaceButton;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label previousCommandLabel;
        private System.Windows.Forms.Label memoryLabel;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.Button memoryClearButton;
        private System.Windows.Forms.Button memoryStoreButton;
        private System.Windows.Forms.Button memoryRecallButton;
        private System.Windows.Forms.Button allClearButton;
        private System.Windows.Forms.Label memoryOutputLabel;
        private System.Windows.Forms.ToolTip mainFormToolTip;
        private System.Windows.Forms.ToolStripMenuItem numberBaseConverterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stringBase64ConverterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileHashCalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexToAsciiConverterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyboardShortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomNumberGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asciiTableToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem topmostToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator helpToolStripSeparator;
        private System.Windows.Forms.Timer dateTimeUpdateTimer;
        private System.Windows.Forms.Timer funnyTimer;
        private System.Windows.Forms.Label dummyLabel;
        private System.Windows.Forms.ToolStripMenuItem randomPasswordGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currencyConverterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuelcostCalculatorToolStripMenuItem;
    }
}

