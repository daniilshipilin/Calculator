namespace Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Calculator.Helpers;

    public partial class RandomNumberGeneratorForm : Form
    {
        private const int COMBINATIONS_LIMIT = 1000000;

        public string QtyTextBoxText
        {
            get => this.qtyTextBox.Text;

            set => this.qtyTextBox.Text = value;
        }

        public string MinTextBoxText
        {
            get => this.minTextBox.Text;

            set => this.minTextBox.Text = value;
        }

        public string MaxTextBoxText
        {
            get => this.maxTextBox.Text;

            set => this.maxTextBox.Text = value;
        }

        public string OutputTextBoxText
        {
            get => this.outputTextBox.Text;

            set => this.outputTextBox.Text = value;
        }

        public string ToolStripStatusLabelText
        {
            get => this.toolStripStatusLabel.Text;

            set => this.toolStripStatusLabel.Text = value;
        }

        // random number buffer
        private int[]? _rndNumbers;

        // Quantity, Min & Max values
        private int _qty = 0;
        private int _minVal = 0;
        private int _maxVal = 0;

        public RandomNumberGeneratorForm()
        {
            this.InitializeComponent();
        }

        private void RandomNumberGeneratorForm_Load(object sender, EventArgs e)
        {
            // textbox tooltips
            this.randomNumberGeneratorFormToolTip.SetToolTip(this.minTextBox, "Random number min value (inclusive) - X pixels");
            this.randomNumberGeneratorFormToolTip.SetToolTip(this.maxTextBox, "Random number max value (exclusive) - Y pixels");
            this.randomNumberGeneratorFormToolTip.SetToolTip(this.rngCheckBox, "Use RNGCryptoServiceProvider(), instead of Random()");

            this.QtyTextBoxText = AppSettings.RandomQty.ToString();
            this.MinTextBoxText = AppSettings.RandomMin.ToString();
            this.MaxTextBoxText = AppSettings.RandomMax.ToString();

            this.TopMost = AppSettings.TopMost;
        }

        private void RandomNumberGeneratorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private async void GenerateButtonAsync_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.QtyTextBoxText) ||
                string.IsNullOrEmpty(this.MinTextBoxText) ||
                string.IsNullOrEmpty(this.MaxTextBoxText))
            {
                MessageBox.Show("Qty, min or max value(s) missing", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                this._qty = int.Parse(this.QtyTextBoxText);
                this._minVal = int.Parse(this.MinTextBoxText);
                this._maxVal = int.Parse(this.MaxTextBoxText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (this._qty is <= 0 or > COMBINATIONS_LIMIT)
            {
                MessageBox.Show("Qty must be a positive integer and not greater than 1M", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (this._maxVal <= this._minVal)
            {
                MessageBox.Show("Min must be less than max value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            this.Clear();

            this.generateButton.Enabled = false;
            this.ToolStripStatusLabelText = "Executing...";

            var stopWatch = Stopwatch.StartNew();

            await this.RandomNumberTaskAsync();

            stopWatch.Stop();
            long elapsedMs = stopWatch.ElapsedMilliseconds;

            this.ToolStripStatusLabelText = $"Elapsed(ms): {elapsedMs}";

            // reset values
            this._qty = this._minVal = this._maxVal = 0;

            this.generateButton.Enabled = true;
        }

        private async Task RandomNumberTaskAsync()
        {
            this.progressBar.Style = ProgressBarStyle.Marquee;

            // This lambda is executed in context of UI thread, so it can safely update form controls
            var progress = new Progress<int>(v => { this.progressBar.MarqueeAnimationSpeed = v; });

            // create list of tasks
            var tasks = new List<Task>
            {
                Task.Run(() => this.GenerateRandomNumbers(progress))
            };

            // wait till tasks finish executing
            await Task.WhenAll(tasks);

            if (this._rndNumbers is not null)
            {
                this.OutputTextBoxText = string.Join(Environment.NewLine, this._rndNumbers);
            }

            this.progressBar.Style = ProgressBarStyle.Blocks;
            this.progressBar.Value = 100;
        }

        private void GenerateRandomNumbers(IProgress<int> progress)
        {
            this._rndNumbers = new int[this._qty];
            progress.Report(100);
            INumberGenerator rnd;

            if (this.rngCheckBox.Checked)
            {
                // using RNGCryptoServiceProvider
                rnd = new RNGNumberGenerator();
            }
            else
            {
                // using Random
                rnd = new RandomNumberGenerator();
            }

            for (int i = 0; i < this._qty; i++)
            {
                this._rndNumbers[i] = rnd.GetInt32(this._minVal, this._maxVal);
            }

            progress.Report(0);
        }

        private void ClearButton_Click(object sender, EventArgs e) => this.Clear();

        private void Clear()
        {
            this.OutputTextBoxText = string.Empty;

            // reset current progress bar value
            this.progressBar.Value = 0;

            this.ToolStripStatusLabelText = string.Empty;

            this._rndNumbers = null;

            // Initiate garbage collector
            GC.Collect();
        }

        private void OutputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                this.outputTextBox.SelectAll();
            }
        }

        private void QtyTextBox_TextChanged(object sender, EventArgs e) => AppSettings.RandomQty = int.Parse(this.QtyTextBoxText);

        private void MinTextBox_TextChanged(object sender, EventArgs e) => AppSettings.RandomMin = int.Parse(this.MinTextBoxText);

        private void MaxTextBox_TextChanged(object sender, EventArgs e) => AppSettings.RandomMax = int.Parse(this.MaxTextBoxText);

        private void GenerateRandomPictureButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.MinTextBoxText, out int x_width) || x_width <= 0)
            {
                MessageBox.Show("X value not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(this.MaxTextBoxText, out int y_height) || y_height <= 0)
            {
                MessageBox.Show("Y value not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var stopWatch = Stopwatch.StartNew();
            var bmp = new Bitmap(x_width, y_height);
            INumberGenerator rnd;

            if (this.rngCheckBox.Checked)
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
            long elapsedMs = stopWatch.ElapsedMilliseconds;

            this.ToolStripStatusLabelText = $"Elapsed(ms): {elapsedMs}";

            var dialogResult = MessageBox.Show("Save generated bitmap to a file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            using var pictureForm = new Form
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
                TopMost = AppSettings.TopMost,
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
