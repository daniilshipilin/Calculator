namespace Calculator.Forms;

using System;
using System.Windows.Forms;

public partial class ClockForm : Form
{
    public ClockForm()
    {
        this.InitializeComponent();
    }

    private void ClockForm_Load(object sender, EventArgs e)
    {
        this.timeLabel.Text = string.Empty;
        this.dateLabel.Text = string.Empty;

        // date & time update timer
        this.dateTimeUpdateTimer.Tick += this.UpdateDateTime;
        this.dateTimeUpdateTimer.Interval = 1000;
        this.dateTimeUpdateTimer.Start();
    }

    private void UpdateDateTime(object? sender, EventArgs e)
    {
        var dateTimeNow = DateTime.Now;
        this.timeLabel.Text = dateTimeNow.ToLongTimeString();
        this.dateLabel.Text = dateTimeNow.ToLongDateString();
        this.toolStripProgressBar.Value = (int)(dateTimeNow.TimeOfDay.TotalSeconds / 86400 * 100);
    }

    private void ClockForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }
}
