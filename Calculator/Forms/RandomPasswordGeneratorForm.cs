namespace Calculator
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Calculator.Helpers;

    public partial class RandomPasswordGeneratorForm : Form
    {
        private const string NUMERIC = "0123456789";
        private const string SYMBOLS14 = "!@#$%^&*()-_+=";
        private const string SYMBOLS_ALL = "!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ ";
        private const string HEX_LOWER = "0123456789abcdef";
        private const string HEX_UPPER = "0123456789ABCDEF";
        private const string UALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string UALPHA_NUMERIC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string UALPHA_NUMERIC_SYMBOL14 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=";
        private const string UALPHA_NUMERIC_ALL = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ ";
        private const string LALPHA = "abcdefghijklmnopqrstuvwxyz";
        private const string LALPHA_NUMERIC = "abcdefghijklmnopqrstuvwxyz0123456789";
        private const string LALPHA_NUMERIC_SYMBOL14 = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_+=";
        private const string LALPHA_NUMERIC_ALL = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ ";
        private const string MIXALPHA = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string MIXALPHA_NUMERIC = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string MIXALPHA_NUMERIC_SYMBOL14 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=";
        private const string MIXALPHA_NUMERIC_ALL = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ ";

        private string QtyTextBoxText
        {
            get => this.qtyTextBox.Text;

            set => this.qtyTextBox.Text = value;
        }

        private string PasswordLengthTextBoxText
        {
            get => this.passwordLengthTextBox.Text;

            set => this.passwordLengthTextBox.Text = value;
        }

        private string CharsetSelectComboBoxText
        {
            get => this.charsetSelectComboBox.Text;

            set => this.charsetSelectComboBox.Text = value;
        }

        private string OutputTextBoxText
        {
            get => this.outputTextBox.Text;

            set => this.outputTextBox.Text = value;
        }

        private string CharsetCharsTextBoxText
        {
            get => this.charsetCharsTextBox.Text;

            set => this.charsetCharsTextBox.Text = value;
        }

        private string CharsetCharsCountLabelText
        {
            set => this.charsetCharsCountLabel.Text = value;
        }

        private string ToolStripStatusLabelText
        {
            set => this.toolStripStatusLabel.Text = value;
        }

        private bool CharsetCharsTextBoxReadOnly
        {
            set => this.charsetCharsTextBox.ReadOnly = value;
        }

        // random passwords string array
        private string[]? _rndPasswords;

        public RandomPasswordGeneratorForm()
        {
            this.InitializeComponent();
        }

        private void RandomPasswordGeneratorForm_Load(object sender, EventArgs e)
        {
            this.saveToFileButton.Enabled = false;

            this.QtyTextBoxText = AppSettings.PasswordQty.ToString();
            this.PasswordLengthTextBoxText = AppSettings.PasswordLength.ToString();
            this.CharsetSelectComboBoxText = AppSettings.PasswordCharset.ToString();

            this.TopMost = AppSettings.TopMost;
        }

        private void RandomPasswordGeneratorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CharsetCharsTextBox_TextChanged(object sender, EventArgs e) => this.CharsetCharsCountLabelText = $"{this.CharsetCharsTextBoxText.Length} char(s)";

        private async void GenerateButton_Click(object sender, EventArgs e)
        {
            // how many random passwords should be generated
            int qty = 0;
            // generated password length
            int length = 0;

            try
            {
                qty = int.Parse(this.QtyTextBoxText);
                length = int.Parse(this.PasswordLengthTextBoxText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (qty <= 0 || length <= 0)
            {
                MessageBox.Show("Qty/length must be a positive integer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(this.CharsetCharsTextBoxText))
            {
                MessageBox.Show("Charset textbox is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.uniqueSequenceCheckBox.Checked && this.CharsetCharsTextBoxText.Length < length)
            {
                MessageBox.Show("Charset chars count is less than password length", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.uniqueSequenceCheckBox.Checked && !CharsetIsUnique(this.CharsetCharsTextBoxText))
            {
                MessageBox.Show("Charset has duplicate items", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Clear();

            this.generateButton.Enabled = false;
            this.ToolStripStatusLabelText = "Executing...";

            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.MarqueeAnimationSpeed = 100;

            var sw = Stopwatch.StartNew();

            // create a task
            var task = this.uniqueSequenceCheckBox.Checked
                       ? Task.Run(() => this.GenerateRandomUniqueSequencePasswords(this.CharsetCharsTextBoxText, qty, length))
                       : Task.Run(() => this.GenerateRandomPasswords(this.CharsetCharsTextBoxText, qty, length));

            // wait till task finish executing
            await Task.WhenAll(task);

            sw.Stop();

            if (this._rndPasswords is not null)
            {
                this.OutputTextBoxText = string.Join(Environment.NewLine, this._rndPasswords);
            }

            this.ToolStripStatusLabelText = $"Elapsed: {sw.ElapsedMilliseconds} ms.";

            this.progressBar.Style = ProgressBarStyle.Blocks;
            this.progressBar.Value = 100;
            this.generateButton.Enabled = true;
            this.saveToFileButton.Enabled = true;
        }

        private static bool CharsetIsUnique(string charset)
        {
            // using two bytes size bool array for Unicode chars
            bool[] array = new bool[char.MaxValue];

            foreach (char ch in charset)
            {
                if (array[ch])
                {
                    // return false, when duplicate char was found
                    return false;
                }

                array[ch] = true;
            }

            return true;
        }

        private void GenerateRandomPasswords(string charset, int qty, int length)
        {
            this._rndPasswords = new string[qty];
            INumberGenerator rnd = new RNGNumberGenerator();

            for (int i = 0; i < this._rndPasswords.Length; i++)
            {
                char[] randomPassword = new char[length];

                for (int j = 0; j < randomPassword.Length; j++)
                {
                    int pos = rnd.GetInt32(charset.Length);
                    randomPassword[j] = charset[pos];
                }

                this._rndPasswords[i] = new string(randomPassword);
            }
        }

        private void GenerateRandomUniqueSequencePasswords(string charset, int qty, int length)
        {
            this._rndPasswords = new string[qty];
            INumberGenerator rnd = new RNGNumberGenerator();

            for (int i = 0; i < this._rndPasswords.Length; i++)
            {
                var charsetList = charset.ToList();
                char[] randomPassword = new char[length];

                for (int j = 0; j < randomPassword.Length; j++)
                {
                    int pos = rnd.GetInt32(charsetList.Count);
                    randomPassword[j] = charsetList[pos];
                    charsetList.RemoveAt(pos);
                }

                this._rndPasswords[i] = new string(randomPassword);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e) => this.Clear();

        private void Clear()
        {
            this.OutputTextBoxText = string.Empty;
            // reset current progress bar value
            this.progressBar.Value = 0;
            this.ToolStripStatusLabelText = string.Empty;
            this.saveToFileButton.Enabled = false;
            // Initiate garbage collector
            GC.Collect();
        }

        private void QtyTextBox_TextChanged(object sender, EventArgs e) => AppSettings.PasswordQty = int.Parse(this.QtyTextBoxText);

        private void PasswordLengthTextBox_TextChanged(object sender, EventArgs e) => AppSettings.PasswordLength = int.Parse(this.PasswordLengthTextBoxText);

        private void CharsetSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            AppSettings.PasswordCharset = this.CharsetSelectComboBoxText;

            if (this.CharsetSelectComboBoxText == "HEX_LOWER")
            {
                this.CharsetCharsTextBoxText = HEX_LOWER;
            }
            else if (this.CharsetSelectComboBoxText == "HEX_UPPER")
            {
                this.CharsetCharsTextBoxText = HEX_UPPER;
            }
            else if (this.CharsetSelectComboBoxText == "LALPHA")
            {
                this.CharsetCharsTextBoxText = LALPHA;
            }
            else if (this.CharsetSelectComboBoxText == "LALPHA_NUMERIC")
            {
                this.CharsetCharsTextBoxText = LALPHA_NUMERIC;
            }
            else if (this.CharsetSelectComboBoxText == "LALPHA_NUMERIC_ALL")
            {
                this.CharsetCharsTextBoxText = LALPHA_NUMERIC_ALL;
            }
            else if (this.CharsetSelectComboBoxText == "LALPHA_NUMERIC_SYMBOL14")
            {
                this.CharsetCharsTextBoxText = LALPHA_NUMERIC_SYMBOL14;
            }
            else if (this.CharsetSelectComboBoxText == "MIXALPHA")
            {
                this.CharsetCharsTextBoxText = MIXALPHA;
            }
            else if (this.CharsetSelectComboBoxText == "MIXALPHA_NUMERIC")
            {
                this.CharsetCharsTextBoxText = MIXALPHA_NUMERIC;
            }
            else if (this.CharsetSelectComboBoxText == "MIXALPHA_NUMERIC_ALL")
            {
                this.CharsetCharsTextBoxText = MIXALPHA_NUMERIC_ALL;
            }
            else if (this.CharsetSelectComboBoxText == "MIXALPHA_NUMERIC_SYMBOL14")
            {
                this.CharsetCharsTextBoxText = MIXALPHA_NUMERIC_SYMBOL14;
            }
            else if (this.CharsetSelectComboBoxText == "NUMERIC")
            {
                this.CharsetCharsTextBoxText = NUMERIC;
            }
            else if (this.CharsetSelectComboBoxText == "SYMBOLS14")
            {
                this.CharsetCharsTextBoxText = SYMBOLS14;
            }
            else if (this.CharsetSelectComboBoxText == "SYMBOLS_ALL")
            {
                this.CharsetCharsTextBoxText = SYMBOLS_ALL;
            }
            else if (this.CharsetSelectComboBoxText == "UALPHA")
            {
                this.CharsetCharsTextBoxText = UALPHA;
            }
            else if (this.CharsetSelectComboBoxText == "UALPHA_NUMERIC")
            {
                this.CharsetCharsTextBoxText = UALPHA_NUMERIC;
            }
            else if (this.CharsetSelectComboBoxText == "UALPHA_NUMERIC_ALL")
            {
                this.CharsetCharsTextBoxText = UALPHA_NUMERIC_ALL;
            }
            else if (this.CharsetSelectComboBoxText == "UALPHA_NUMERIC_SYMBOL14")
            {
                this.CharsetCharsTextBoxText = UALPHA_NUMERIC_SYMBOL14;
            }
        }

        private void EditCheckBox_CheckedChanged(object sender, EventArgs e) => this.CharsetCharsTextBoxReadOnly = !this.editCheckBox.Checked;

        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    File.WriteAllText(fileName, this.OutputTextBoxText);
                    MessageBox.Show($"File saved as: '{fileName}'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
