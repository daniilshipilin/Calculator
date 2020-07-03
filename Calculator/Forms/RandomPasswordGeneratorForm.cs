using Calculator.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class RandomPasswordGeneratorForm : Form
    {
        #region Charsets

        const string NUMERIC = "0123456789";
        const string SYMBOLS14 = "!@#$%^&*()-_+=";
        const string SYMBOLS_ALL = "!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ ";
        const string HEX_LOWER = "0123456789abcdef";
        const string HEX_UPPER = "0123456789ABCDEF";

        const string UALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string UALPHA_NUMERIC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        const string UALPHA_NUMERIC_SYMBOL14 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=";
        const string UALPHA_NUMERIC_ALL = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ ";

        const string LALPHA = "abcdefghijklmnopqrstuvwxyz";
        const string LALPHA_NUMERIC = "abcdefghijklmnopqrstuvwxyz0123456789";
        const string LALPHA_NUMERIC_SYMBOL14 = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_+=";
        const string LALPHA_NUMERIC_ALL = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ ";

        const string MIXALPHA = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string MIXALPHA_NUMERIC = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        const string MIXALPHA_NUMERIC_SYMBOL14 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=";
        const string MIXALPHA_NUMERIC_ALL = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ ";

        #endregion

        #region Properties

        string QtyTextBoxText
        {
            get { return (qtyTextBox.Text); }
            set { qtyTextBox.Text = value; }
        }

        string PasswordLengthTextBoxText
        {
            get { return (passwordLengthTextBox.Text); }
            set { passwordLengthTextBox.Text = value; }
        }

        string CharsetSelectComboBoxText
        {
            get { return (charsetSelectComboBox.Text); }
            set { charsetSelectComboBox.Text = value; }
        }

        string OutputTextBoxText
        {
            get { return (outputTextBox.Text); }
            set { outputTextBox.Text = value; }
        }

        string CharsetCharsTextBoxText
        {
            get { return (charsetCharsTextBox.Text); }
            set { charsetCharsTextBox.Text = value; }
        }

        string CharsetCharsCountLabelText
        {
            set { charsetCharsCountLabel.Text = value; }
        }

        string ToolStripStatusLabelText
        {
            set { toolStripStatusLabel.Text = value; }
        }

        bool CharsetCharsTextBoxReadOnly
        {
            set { charsetCharsTextBox.ReadOnly = value; }
        }

        #endregion

        #region AppSettings

        static readonly List<string> _keys = new List<string>
        {
            "PasswordQty",
            "PasswordLength",
            "PasswordCharset"
        };

        #endregion

        #region Fields

        // flag to activate settings update
        bool _settingsUpdateEnabled = false;

        // random passwords string array
        string[] _rndPasswords;

        #endregion

        public RandomPasswordGeneratorForm()
        {
            InitializeComponent();
        }

        private void RandomPasswordGeneratorForm_Load(object sender, EventArgs e)
        {
            // default values
            QtyTextBoxText = "10";
            PasswordLengthTextBoxText = "10";
            CharsetSelectComboBoxText = "MIXALPHA_NUMERIC_ALL";
            saveToFileButton.Enabled = false;

            // configuration check
            if (AppSettings.AssemblyExist())
            {
                if (AppSettings.KeyExist(_keys[0]))
                {
                    QtyTextBoxText = AppSettings.ReadKey(_keys[0]);
                }

                if (AppSettings.KeyExist(_keys[1]))
                {
                    PasswordLengthTextBoxText = AppSettings.ReadKey(_keys[1]);
                }

                if (AppSettings.KeyExist(_keys[2]))
                {
                    CharsetSelectComboBoxText = AppSettings.ReadKey(_keys[2]);
                }

                _settingsUpdateEnabled = true;
            }

            TopMost = Program.GlobalTopMost;
        }

        private void RandomPasswordGeneratorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void CharsetCharsTextBox_TextChanged(object sender, EventArgs e)
        {
            CharsetCharsCountLabelText = $"{CharsetCharsTextBoxText.Length} char(s)";
        }

        private async void GenerateButton_Click(object sender, EventArgs e)
        {
            // how many random passwords should be generated
            int qty = 0;
            // generated password length
            int length = 0;

            try
            {
                qty = int.Parse(QtyTextBoxText);
                length = int.Parse(PasswordLengthTextBoxText);
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

            if (string.IsNullOrEmpty(CharsetCharsTextBoxText))
            {
                MessageBox.Show("Charset textbox is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (uniqueSequenceCheckBox.Checked && CharsetCharsTextBoxText.Length < length)
            {
                MessageBox.Show("Charset chars count is less than password length", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (uniqueSequenceCheckBox.Checked && !CharsetIsUnique(CharsetCharsTextBoxText))
            {
                MessageBox.Show("Charset has duplicate items", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Clear();

            generateButton.Enabled = false;
            ToolStripStatusLabelText = "Executing...";

            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 100;

            var sw = Stopwatch.StartNew();

            // create a task
            var task = (uniqueSequenceCheckBox.Checked)
                       ? Task.Run(() => GenerateRandomUniqueSequencePasswords(CharsetCharsTextBoxText, qty, length))
                       : Task.Run(() => GenerateRandomPasswords(CharsetCharsTextBoxText, qty, length));

            // wait till task finish executing
            await Task.WhenAll(task);

            sw.Stop();
            OutputTextBoxText = string.Join(Environment.NewLine, _rndPasswords);
            _rndPasswords = null;
            ToolStripStatusLabelText = $"Elapsed: {sw.ElapsedMilliseconds} ms.";

            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 100;
            generateButton.Enabled = true;
            saveToFileButton.Enabled = true;
        }

        private bool CharsetIsUnique(string charset)
        {
            // using two bytes size bool array for Unicode chars
            bool[] array = new bool[char.MaxValue];

            foreach (var ch in charset)
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
            _rndPasswords = new string[qty];
            INumberGenerator rnd = new RNGNumberGenerator();

            for (int i = 0; i < _rndPasswords.Length; i++)
            {
                char[] randomPassword = new char[length];

                for (int j = 0; j < randomPassword.Length; j++)
                {
                    int pos = rnd.GetInt32(charset.Length);
                    randomPassword[j] = charset[pos];
                }

                _rndPasswords[i] = new string(randomPassword);
            }
        }

        private void GenerateRandomUniqueSequencePasswords(string charset, int qty, int length)
        {
            _rndPasswords = new string[qty];
            INumberGenerator rnd = new RNGNumberGenerator();

            for (int i = 0; i < _rndPasswords.Length; i++)
            {
                List<char> charsetList = charset.ToList();
                char[] randomPassword = new char[length];

                for (int j = 0; j < randomPassword.Length; j++)
                {
                    int pos = rnd.GetInt32(charsetList.Count);
                    randomPassword[j] = charsetList[pos];
                    charsetList.RemoveAt(pos);
                }

                _rndPasswords[i] = new string(randomPassword);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            OutputTextBoxText = string.Empty;
            // reset current progress bar value
            progressBar.Value = 0;
            ToolStripStatusLabelText = string.Empty;
            saveToFileButton.Enabled = false;
            // Initiate garbage collector
            GC.Collect();
        }

        private void QtyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_settingsUpdateEnabled)
            {
                UpdateSettings(_keys[0]);
            }
        }

        private void PasswordLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_settingsUpdateEnabled)
            {
                UpdateSettings(_keys[1]);
            }
        }

        private void CharsetSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_settingsUpdateEnabled)
            {
                UpdateSettings(_keys[2]);
            }

            if (CharsetSelectComboBoxText == "HEX_LOWER")
            {
                CharsetCharsTextBoxText = HEX_LOWER;
            }
            else if (CharsetSelectComboBoxText == "HEX_UPPER")
            {
                CharsetCharsTextBoxText = HEX_UPPER;
            }
            else if (CharsetSelectComboBoxText == "LALPHA")
            {
                CharsetCharsTextBoxText = LALPHA;
            }
            else if (CharsetSelectComboBoxText == "LALPHA_NUMERIC")
            {
                CharsetCharsTextBoxText = LALPHA_NUMERIC;
            }
            else if (CharsetSelectComboBoxText == "LALPHA_NUMERIC_ALL")
            {
                CharsetCharsTextBoxText = LALPHA_NUMERIC_ALL;
            }
            else if (CharsetSelectComboBoxText == "LALPHA_NUMERIC_SYMBOL14")
            {
                CharsetCharsTextBoxText = LALPHA_NUMERIC_SYMBOL14;
            }
            else if (CharsetSelectComboBoxText == "MIXALPHA")
            {
                CharsetCharsTextBoxText = MIXALPHA;
            }
            else if (CharsetSelectComboBoxText == "MIXALPHA_NUMERIC")
            {
                CharsetCharsTextBoxText = MIXALPHA_NUMERIC;
            }
            else if (CharsetSelectComboBoxText == "MIXALPHA_NUMERIC_ALL")
            {
                CharsetCharsTextBoxText = MIXALPHA_NUMERIC_ALL;
            }
            else if (CharsetSelectComboBoxText == "MIXALPHA_NUMERIC_SYMBOL14")
            {
                CharsetCharsTextBoxText = MIXALPHA_NUMERIC_SYMBOL14;
            }
            else if (CharsetSelectComboBoxText == "NUMERIC")
            {
                CharsetCharsTextBoxText = NUMERIC;
            }
            else if (CharsetSelectComboBoxText == "SYMBOLS14")
            {
                CharsetCharsTextBoxText = SYMBOLS14;
            }
            else if (CharsetSelectComboBoxText == "SYMBOLS_ALL")
            {
                CharsetCharsTextBoxText = SYMBOLS_ALL;
            }
            else if (CharsetSelectComboBoxText == "UALPHA")
            {
                CharsetCharsTextBoxText = UALPHA;
            }
            else if (CharsetSelectComboBoxText == "UALPHA_NUMERIC")
            {
                CharsetCharsTextBoxText = UALPHA_NUMERIC;
            }
            else if (CharsetSelectComboBoxText == "UALPHA_NUMERIC_ALL")
            {
                CharsetCharsTextBoxText = UALPHA_NUMERIC_ALL;
            }
            else if (CharsetSelectComboBoxText == "UALPHA_NUMERIC_SYMBOL14")
            {
                CharsetCharsTextBoxText = UALPHA_NUMERIC_SYMBOL14;
            }
        }

        private void UpdateSettings(string key)
        {
            // update settings
            if (AppSettings.AssemblyExist())
            {
                if (AppSettings.KeyExist(key))
                {
                    if (QtyTextBoxText != AppSettings.ReadKey(_keys[0]))
                    {
                        AppSettings.UpdateKey(key, QtyTextBoxText);
                    }
                    else if (PasswordLengthTextBoxText != AppSettings.ReadKey(_keys[1]))
                    {
                        AppSettings.UpdateKey(key, PasswordLengthTextBoxText);
                    }
                    else if (CharsetSelectComboBoxText != AppSettings.ReadKey(_keys[2]))
                    {
                        AppSettings.UpdateKey(key, CharsetSelectComboBoxText);
                    }
                }
            }
        }

        private void EditCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CharsetCharsTextBoxReadOnly = !editCheckBox.Checked;
        }

        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    File.WriteAllText(fileName, OutputTextBoxText);
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
