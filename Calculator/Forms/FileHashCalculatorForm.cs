namespace Calculator
{
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
        public string OpenSingleFileNameLabelText
        {
            get => this.openSingleFileNameLabel.Text;

            set => this.openSingleFileNameLabel.Text = value;
        }

        public string Crc32TextBoxText
        {
            get => this.crc32TextBox.Text;

            set => this.crc32TextBox.Text = value;
        }

        public string Elf32TextBoxText
        {
            get => this.elf32TextBox.Text;

            set => this.elf32TextBox.Text = value;
        }

        public string Md5TextBoxText
        {
            get => this.md5TextBox.Text;

            set => this.md5TextBox.Text = value;
        }

        public string Sha1TextBoxText
        {
            get => this.sha1TextBox.Text;

            set => this.sha1TextBox.Text = value;
        }

        public string Sha256TextBoxText
        {
            get => this.sha256TextBox.Text;

            set => this.sha256TextBox.Text = value;
        }

        public string Sha384TextBoxText
        {
            get => this.sha384TextBox.Text;

            set => this.sha384TextBox.Text = value;
        }

        public string Sha512TextBoxText
        {
            get => this.sha512TextBox.Text;

            set => this.sha512TextBox.Text = value;
        }

        public string ExecutionStatusLabelText
        {
            get => this.executionStatusLabel.Text;

            set => this.executionStatusLabel.Text = value;
        }

        // buffer to store file contents
        private byte[]? _openFileBytes;

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

            this.OpenSingleFileNameLabelText = "No file selected";
            this.ExecutionStatusLabelText = "Nothing to execute";

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
                    this._openFileBytes = await Task.Run(() => br.ReadBytes((int)br.BaseStream.Length));

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

                this.OpenSingleFileNameLabelText = this.openSingleFileDialog.FileName;
            }
        }

        private async void CalculateHashesAsyncButton_Click(object sender, EventArgs e)
        {
            if (this._openFileBytes == null)
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
                this.ExecutionStatusLabelText = "Calculating hash(es)";

                var stopWatch = Stopwatch.StartNew();

                await this.CalculateHashesParallelAsync(this._openFileBytes);

                stopWatch.Stop();
                long elapsedMs = stopWatch.ElapsedMilliseconds;

                this.calculateHashesButton.Enabled = true;
                this.ExecutionStatusLabelText = $"Done - Elapsed(ms): {elapsedMs}";
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

            this.Crc32TextBoxText = tasksResults[0];
            this.Elf32TextBoxText = tasksResults[1];
            this.Md5TextBoxText = tasksResults[2];
            this.Sha1TextBoxText = tasksResults[3];
            this.Sha256TextBoxText = tasksResults[4];
            this.Sha384TextBoxText = tasksResults[5];
            this.Sha512TextBoxText = tasksResults[6];
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
            this.Crc32TextBoxText = string.Empty;
            this.Elf32TextBoxText = string.Empty;
            this.Md5TextBoxText = string.Empty;
            this.Sha1TextBoxText = string.Empty;
            this.Sha256TextBoxText = string.Empty;
            this.Sha384TextBoxText = string.Empty;
            this.Sha512TextBoxText = string.Empty;
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            this.OpenSingleFileNameLabelText = "No file selected";
            this.ExecutionStatusLabelText = "Nothing to execute";

            this._openFileBytes = null;

            this.ClearTextBoxes();

            this.progressBar.Value = 0;

            // Initiate garbage collector
            GC.Collect();
        }

        private void ResultsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Crc32TextBoxText) ||
                !string.IsNullOrEmpty(this.Elf32TextBoxText) ||
                !string.IsNullOrEmpty(this.Md5TextBoxText) ||
                !string.IsNullOrEmpty(this.Sha1TextBoxText) ||
                !string.IsNullOrEmpty(this.Sha256TextBoxText) ||
                !string.IsNullOrEmpty(this.Sha384TextBoxText) ||
                !string.IsNullOrEmpty(this.Sha512TextBoxText))
            {
                MessageBox.Show($"File: {this.OpenSingleFileNameLabelText}\n" +
                                $"CRC32: {this.Crc32TextBoxText}\n" +
                                $"ELF32: {this.Elf32TextBoxText}\n" +
                                $"MD5: {this.Md5TextBoxText}\n" +
                                $"SHA-1: {this.Sha1TextBoxText}\n" +
                                $"SHA-256: {this.Sha256TextBoxText}\n" +
                                $"SHA-384: {this.Sha384TextBoxText}\n" +
                                $"SHA-512: {this.Sha512TextBoxText}", "File Hash Results", MessageBoxButtons.OK);
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
}
