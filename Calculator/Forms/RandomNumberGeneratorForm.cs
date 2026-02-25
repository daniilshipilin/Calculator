namespace Calculator.Forms;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Configuration;

public partial class RandomNumberGeneratorForm : Form
{
    private const int CombinationsLimit = 1000000;

    // random number buffer
    private int[]? rndNumbers;

    // Quantity, Min & Max values
    private int qty = 0;
    private int minVal = 0;
    private int maxVal = 0;

    public RandomNumberGeneratorForm()
    {
        this.InitializeComponent();
    }

    private void RandomNumberGeneratorForm_Load(object sender, EventArgs e)
    {
        // textbox tooltips
        this.randomNumberGeneratorFormToolTip.SetToolTip(this.minTextBox, "Random number min value (inclusive) - X pixels");
        this.randomNumberGeneratorFormToolTip.SetToolTip(this.maxTextBox, "Random number max value (exclusive) - Y pixels");

        this.qtyTextBox.Text = AppSettings.RandomQty.ToString();
        this.minTextBox.Text = AppSettings.RandomMin.ToString();
        this.maxTextBox.Text = AppSettings.RandomMax.ToString();
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
        if (string.IsNullOrEmpty(this.qtyTextBox.Text) ||
            string.IsNullOrEmpty(this.minTextBox.Text) ||
            string.IsNullOrEmpty(this.maxTextBox.Text))
        {
            MessageBox.Show("Qty, min or max value(s) missing", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return;
        }

        try
        {
            this.qty = int.Parse(this.qtyTextBox.Text);
            this.minVal = int.Parse(this.minTextBox.Text);
            this.maxVal = int.Parse(this.maxTextBox.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }

        if (this.qty is <= 0 or > CombinationsLimit)
        {
            MessageBox.Show("Qty must be a positive integer and not greater than 1M", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return;
        }

        if (this.maxVal <= this.minVal)
        {
            MessageBox.Show("Min must be less than max value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return;
        }

        this.Clear();

        this.generateButton.Enabled = false;
        this.toolStripStatusLabel.Text = "Executing...";

        var stopWatch = Stopwatch.StartNew();

        await this.RandomNumberTaskAsync();

        stopWatch.Stop();
        long elapsedMs = stopWatch.ElapsedMilliseconds;

        this.toolStripStatusLabel.Text = $"Elapsed(ms): {elapsedMs}";

        // reset values
        this.qty = this.minVal = this.maxVal = 0;

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

        if (this.rndNumbers is not null)
        {
            this.outputTextBox.Text = string.Join(Environment.NewLine, this.rndNumbers);
        }

        this.progressBar.Style = ProgressBarStyle.Blocks;
        this.progressBar.Value = 100;
    }

    private void GenerateRandomNumbers(IProgress<int> progress)
    {
        this.rndNumbers = new int[this.qty];
        progress.Report(100);

        for (int i = 0; i < this.qty; i++)
        {
            this.rndNumbers[i] = RandomNumberGenerator.GetInt32(this.minVal, this.maxVal);
        }

        progress.Report(0);
    }

    private void ClearButton_Click(object sender, EventArgs e) => this.Clear();

    private void Clear()
    {
        this.outputTextBox.Text = string.Empty;

        // reset current progress bar value
        this.progressBar.Value = 0;

        this.toolStripStatusLabel.Text = string.Empty;

        this.rndNumbers = null;

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

    private void QtyTextBox_TextChanged(object sender, EventArgs e) => AppSettings.RandomQty = int.Parse(this.qtyTextBox.Text);

    private void MinTextBox_TextChanged(object sender, EventArgs e) => AppSettings.RandomMin = int.Parse(this.minTextBox.Text);

    private void MaxTextBox_TextChanged(object sender, EventArgs e) => AppSettings.RandomMax = int.Parse(this.maxTextBox.Text);

    private void GenerateRandomPictureButton_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(this.minTextBox.Text, out int x_width) || x_width <= 0)
        {
            MessageBox.Show("X value not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return;
        }

        if (!int.TryParse(this.maxTextBox.Text, out int y_height) || y_height <= 0)
        {
            MessageBox.Show("Y value not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return;
        }

        var stopWatch = Stopwatch.StartNew();
        var bmp = new Bitmap(x_width, y_height);
        using var rnd = RandomNumberGenerator.Create();

        // create random pixels
        for (int y = 0; y < y_height; y++)
        {
            for (int x = 0; x < x_width; x++)
            {
                byte[] argb = new byte[4];

                // generate random ARGB value by filling byte array
                rnd.GetBytes(argb);

                // set ARGB value
                bmp.SetPixel(x, y, Color.FromArgb(argb[0], argb[1], argb[2], argb[3]));
            }
        }

        stopWatch.Stop();
        long elapsedMs = stopWatch.ElapsedMilliseconds;

        this.toolStripStatusLabel.Text = $"Elapsed(ms): {elapsedMs}";

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
