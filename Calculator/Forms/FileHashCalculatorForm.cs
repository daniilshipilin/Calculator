namespace Calculator.Forms;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Helpers;
using DamienG.Security.Cryptography;

public partial class FileHashCalculatorForm : Form
{
    // buffer to store file contents
    private byte[]? openFileBytes;

    public FileHashCalculatorForm()
    {
        this.InitializeComponent();
    }

    private void CalculateFileHashForm_Load(object sender, EventArgs e)
    {
        // textbox tooltips
        this.calculateFileHashFormToolTip.SetToolTip(this.crc32TextBox, "A 32-bit CRC hash algorithm.");
        this.calculateFileHashFormToolTip.SetToolTip(this.elf32TextBox, "A 32-bit ELF hash algorithm compatible with ELF binary format.");
        this.calculateFileHashFormToolTip.SetToolTip(this.md5TextBox, "A 128-bit MD5 hash algorithm.");
        this.calculateFileHashFormToolTip.SetToolTip(this.sha1TextBox, "A 160-bit SHA-1 cryptographic hash function.");
        this.calculateFileHashFormToolTip.SetToolTip(this.sha256TextBox, "A 256-bit SHA-2 cryptographic hash function.");
        this.calculateFileHashFormToolTip.SetToolTip(this.sha384TextBox, "A 384-bit SHA-2 cryptographic hash function.");
        this.calculateFileHashFormToolTip.SetToolTip(this.sha512TextBox, "A 512-bit SHA-2 cryptographic hash function.");

        this.openSingleFileNameLabel.Text = "No file selected";
        this.executionStatusLabel.Text = "Nothing to execute";

        this.crc32CheckBox.Checked = AppSettings.Crc32Checked;
        this.elf32CheckBox.Checked = AppSettings.Elf32Checked;
        this.md5CheckBox.Checked = AppSettings.Md5Checked;
        this.sha1CheckBox.Checked = AppSettings.Sha1Checked;
        this.sha256CheckBox.Checked = AppSettings.Sha256Checked;
        this.sha384CheckBox.Checked = AppSettings.Sha384Checked;
        this.sha512CheckBox.Checked = AppSettings.Sha512Checked;

        this.TopMost = AppSettings.TopMost;
    }

    private void CalculateFileHashForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }

    private async void OpenSingleFileAsyncButton_Click(object sender, EventArgs e) => await this.OpenSingleFileAsync();

    private async Task OpenSingleFileAsync()
    {
        if (this.openSingleFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                using var br = new BinaryReader(File.Open(this.openSingleFileDialog.FileName, FileMode.Open, FileAccess.Read));

                if (br.BaseStream.Length is > int.MaxValue or 0)
                {
                    throw new IndexOutOfRangeException("File is empty or its size is bigger than 2GB");
                }

                // async method #1: using await
                this.openFileBytes = await Task.Run(() => br.ReadBytes((int)br.BaseStream.Length));

                // async method #2: using list of tasks
                //List<Task<byte[]>> tasks = new List<Task<byte[]>>();
                //tasks.Add(Task.Run(() => br.ReadBytes((int)br.BaseStream.Length)));
                //var tasksResults = await Task.WhenAll(tasks);
                //_openFileBytes = tasksResults[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            this.ClearTextBoxes();

            this.openSingleFileNameLabel.Text = this.openSingleFileDialog.FileName;
        }
    }

    private async void CalculateHashesAsyncButton_Click(object sender, EventArgs e)
    {
        if (this.openFileBytes == null)
        {
            MessageBox.Show("Select the file first", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (this.crc32CheckBox.Checked ||
            this.elf32CheckBox.Checked ||
            this.md5CheckBox.Checked ||
            this.sha1CheckBox.Checked ||
            this.sha256CheckBox.Checked ||
            this.sha384CheckBox.Checked ||
            this.sha512CheckBox.Checked)
        {
            this.ClearTextBoxes();

            this.calculateHashesButton.Enabled = false;
            this.executionStatusLabel.Text = "Calculating hash(es)";

            var stopWatch = Stopwatch.StartNew();

            await this.CalculateHashesParallelAsync(this.openFileBytes);

            stopWatch.Stop();
            long elapsedMs = stopWatch.ElapsedMilliseconds;

            this.calculateHashesButton.Enabled = true;
            this.executionStatusLabel.Text = $"Done - Elapsed(ms): {elapsedMs}";
        }
        else
        {
            MessageBox.Show("No hashing method(s) selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private async Task CalculateHashesParallelAsync(byte[] bytes)
    {
        // reset current progress bar value
        this.progressBar.Value = 0;
        this.progressBar.Maximum = this.GetTasksTotal();

        // This lambda is executed in context of UI thread, so it can safely update form controls
        var progress = new Progress<int>(v => { this.progressBar.Value += v; });

        // create list of tasks
        var tasks = new List<Task<string>>();

        // multithreaded parallel execution
        if (this.crc32CheckBox.Checked)
        {
            tasks.Add(Task.Run(() => CalculateCRC32Hash(bytes, progress)));
        }
        else
        {
            tasks.Add(Task.Run(() => string.Empty));
        }

        if (this.elf32CheckBox.Checked)
        {
            tasks.Add(Task.Run(() => CalculateELF32Hash(bytes, progress)));
        }
        else
        {
            tasks.Add(Task.Run(() => string.Empty));
        }

        if (this.md5CheckBox.Checked)
        {
            tasks.Add(Task.Run(() => CalculateMD5Hash(bytes, progress)));
        }
        else
        {
            tasks.Add(Task.Run(() => string.Empty));
        }

        if (this.sha1CheckBox.Checked)
        {
            tasks.Add(Task.Run(() => CalculateSHA1Hash(bytes, progress)));
        }
        else
        {
            tasks.Add(Task.Run(() => string.Empty));
        }

        if (this.sha256CheckBox.Checked)
        {
            tasks.Add(Task.Run(() => CalculateSHA256Hash(bytes, progress)));
        }
        else
        {
            tasks.Add(Task.Run(() => string.Empty));
        }

        if (this.sha384CheckBox.Checked)
        {
            tasks.Add(Task.Run(() => CalculateSHA384Hash(bytes, progress)));
        }
        else
        {
            tasks.Add(Task.Run(() => string.Empty));
        }

        if (this.sha512CheckBox.Checked)
        {
            tasks.Add(Task.Run(() => CalculateSHA512Hash(bytes, progress)));
        }
        else
        {
            tasks.Add(Task.Run(() => string.Empty));
        }

        // wait till tasks finish executing
        string[]? tasksResults = await Task.WhenAll(tasks);

        this.crc32TextBox.Text = tasksResults[0];
        this.elf32TextBox.Text = tasksResults[1];
        this.md5TextBox.Text = tasksResults[2];
        this.sha1TextBox.Text = tasksResults[3];
        this.sha256TextBox.Text = tasksResults[4];
        this.sha384TextBox.Text = tasksResults[5];
        this.sha512TextBox.Text = tasksResults[6];
    }

    private int GetTasksTotal()
    {
        int tasks = 0;

        if (this.crc32CheckBox.Checked)
        {
            tasks++;
        }

        if (this.elf32CheckBox.Checked)
        {
            tasks++;
        }

        if (this.md5CheckBox.Checked)
        {
            tasks++;
        }

        if (this.sha1CheckBox.Checked)
        {
            tasks++;
        }

        if (this.sha256CheckBox.Checked)
        {
            tasks++;
        }

        if (this.sha384CheckBox.Checked)
        {
            tasks++;
        }

        if (this.sha512CheckBox.Checked)
        {
            tasks++;
        }

        return tasks;
    }

    private static string CalculateCRC32Hash(byte[] data, IProgress<int> progress)
    {
        var crc32 = new Crc32();

        byte[] hashValue = crc32.ComputeHash(data);

        // Use progress to notify UI thread that progress has changed
        if (progress != null)
        {
            progress.Report(1);
        }

        return BitConverter.ToString(hashValue).Replace("-", string.Empty).ToUpper();
    }

    private static string CalculateELF32Hash(byte[] data, IProgress<int> progress)
    {
        var elf32 = new Elf32();

        byte[] hashValue = elf32.ComputeHash(data);

        if (progress != null)
        {
            progress.Report(1);
        }

        return BitConverter.ToString(hashValue).Replace("-", string.Empty).ToUpper();
    }

    private static string CalculateMD5Hash(byte[] data, IProgress<int> progress)
    {
        var md5 = MD5.Create();

        byte[] hashValue = md5.ComputeHash(data);

        if (progress != null)
        {
            progress.Report(1);
        }

        return BitConverter.ToString(hashValue).Replace("-", string.Empty).ToUpper();
    }

    private static string CalculateSHA1Hash(byte[] data, IProgress<int> progress)
    {
        var sha1 = SHA1.Create();

        byte[] hashValue = sha1.ComputeHash(data);

        if (progress != null)
        {
            progress.Report(1);
        }

        return BitConverter.ToString(hashValue).Replace("-", string.Empty).ToUpper();
    }

    private static string CalculateSHA256Hash(byte[] data, IProgress<int> progress)
    {
        var sha256 = SHA256.Create();

        byte[] hashValue = sha256.ComputeHash(data);

        if (progress != null)
        {
            progress.Report(1);
        }

        return BitConverter.ToString(hashValue).Replace("-", string.Empty).ToUpper();
    }

    private static string CalculateSHA384Hash(byte[] data, IProgress<int> progress)
    {
        var sha384 = SHA384.Create();

        byte[] hashValue = sha384.ComputeHash(data);

        if (progress != null)
        {
            progress.Report(1);
        }

        return BitConverter.ToString(hashValue).Replace("-", string.Empty).ToUpper();
    }

    private static string CalculateSHA512Hash(byte[] data, IProgress<int> progress)
    {
        var sha512 = SHA512.Create();

        byte[] hashValue = sha512.ComputeHash(data);

        if (progress != null)
        {
            progress.Report(1);
        }

        return BitConverter.ToString(hashValue).Replace("-", string.Empty).ToUpper();
    }

    private void ClearTextBoxes()
    {
        this.crc32TextBox.Text = string.Empty;
        this.elf32TextBox.Text = string.Empty;
        this.md5TextBox.Text = string.Empty;
        this.sha1TextBox.Text = string.Empty;
        this.sha256TextBox.Text = string.Empty;
        this.sha384TextBox.Text = string.Empty;
        this.sha512TextBox.Text = string.Empty;
    }

    private void ClearAllButton_Click(object sender, EventArgs e)
    {
        this.openSingleFileNameLabel.Text = "No file selected";
        this.executionStatusLabel.Text = "Nothing to execute";

        this.openFileBytes = null;

        this.ClearTextBoxes();

        this.progressBar.Value = 0;

        // Initiate garbage collector
        GC.Collect();
    }

    private void ResultsButton_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.crc32TextBox.Text) ||
            !string.IsNullOrEmpty(this.elf32TextBox.Text) ||
            !string.IsNullOrEmpty(this.md5TextBox.Text) ||
            !string.IsNullOrEmpty(this.sha1TextBox.Text) ||
            !string.IsNullOrEmpty(this.sha256TextBox.Text) ||
            !string.IsNullOrEmpty(this.sha384TextBox.Text) ||
            !string.IsNullOrEmpty(this.sha512TextBox.Text))
        {
            MessageBox.Show($"File: {this.openSingleFileNameLabel.Text}\n" +
                            $"CRC32: {this.crc32TextBox.Text}\n" +
                            $"ELF32: {this.elf32TextBox.Text}\n" +
                            $"MD5: {this.md5TextBox.Text}\n" +
                            $"SHA-1: {this.sha1TextBox.Text}\n" +
                            $"SHA-256: {this.sha256TextBox.Text}\n" +
                            $"SHA-384: {this.sha384TextBox.Text}\n" +
                            $"SHA-512: {this.sha512TextBox.Text}", "File Hash Results", MessageBoxButtons.OK);
        }
        else
        {
            MessageBox.Show("Nothing to show", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void SelectAllCheckBox_Click(object sender, EventArgs e)
    {
        if (this.selectAllCheckBox.CheckState == CheckState.Checked)
        {
            this.crc32CheckBox.Checked = true;
            this.elf32CheckBox.Checked = true;
            this.md5CheckBox.Checked = true;
            this.sha1CheckBox.Checked = true;
            this.sha256CheckBox.Checked = true;
            this.sha384CheckBox.Checked = true;
            this.sha512CheckBox.Checked = true;
        }
        else if (this.selectAllCheckBox.CheckState == CheckState.Unchecked)
        {
            this.crc32CheckBox.Checked = false;
            this.elf32CheckBox.Checked = false;
            this.md5CheckBox.Checked = false;
            this.sha1CheckBox.Checked = false;
            this.sha256CheckBox.Checked = false;
            this.sha384CheckBox.Checked = false;
            this.sha512CheckBox.Checked = false;
        }

        this.UpdateSettings();
    }

    private void SelectedCheckBox_Click(object sender, EventArgs e)
    {
        this.selectAllCheckBox.CheckState = this.crc32CheckBox.Checked &&
            this.elf32CheckBox.Checked &&
            this.md5CheckBox.Checked &&
            this.sha1CheckBox.Checked &&
            this.sha256CheckBox.Checked &&
            this.sha384CheckBox.Checked &&
            this.sha512CheckBox.Checked
            ? CheckState.Checked
            : this.crc32CheckBox.Checked ||
                                 this.elf32CheckBox.Checked ||
                                 this.md5CheckBox.Checked ||
                                 this.sha1CheckBox.Checked ||
                                 this.sha256CheckBox.Checked ||
                                 this.sha384CheckBox.Checked ||
                                 this.sha512CheckBox.Checked
                ? CheckState.Indeterminate
                : CheckState.Unchecked;

        this.UpdateSettings();
    }

    private void UpdateSettings()
    {
        AppSettings.Crc32Checked = this.crc32CheckBox.Checked;
        AppSettings.Elf32Checked = this.elf32CheckBox.Checked;
        AppSettings.Md5Checked = this.md5CheckBox.Checked;
        AppSettings.Sha1Checked = this.sha1CheckBox.Checked;
        AppSettings.Sha256Checked = this.sha256CheckBox.Checked;
        AppSettings.Sha384Checked = this.sha384CheckBox.Checked;
        AppSettings.Sha512Checked = this.sha512CheckBox.Checked;
    }
}
