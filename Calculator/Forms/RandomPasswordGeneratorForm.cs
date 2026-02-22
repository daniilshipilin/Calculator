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
    private static readonly IReadOnlyDictionary<string, string> Charsets = new Dictionary<string, string>
    {
        { "Numeric", "0123456789" },
        { "Symbols14", "!@#$%^&*()-_+=" },
        { "SymbolsAll", "!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ " },
        { "HexLower", "0123456789abcdef" },
        { "HexUpper", "0123456789ABCDEF" },
        { "UAlpha", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
        { "UAlphaNumeric", "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" },
        { "UAlphaNumericSymbol14", "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=" },
        { "UAlphaNumericAll", "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ " },
        { "LAlpha", "abcdefghijklmnopqrstuvwxyz" },
        { "LAlphaNumeric", "abcdefghijklmnopqrstuvwxyz0123456789" },
        { "LAlphaNumericSymbol14", "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_+=" },
        { "LAlphaNumericAll", "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ " },
        { "MixAlpha", "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" },
        { "MixAlphaNumeric", "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" },
        { "MixAlphaNumericSymbol14", "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=" },
        { "MixAlphaNumericAll", "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=~`[]{}|\\:;\"'<>,.?/ " },
        { "PasswordCharset", "abcdefghjkmnpqrstuvwxyzABCDEFGHJKMNPQRSTUVWXYZ123456789!@#$%^&*()-_+=" },
        { "GuidFormat", "GUID 8-4-4-4-12 format" },
    };

    private IEnumerable<string> rndPasswords = [];

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

        foreach (string item in Charsets.Keys)
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

    private void CharsetCharsTextBox_TextChanged(object sender, EventArgs e)
        => this.charsetCharsCountLabel.Text = this.charsetSelectComboBox.Text.Equals("GuidFormat")
            ? string.Empty
            : $"{this.charsetCharsTextBox.Text.Length} char(s)";

    private async void GenerateButton_Click(object sender, EventArgs e)
    {
        int qty = 0;
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

        bool guidGenerate = this.charsetSelectComboBox.Text.Equals("GuidFormat");

        if (!guidGenerate)
        {
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
        }

        this.Clear();

        this.generateButton.Enabled = false;
        this.toolStripStatusLabel.Text = "Executing...";

        this.progressBar.Style = ProgressBarStyle.Marquee;
        this.progressBar.MarqueeAnimationSpeed = 100;

        var sw = Stopwatch.StartNew();

        var task = guidGenerate
            ? Task.Run(() => this.GenerateRandomGuids(qty))
            : this.uniqueSequenceCheckBox.Checked
                ? Task.Run(() => this.GenerateRandomUniqueSequencePasswords(this.charsetCharsTextBox.Text, qty, length))
                : Task.Run(() => this.GenerateRandomPasswords(this.charsetCharsTextBox.Text, qty, length));

        await task;

        sw.Stop();

        this.outputTextBox.Text = string.Join(Environment.NewLine, this.rndPasswords);

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
                return false;
            }

            array[ch] = true;
        }

        return true;
    }

    private void GenerateRandomGuids(int qty)
    {
        string[] guids = new string[qty];

        for (int i = 0; i < guids.Length; i++)
        {
            byte[] bytes = new byte[16];
            RandomNumberGenerator.Fill(bytes);
            guids[i] = new Guid(bytes).ToString();
        }

        this.rndPasswords = guids;
    }

    private void GenerateRandomPasswords(string charset, int qty, int length)
    {
        string[] passwords = new string[qty];

        for (int i = 0; i < passwords.Length; i++)
        {
            char[] randomPassword = new char[length];

            for (int j = 0; j < randomPassword.Length; j++)
            {
                int pos = RandomNumberGenerator.GetInt32(charset.Length);
                randomPassword[j] = charset[pos];
            }

            passwords[i] = new string(randomPassword);
        }

        this.rndPasswords = passwords;
    }

    private void GenerateRandomUniqueSequencePasswords(string charset, int qty, int length)
    {
        string[] passwords = new string[qty];

        for (int i = 0; i < passwords.Length; i++)
        {
            var charsetList = charset.ToList();
            char[] randomPassword = new char[length];

            for (int j = 0; j < randomPassword.Length; j++)
            {
                int pos = RandomNumberGenerator.GetInt32(charsetList.Count);
                randomPassword[j] = charsetList[pos];
                charsetList.RemoveAt(pos);
            }

            passwords[i] = new string(randomPassword);
        }

        this.rndPasswords = passwords;
    }

    private void ClearButton_Click(object sender, EventArgs e)
        => this.Clear();

    private void Clear()
    {
        this.outputTextBox.Text = string.Empty;
        this.progressBar.Value = 0;
        this.toolStripStatusLabel.Text = string.Empty;
        this.saveToFileButton.Enabled = false;
        this.rndPasswords = [];
    }

    private void QtyTextBox_TextChanged(object sender, EventArgs e)
        => AppSettings.PasswordQty = int.Parse(this.qtyTextBox.Text);

    private void PasswordLengthTextBox_TextChanged(object sender, EventArgs e)
        => AppSettings.PasswordLength = int.Parse(this.passwordLengthTextBox.Text);

    private void CharsetSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        if (this.charsetSelectComboBox.Text.Equals("GuidFormat"))
        {
            this.editCheckBox.Checked = false;
            this.editCheckBox.Enabled = false;
            this.passwordLengthTextBox.Enabled = false;
        }
        else
        {
            this.editCheckBox.Enabled = true;
            this.passwordLengthTextBox.Enabled = true;
        }

        if (Charsets.TryGetValue(this.charsetSelectComboBox.Text, out string? charset))
        {
            this.charsetCharsTextBox.Text = charset;
            AppSettings.PasswordCharset = this.charsetSelectComboBox.Text;
        }
    }

    private void EditCheckBox_CheckedChanged(object sender, EventArgs e)
        => this.charsetCharsTextBox.ReadOnly = !this.editCheckBox.Checked;

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
