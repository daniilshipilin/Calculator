using Calculator.Helpers;
using DamienG.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FileHashCalculatorForm : Form
    {
        #region Public properties

        public string OpenSingleFileNameLabelText
        {
            get { return (openSingleFileNameLabel.Text); }
            set { openSingleFileNameLabel.Text = value; }
        }

        public string Crc32TextBoxText
        {
            get { return (crc32TextBox.Text); }
            set { crc32TextBox.Text = value; }
        }

        public string Elf32TextBoxText
        {
            get { return (elf32TextBox.Text); }
            set { elf32TextBox.Text = value; }
        }

        public string Md5TextBoxText
        {
            get { return (md5TextBox.Text); }
            set { md5TextBox.Text = value; }
        }

        public string Sha1TextBoxText
        {
            get { return (sha1TextBox.Text); }
            set { sha1TextBox.Text = value; }
        }

        public string Sha256TextBoxText
        {
            get { return (sha256TextBox.Text); }
            set { sha256TextBox.Text = value; }
        }

        public string Sha384TextBoxText
        {
            get { return (sha384TextBox.Text); }
            set { sha384TextBox.Text = value; }
        }

        public string Sha512TextBoxText
        {
            get { return (sha512TextBox.Text); }
            set { sha512TextBox.Text = value; }
        }

        public string ExecutionStatusLabelText
        {
            get { return (executionStatusLabel.Text); }
            set { executionStatusLabel.Text = value; }
        }

        #endregion

        #region AppSettings

        static readonly List<string> _keys = new List<string>
        {
            "Crc32Checked",
            "Elf32Checked",
            "Md5Checked",
            "Sha1Checked",
            "Sha256Checked",
            "Sha384Checked",
            "Sha512Checked"
        };

        #endregion

        #region Private fields

        // buffer to store file contents
        byte[] _openFileBytes = null;

        // flag to activate settings update
        bool _settingsUpdateEnabled = false;

        #endregion

        public FileHashCalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculateFileHashForm_Load(object sender, EventArgs e)
        {
            // textbox tooltips
            calculateFileHashFormToolTip.SetToolTip(crc32TextBox, "A 32-bit CRC hash algorithm.");
            calculateFileHashFormToolTip.SetToolTip(elf32TextBox, "A 32-bit ELF hash algorithm compatible with ELF binary format.");
            calculateFileHashFormToolTip.SetToolTip(md5TextBox, "A 128-bit MD5 hash algorithm.");
            calculateFileHashFormToolTip.SetToolTip(sha1TextBox, "A 160-bit SHA-1 cryptographic hash function.");
            calculateFileHashFormToolTip.SetToolTip(sha256TextBox, "A 256-bit SHA-2 cryptographic hash function.");
            calculateFileHashFormToolTip.SetToolTip(sha384TextBox, "A 384-bit SHA-2 cryptographic hash function.");
            calculateFileHashFormToolTip.SetToolTip(sha512TextBox, "A 512-bit SHA-2 cryptographic hash function.");

            OpenSingleFileNameLabelText = "No file selected";
            ExecutionStatusLabelText = "Nothing to execute";

            // configuration check
            if (AppSettings.AssemblyExist())
            {
                if (AppSettings.KeyExist(_keys[0]))
                {
                    crc32CheckBox.Checked = AppSettings.ReadKey("Crc32Checked").Equals("True") ? true : false;
                }

                if (AppSettings.KeyExist(_keys[1]))
                {
                    elf32CheckBox.Checked = AppSettings.ReadKey("Elf32Checked").Equals("True") ? true : false;
                }

                if (AppSettings.KeyExist(_keys[2]))
                {
                    md5CheckBox.Checked = AppSettings.ReadKey("Md5Checked").Equals("True") ? true : false;
                }

                if (AppSettings.KeyExist(_keys[3]))
                {
                    sha1CheckBox.Checked = AppSettings.ReadKey("Sha1Checked").Equals("True") ? true : false;
                }

                if (AppSettings.KeyExist(_keys[4]))
                {
                    sha256CheckBox.Checked = AppSettings.ReadKey("Sha256Checked").Equals("True") ? true : false;
                }

                if (AppSettings.KeyExist(_keys[5]))
                {
                    sha384CheckBox.Checked = AppSettings.ReadKey("Sha384Checked").Equals("True") ? true : false;
                }

                if (AppSettings.KeyExist(_keys[6]))
                {
                    sha512CheckBox.Checked = AppSettings.ReadKey("Sha512Checked").Equals("True") ? true : false;
                }
            }

            _settingsUpdateEnabled = true;

            TopMost = Program.GlobalTopMost;
        }

        private void CalculateFileHashForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private async void OpenSingleFileAsyncButton_Click(object sender, EventArgs e)
        {
            await OpenSingleFileAsync();
        }

        private async Task OpenSingleFileAsync()
        {
            if (openSingleFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var br = new BinaryReader(File.Open(openSingleFileDialog.FileName, FileMode.Open, FileAccess.Read));

                    if (br.BaseStream.Length > int.MaxValue || br.BaseStream.Length == 0)
                    {
                        throw new IndexOutOfRangeException("File is empty or its size is bigger than 2GB");
                    }

                    // async method #1: using await
                    _openFileBytes = await Task.Run(() => br.ReadBytes((int)br.BaseStream.Length));

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

                ClearTextBoxes();

                OpenSingleFileNameLabelText = openSingleFileDialog.FileName;
            }
        }

        private async void CalculateHashesAsyncButton_Click(object sender, EventArgs e)
        {
            if (_openFileBytes == null)
            {
                MessageBox.Show("Select the file first", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (crc32CheckBox.Checked ||
                elf32CheckBox.Checked ||
                md5CheckBox.Checked ||
                sha1CheckBox.Checked ||
                sha256CheckBox.Checked ||
                sha384CheckBox.Checked ||
                sha512CheckBox.Checked)
            {
                ClearTextBoxes();

                calculateHashesButton.Enabled = false;
                ExecutionStatusLabelText = "Calculating hash(es)";

                var stopWatch = Stopwatch.StartNew();

                await CalculateHashesParallelAsync();

                stopWatch.Stop();
                var elapsedMs = stopWatch.ElapsedMilliseconds;

                calculateHashesButton.Enabled = true;
                ExecutionStatusLabelText = $"Done - Elapsed(ms): {elapsedMs}";
            }
            else
            {
                MessageBox.Show("No hashing method(s) selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task CalculateHashesParallelAsync()
        {
            // reset current progress bar value
            progressBar.Value = 0;
            progressBar.Maximum = GetTasksTotal();

            // This lambda is executed in context of UI thread, so it can safely update form controls
            var progress = new Progress<int>(v => { progressBar.Value += v; });

            // create list of tasks
            List<Task<string>> tasks = new List<Task<string>>();

            // multithreaded parallel execution
            if (crc32CheckBox.Checked) { tasks.Add(Task.Run(() => CalculateCRC32Hash(_openFileBytes, progress))); }
            else { tasks.Add(Task.Run(() => string.Empty)); }

            if (elf32CheckBox.Checked) { tasks.Add(Task.Run(() => CalculateELF32Hash(_openFileBytes, progress))); }
            else { tasks.Add(Task.Run(() => string.Empty)); }

            if (md5CheckBox.Checked) { tasks.Add(Task.Run(() => CalculateMD5Hash(_openFileBytes, progress))); }
            else { tasks.Add(Task.Run(() => string.Empty)); }

            if (sha1CheckBox.Checked) { tasks.Add(Task.Run(() => CalculateSHA1Hash(_openFileBytes, progress))); }
            else { tasks.Add(Task.Run(() => string.Empty)); }

            if (sha256CheckBox.Checked) { tasks.Add(Task.Run(() => CalculateSHA256Hash(_openFileBytes, progress))); }
            else { tasks.Add(Task.Run(() => string.Empty)); }

            if (sha384CheckBox.Checked) { tasks.Add(Task.Run(() => CalculateSHA384Hash(_openFileBytes, progress))); }
            else { tasks.Add(Task.Run(() => string.Empty)); }

            if (sha512CheckBox.Checked) { tasks.Add(Task.Run(() => CalculateSHA512Hash(_openFileBytes, progress))); }
            else { tasks.Add(Task.Run(() => string.Empty)); }

            // wait till tasks finish executing
            var tasksResults = await Task.WhenAll(tasks);

            if (crc32CheckBox.Checked) { Crc32TextBoxText = tasksResults[0]; }

            if (elf32CheckBox.Checked) { Elf32TextBoxText = tasksResults[1]; }

            if (md5CheckBox.Checked) { Md5TextBoxText = tasksResults[2]; }

            if (sha1CheckBox.Checked) { Sha1TextBoxText = tasksResults[3]; }

            if (sha256CheckBox.Checked) { Sha256TextBoxText = tasksResults[4]; }

            if (sha384CheckBox.Checked) { Sha384TextBoxText = tasksResults[5]; }

            if (sha512CheckBox.Checked) { Sha512TextBoxText = tasksResults[6]; }
        }

        private int GetTasksTotal()
        {
            int tasks = 0;

            if (crc32CheckBox.Checked) { tasks++; }

            if (elf32CheckBox.Checked) { tasks++; }

            if (md5CheckBox.Checked) { tasks++; }

            if (sha1CheckBox.Checked) { tasks++; }

            if (sha256CheckBox.Checked) { tasks++; }

            if (sha384CheckBox.Checked) { tasks++; }

            if (sha512CheckBox.Checked) { tasks++; }

            return (tasks);
        }

        #region Hashing methods

        private string CalculateCRC32Hash(byte[] data, IProgress<int> progress)
        {
            var crc32 = new Crc32();

            byte[] hashValue = crc32.ComputeHash(data);

            // Use progress to notify UI thread that progress has changed
            if (progress != null)
            {
                progress.Report(1);
            }

            return (BitConverter.ToString(hashValue).Replace("-", String.Empty).ToUpper());
        }

        private string CalculateELF32Hash(byte[] data, IProgress<int> progress)
        {
            var elf32 = new Elf32();

            byte[] hashValue = elf32.ComputeHash(data);

            if (progress != null)
            {
                progress.Report(1);
            }

            return (BitConverter.ToString(hashValue).Replace("-", String.Empty).ToUpper());
        }

        private string CalculateMD5Hash(byte[] data, IProgress<int> progress)
        {
            var md5 = MD5.Create();

            byte[] hashValue = md5.ComputeHash(data);

            if (progress != null)
            {
                progress.Report(1);
            }

            return (BitConverter.ToString(hashValue).Replace("-", String.Empty).ToUpper());
        }

        private string CalculateSHA1Hash(byte[] data, IProgress<int> progress)
        {
            var sha1 = SHA1.Create();

            byte[] hashValue = sha1.ComputeHash(data);

            if (progress != null)
            {
                progress.Report(1);
            }

            return (BitConverter.ToString(hashValue).Replace("-", String.Empty).ToUpper());
        }

        private string CalculateSHA256Hash(byte[] data, IProgress<int> progress)
        {
            var sha256 = SHA256.Create();

            byte[] hashValue = sha256.ComputeHash(data);

            if (progress != null)
            {
                progress.Report(1);
            }

            return (BitConverter.ToString(hashValue).Replace("-", String.Empty).ToUpper());
        }

        private string CalculateSHA384Hash(byte[] data, IProgress<int> progress)
        {
            var sha384 = SHA384.Create();

            byte[] hashValue = sha384.ComputeHash(data);

            if (progress != null)
            {
                progress.Report(1);
            }

            return (BitConverter.ToString(hashValue).Replace("-", String.Empty).ToUpper());
        }

        private string CalculateSHA512Hash(byte[] data, IProgress<int> progress)
        {
            var sha512 = SHA512.Create();

            byte[] hashValue = sha512.ComputeHash(data);

            if (progress != null)
            {
                progress.Report(1);
            }

            return (BitConverter.ToString(hashValue).Replace("-", String.Empty).ToUpper());
        }

        #endregion

        private void ClearTextBoxes()
        {
            Crc32TextBoxText = string.Empty;
            Elf32TextBoxText = string.Empty;
            Md5TextBoxText = string.Empty;
            Sha1TextBoxText = string.Empty;
            Sha256TextBoxText = string.Empty;
            Sha384TextBoxText = string.Empty;
            Sha512TextBoxText = string.Empty;
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            OpenSingleFileNameLabelText = "No file selected";
            ExecutionStatusLabelText = "Nothing to execute";

            _openFileBytes = null;

            ClearTextBoxes();

            progressBar.Value = 0;

            // Initiate garbage collector
            GC.Collect();
        }

        private void ResultsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Crc32TextBoxText) ||
                !string.IsNullOrEmpty(Elf32TextBoxText) ||
                !string.IsNullOrEmpty(Md5TextBoxText) ||
                !string.IsNullOrEmpty(Sha1TextBoxText) ||
                !string.IsNullOrEmpty(Sha256TextBoxText) ||
                !string.IsNullOrEmpty(Sha384TextBoxText) ||
                !string.IsNullOrEmpty(Sha512TextBoxText))
            {
                MessageBox.Show($"File: {OpenSingleFileNameLabelText}\n" +
                                $"CRC32: {Crc32TextBoxText}\n" +
                                $"ELF32: {Elf32TextBoxText}\n" +
                                $"MD5: {Md5TextBoxText}\n" +
                                $"SHA-1: {Sha1TextBoxText}\n" +
                                $"SHA-256: {Sha256TextBoxText}\n" +
                                $"SHA-384: {Sha384TextBoxText}\n" +
                                $"SHA-512: {Sha512TextBoxText}", "File Hash Results", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Nothing to show", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SelectAllCheckBox_Click(object sender, EventArgs e)
        {
            if (selectAllCheckBox.CheckState == CheckState.Checked)
            {
                crc32CheckBox.Checked = true;
                elf32CheckBox.Checked = true;
                md5CheckBox.Checked = true;
                sha1CheckBox.Checked = true;
                sha256CheckBox.Checked = true;
                sha384CheckBox.Checked = true;
                sha512CheckBox.Checked = true;
            }
            else if (selectAllCheckBox.CheckState == CheckState.Unchecked)
            {
                crc32CheckBox.Checked = false;
                elf32CheckBox.Checked = false;
                md5CheckBox.Checked = false;
                sha1CheckBox.Checked = false;
                sha256CheckBox.Checked = false;
                sha384CheckBox.Checked = false;
                sha512CheckBox.Checked = false;
            }

            if (_settingsUpdateEnabled)
            {
                UpdateSettings();
            }
        }

        private void SelectedCheckBox_Click(object sender, EventArgs e)
        {
            if (crc32CheckBox.Checked &&
                elf32CheckBox.Checked &&
                md5CheckBox.Checked &&
                sha1CheckBox.Checked &&
                sha256CheckBox.Checked &&
                sha384CheckBox.Checked &&
                sha512CheckBox.Checked)
            {
                selectAllCheckBox.CheckState = CheckState.Checked;
            }
            else if (crc32CheckBox.Checked ||
                     elf32CheckBox.Checked ||
                     md5CheckBox.Checked ||
                     sha1CheckBox.Checked ||
                     sha256CheckBox.Checked ||
                     sha384CheckBox.Checked ||
                     sha512CheckBox.Checked)
            {
                selectAllCheckBox.CheckState = CheckState.Indeterminate;
            }
            else
            {
                selectAllCheckBox.CheckState = CheckState.Unchecked;
            }

            if (_settingsUpdateEnabled)
            {
                UpdateSettings();
            }
        }

        private void UpdateSettings()
        {
            // update settings
            if (AppSettings.AssemblyExist())
            {
                if (AppSettings.KeyExist(_keys[0]))
                {
                    if (crc32CheckBox.Checked.ToString() != AppSettings.ReadKey(_keys[0]))
                    {
                        AppSettings.UpdateKey(_keys[0], crc32CheckBox.Checked.ToString());
                    }
                }

                if (AppSettings.KeyExist(_keys[1]))
                {
                    if (elf32CheckBox.Checked.ToString() != AppSettings.ReadKey(_keys[1]))
                    {
                        AppSettings.UpdateKey(_keys[1], elf32CheckBox.Checked.ToString());
                    }
                }

                if (AppSettings.KeyExist(_keys[2]))
                {
                    if (md5CheckBox.Checked.ToString() != AppSettings.ReadKey(_keys[2]))
                    {
                        AppSettings.UpdateKey(_keys[2], md5CheckBox.Checked.ToString());
                    }
                }

                if (AppSettings.KeyExist(_keys[3]))
                {
                    if (sha1CheckBox.Checked.ToString() != AppSettings.ReadKey(_keys[3]))
                    {
                        AppSettings.UpdateKey(_keys[3], sha1CheckBox.Checked.ToString());
                    }
                }

                if (AppSettings.KeyExist(_keys[4]))
                {
                    if (sha256CheckBox.Checked.ToString() != AppSettings.ReadKey(_keys[4]))
                    {
                        AppSettings.UpdateKey(_keys[4], sha256CheckBox.Checked.ToString());
                    }
                }

                if (AppSettings.KeyExist(_keys[5]))
                {
                    if (sha384CheckBox.Checked.ToString() != AppSettings.ReadKey(_keys[5]))
                    {
                        AppSettings.UpdateKey(_keys[5], sha384CheckBox.Checked.ToString());
                    }
                }

                if (AppSettings.KeyExist(_keys[6]))
                {
                    if (sha512CheckBox.Checked.ToString() != AppSettings.ReadKey(_keys[6]))
                    {
                        AppSettings.UpdateKey(_keys[6], sha512CheckBox.Checked.ToString());
                    }
                }
            }
        }
    }
}
