using Calculator.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class RandomNumberGeneratorForm : Form
    {
        #region Public properties

        public string QtyTextBoxText
        {
            get { return (qtyTextBox.Text); }
            set { qtyTextBox.Text = value; }
        }

        public string MinTextBoxText
        {
            get { return (minTextBox.Text); }
            set { minTextBox.Text = value; }
        }

        public string MaxTextBoxText
        {
            get { return (maxTextBox.Text); }
            set { maxTextBox.Text = value; }
        }

        public string OutputTextBoxText
        {
            get { return (outputTextBox.Text); }
            set { outputTextBox.Text = value; }
        }

        public string ToolStripStatusLabelText
        {
            get { return (toolStripStatusLabel.Text); }
            set { toolStripStatusLabel.Text = value; }
        }

        #endregion

        #region AppSettings

        static readonly List<string> _keys = new List<string>
        {
            "RandomQty",
            "RandomMin",
            "RandomMax"
        };

        #endregion

        #region Private fields

        // random number buffer
        int[] _rndNumbers = null;

        // Quantity, Min & Max values
        int _qty = 0;
        int _minVal = 0;
        int _maxVal = 0;

        // flag to activate settings update
        bool _settingsUpdateEnabled = false;

        #endregion

        #region Constants

        const int COMBINATIONS_LIMIT = 1000000;

        #endregion

        public RandomNumberGeneratorForm()
        {
            InitializeComponent();
        }

        private void RandomNumberGeneratorForm_Load(object sender, EventArgs e)
        {
            // textbox tooltips
            randomNumberGeneratorFormToolTip.SetToolTip(minTextBox, "Random number min value (inclusive) - X pixels");
            randomNumberGeneratorFormToolTip.SetToolTip(maxTextBox, "Random number max value (exclusive) - Y pixels");
            randomNumberGeneratorFormToolTip.SetToolTip(rngCheckBox, "Use RNGCryptoServiceProvider(), instead of Random()");

            // default values
            QtyTextBoxText = "1000";
            MinTextBoxText = "-1000000";
            MaxTextBoxText = "1000000";

            // configuration check
            if (AppSettings.AssemblyExist())
            {
                if (AppSettings.KeyExist(_keys[0]))
                {
                    QtyTextBoxText = AppSettings.ReadKey(_keys[0]);
                }

                if (AppSettings.KeyExist(_keys[1]))
                {
                    MinTextBoxText = AppSettings.ReadKey(_keys[1]);
                }

                if (AppSettings.KeyExist(_keys[2]))
                {
                    MaxTextBoxText = AppSettings.ReadKey(_keys[2]);
                }
            }

            _settingsUpdateEnabled = true;

            TopMost = Program.GlobalTopMost;
        }

        private void RandomNumberGeneratorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private async void GenerateButtonAsync_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(QtyTextBoxText) ||
                string.IsNullOrEmpty(MinTextBoxText) ||
                string.IsNullOrEmpty(MaxTextBoxText))
            {
                MessageBox.Show("Qty, min or max value(s) missing", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                _qty = int.Parse(QtyTextBoxText);
                _minVal = int.Parse(MinTextBoxText);
                _maxVal = int.Parse(MaxTextBoxText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (_qty <= 0 || _qty > COMBINATIONS_LIMIT)
            {
                MessageBox.Show("Qty must be a positive integer and not greater than 1M", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (_maxVal <= _minVal)
            {
                MessageBox.Show("Min must be less than max value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            Clear();

            generateButton.Enabled = false;
            ToolStripStatusLabelText = "Executing...";

            var stopWatch = Stopwatch.StartNew();

            await RandomNumberTaskAsync();

            stopWatch.Stop();
            var elapsedMs = stopWatch.ElapsedMilliseconds;

            ToolStripStatusLabelText = $"Elapsed(ms): {elapsedMs}";

            // reset values
            _qty = _minVal = _maxVal = 0;

            generateButton.Enabled = true;
        }

        private async Task RandomNumberTaskAsync()
        {
            progressBar.Style = ProgressBarStyle.Marquee;

            // This lambda is executed in context of UI thread, so it can safely update form controls
            var progress = new Progress<int>(v => { progressBar.MarqueeAnimationSpeed = v; });

            // create list of tasks
            List<Task> tasks = new List<Task>
            {
                Task.Run(() => GenerateRandomNumbers(progress))
            };

            // wait till tasks finish executing
            await Task.WhenAll(tasks);

            OutputTextBoxText = string.Join(Environment.NewLine, _rndNumbers);

            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 100;
        }

        private void GenerateRandomNumbers(IProgress<int> progress)
        {
            _rndNumbers = new int[_qty];
            progress.Report(100);
            INumberGenerator rnd;

            if (rngCheckBox.Checked)
            {
                // using RNGCryptoServiceProvider
                rnd = new RNGNumberGenerator();
            }
            else
            {
                // using Random
                rnd = new RandomNumberGenerator();
            }

            for (int i = 0; i < _qty; i++)
            {
                _rndNumbers[i] = rnd.GetInt32(_minVal, _maxVal);
            }

            progress.Report(0);
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

            _rndNumbers = null;

            // Initiate garbage collector
            GC.Collect();
        }

        private void OutputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                outputTextBox.SelectAll();
            }
        }

        private void QtyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_settingsUpdateEnabled)
            {
                UpdateSettings(_keys[0]);
            }
        }

        private void MinTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_settingsUpdateEnabled)
            {
                UpdateSettings(_keys[1]);
            }
        }

        private void MaxTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_settingsUpdateEnabled)
            {
                UpdateSettings(_keys[2]);
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
                    else if (MinTextBoxText != AppSettings.ReadKey(_keys[1]))
                    {
                        AppSettings.UpdateKey(key, MinTextBoxText);
                    }
                    else if (MaxTextBoxText != AppSettings.ReadKey(_keys[2]))
                    {
                        AppSettings.UpdateKey(key, MaxTextBoxText);
                    }
                }
            }
        }

        private void GenerateRandomPictureButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(MinTextBoxText, out int x_width) || x_width <= 0)
            {
                MessageBox.Show("X value not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(MaxTextBoxText, out int y_height) || y_height <= 0)
            {
                MessageBox.Show("Y value not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var stopWatch = Stopwatch.StartNew();
            var bmp = new Bitmap(x_width, y_height);
            INumberGenerator rnd;

            if (rngCheckBox.Checked)
            {
                // using RNGCryptoServiceProvider
                rnd = new RNGNumberGenerator();
            }
            else
            {
                // using Random
                rnd = new RandomNumberGenerator();
            }

            // create random pixels
            for (int y = 0; y < y_height; y++)
            {
                for (int x = 0; x < x_width; x++)
                {
                    byte[] argb = new byte[4];

                    // generate random ARGB value by filling byte array
                    rnd.FillBytes(argb);

                    // set ARGB value
                    bmp.SetPixel(x, y, Color.FromArgb(argb[0], argb[1], argb[2], argb[3]));
                }
            }

            stopWatch.Stop();
            var elapsedMs = stopWatch.ElapsedMilliseconds;

            ToolStripStatusLabelText = $"Elapsed(ms): {elapsedMs}";

            DialogResult dialogResult = MessageBox.Show("Save generated bitmap to a file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // file format to store the bitmap
                var fileFormat = ImageFormat.Png;
                string fileName = $"{AppDomain.CurrentDomain.BaseDirectory}RandomImage_{DateTime.Now:yyyyMMddHHmmss}.{fileFormat.ToString().ToLower()}";

                try
                {
                    // save random pixel image
                    bmp.Save(fileName, fileFormat);

                    MessageBox.Show($"File saved as {fileName}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // create new form
            using Form pictureForm = new Form
            {
                Text = $"Random Image {x_width}x{y_height}",
                Width = x_width,
                Height = y_height,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                ShowIcon = false,
                MinimizeBox = false,
                MaximizeBox = false,
                TopMost = Program.GlobalTopMost
            };

            // container for generated bitmap
            var pictureBox = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(x_width, y_height),
                Location = new Point(),
                Image = bmp
            };

            pictureForm.Controls.Add(pictureBox);

            // show random generated bitmap
            pictureForm.ShowDialog();
        }
    }
}
