namespace Calculator.Forms;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
    private const string PASSWORD_CHARSET = "abcdefghjkmnpqrstuvwxyzABCDEFGHJKMNPQRSTUVWXYZ123456789!@#$%^&*()-_+=";

    private static readonly IReadOnlyList<string> Charset = new List<string>
    {
        nameof(NUMERIC),
        nameof(SYMBOLS14),
        nameof(SYMBOLS_ALL),
        nameof(HEX_LOWER),
        nameof(HEX_UPPER),
        nameof(UALPHA),
        nameof(UALPHA_NUMERIC),
        nameof(UALPHA_NUMERIC_SYMBOL14),
        nameof(UALPHA_NUMERIC_ALL),
        nameof(LALPHA),
        nameof(LALPHA_NUMERIC),
        nameof(LALPHA_NUMERIC_SYMBOL14),
        nameof(LALPHA_NUMERIC_ALL),
        nameof(MIXALPHA),
        nameof(MIXALPHA_NUMERIC),
        nameof(MIXALPHA_NUMERIC_SYMBOL14),
        nameof(MIXALPHA_NUMERIC_ALL),
        nameof(PASSWORD_CHARSET),
    };

    // random passwords string array
    private string[]? rndPasswords;

    public RandomPasswordGeneratorForm()
    {
        this.InitializeComponent();
    }

    private void RandomPasswordGeneratorForm_Load(object sender, EventArgs e)
    {
        this.TopMost = AppSettings.TopMost;
        this.saveToFileButton.Enabled = false;

        this.qtyTextBox.Text = AppSettings.PasswordQty.ToString();
        this.passwordLengthTextBox.Text = AppSettings.PasswordLength.ToString();

        foreach (string item in Charset)
        {
            this.charsetSelectComboBox.Items.Add(item);
        }

        this.charsetSelectComboBox.Text = AppSettings.PasswordCharset.ToString();
    }

    private void RandomPasswordGeneratorForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }

    private void CharsetCharsTextBox_TextChanged(object sender, EventArgs e) => this.charsetCharsCountLabel.Text = $"{this.charsetCharsTextBox.Text.Length} char(s)";

    private async void GenerateButton_Click(object sender, EventArgs e)
    {
        // how many random passwords should be generated
        int qty = 0;
        // generated password length
        int length = 0;

        try
        {
            qty = int.Parse(this.qtyTextBox.Text);
            length = int.Parse(this.passwordLengthTextBox.Text);
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

        if (string.IsNullOrEmpty(this.charsetCharsTextBox.Text))
        {
            MessageBox.Show("Charset textbox is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (this.uniqueSequenceCheckBox.Checked && this.charsetCharsTextBox.Text.Length < length)
        {
            MessageBox.Show("Charset chars count is less than password length", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (this.uniqueSequenceCheckBox.Checked && !CharsetIsUnique(this.charsetCharsTextBox.Text))
        {
            MessageBox.Show("Charset has duplicate items", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        this.Clear();

        this.generateButton.Enabled = false;
        this.toolStripStatusLabel.Text = "Executing...";

        this.progressBar.Style = ProgressBarStyle.Marquee;
        this.progressBar.MarqueeAnimationSpeed = 100;

        var sw = Stopwatch.StartNew();

        // create a task
        var task = this.uniqueSequenceCheckBox.Checked
                   ? Task.Run(() => this.GenerateRandomUniqueSequencePasswords(this.charsetCharsTextBox.Text, qty, length))
                   : Task.Run(() => this.GenerateRandomPasswords(this.charsetCharsTextBox.Text, qty, length));

        // wait till task finish executing
        await task;

        sw.Stop();

        if (this.rndPasswords is not null)
        {
            string tmp = string.Join(Environment.NewLine, this.rndPasswords);
            this.outputTextBox.Text = tmp;
            Clipboard.SetDataObject(tmp);
        }

        this.toolStripStatusLabel.Text = $"Elapsed: {sw.ElapsedMilliseconds} ms.";

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
        this.rndPasswords = new string[qty];

        for (int i = 0; i < this.rndPasswords.Length; i++)
        {
            char[] randomPassword = new char[length];

            for (int j = 0; j < randomPassword.Length; j++)
            {
                int pos = RandomNumberGenerator.GetInt32(charset.Length);
                randomPassword[j] = charset[pos];
            }

            this.rndPasswords[i] = new string(randomPassword);
        }
    }

    private void GenerateRandomUniqueSequencePasswords(string charset, int qty, int length)
    {
        this.rndPasswords = new string[qty];

        for (int i = 0; i < this.rndPasswords.Length; i++)
        {
            var charsetList = charset.ToList();
            char[] randomPassword = new char[length];

            for (int j = 0; j < randomPassword.Length; j++)
            {
                int pos = RandomNumberGenerator.GetInt32(charsetList.Count);
                randomPassword[j] = charsetList[pos];
                charsetList.RemoveAt(pos);
            }

            this.rndPasswords[i] = new string(randomPassword);
        }
    }

    private void ClearButton_Click(object sender, EventArgs e) => this.Clear();

    private void Clear()
    {
        this.outputTextBox.Text = string.Empty;
        // reset current progress bar value
        this.progressBar.Value = 0;
        this.toolStripStatusLabel.Text = string.Empty;
        this.saveToFileButton.Enabled = false;
        // Initiate garbage collector
        GC.Collect();
    }

    private void QtyTextBox_TextChanged(object sender, EventArgs e) => AppSettings.PasswordQty = int.Parse(this.qtyTextBox.Text);

    private void PasswordLengthTextBox_TextChanged(object sender, EventArgs e) => AppSettings.PasswordLength = int.Parse(this.passwordLengthTextBox.Text);

    private void CharsetSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        AppSettings.PasswordCharset = this.charsetSelectComboBox.Text;

        if (this.charsetSelectComboBox.Text == nameof(PASSWORD_CHARSET))
        {
            this.charsetCharsTextBox.Text = PASSWORD_CHARSET;
        }
        else if (this.charsetSelectComboBox.Text == nameof(HEX_LOWER))
        {
            this.charsetCharsTextBox.Text = HEX_LOWER;
        }
        else if (this.charsetSelectComboBox.Text == nameof(HEX_UPPER))
        {
            this.charsetCharsTextBox.Text = HEX_UPPER;
        }
        else if (this.charsetSelectComboBox.Text == nameof(LALPHA))
        {
            this.charsetCharsTextBox.Text = LALPHA;
        }
        else if (this.charsetSelectComboBox.Text == nameof(LALPHA_NUMERIC))
        {
            this.charsetCharsTextBox.Text = LALPHA_NUMERIC;
        }
        else if (this.charsetSelectComboBox.Text == nameof(LALPHA_NUMERIC_ALL))
        {
            this.charsetCharsTextBox.Text = LALPHA_NUMERIC_ALL;
        }
        else if (this.charsetSelectComboBox.Text == nameof(LALPHA_NUMERIC_SYMBOL14))
        {
            this.charsetCharsTextBox.Text = LALPHA_NUMERIC_SYMBOL14;
        }
        else if (this.charsetSelectComboBox.Text == nameof(MIXALPHA))
        {
            this.charsetCharsTextBox.Text = MIXALPHA;
        }
        else if (this.charsetSelectComboBox.Text == nameof(MIXALPHA_NUMERIC))
        {
            this.charsetCharsTextBox.Text = MIXALPHA_NUMERIC;
        }
        else if (this.charsetSelectComboBox.Text == nameof(MIXALPHA_NUMERIC_ALL))
        {
            this.charsetCharsTextBox.Text = MIXALPHA_NUMERIC_ALL;
        }
        else if (this.charsetSelectComboBox.Text == nameof(MIXALPHA_NUMERIC_SYMBOL14))
        {
            this.charsetCharsTextBox.Text = MIXALPHA_NUMERIC_SYMBOL14;
        }
        else if (this.charsetSelectComboBox.Text == nameof(NUMERIC))
        {
            this.charsetCharsTextBox.Text = NUMERIC;
        }
        else if (this.charsetSelectComboBox.Text == nameof(SYMBOLS14))
        {
            this.charsetCharsTextBox.Text = SYMBOLS14;
        }
        else if (this.charsetSelectComboBox.Text == nameof(SYMBOLS_ALL))
        {
            this.charsetCharsTextBox.Text = SYMBOLS_ALL;
        }
        else if (this.charsetSelectComboBox.Text == nameof(UALPHA))
        {
            this.charsetCharsTextBox.Text = UALPHA;
        }
        else if (this.charsetSelectComboBox.Text == nameof(UALPHA_NUMERIC))
        {
            this.charsetCharsTextBox.Text = UALPHA_NUMERIC;
        }
        else if (this.charsetSelectComboBox.Text == nameof(UALPHA_NUMERIC_ALL))
        {
            this.charsetCharsTextBox.Text = UALPHA_NUMERIC_ALL;
        }
        else if (this.charsetSelectComboBox.Text == nameof(UALPHA_NUMERIC_SYMBOL14))
        {
            this.charsetCharsTextBox.Text = UALPHA_NUMERIC_SYMBOL14;
        }
    }

    private void EditCheckBox_CheckedChanged(object sender, EventArgs e) => this.charsetCharsTextBox.ReadOnly = !this.editCheckBox.Checked;

    private void SaveToFileButton_Click(object sender, EventArgs e)
    {
        var saveFileDialog = new SaveFileDialog();

        try
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                File.WriteAllText(fileName, this.outputTextBox.Text);
                MessageBox.Show($"File saved as: '{fileName}'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
