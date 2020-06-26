using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class ClockForm : Form
    {
        string TimeLabelText
        {
            set { timeLabel.Text = value; }
        }

        string DateLabelText
        {
            set { dateLabel.Text = value; }
        }

        //Color TimeLabelForeColor
        //{
        //    set { timeLabel.ForeColor = value; }
        //}

        //Color DateLabelForeColor
        //{
        //    set { dateLabel.ForeColor = value; }
        //}

        //Color DateTimeLabelColor { get; set; }

        // default color argb(255, 0, 0, 0)
        //uint _currentArgbVal = 0xFF000000;

        //List<Color> _colors = new List<Color>()
        //{
        //    Color.DarkBlue,
        //    Color.DarkCyan,
        //    Color.DarkGoldenrod,
        //    Color.DarkGray,
        //    Color.DarkGreen,
        //    Color.DarkKhaki,
        //    Color.DarkMagenta,
        //    Color.DarkOliveGreen,
        //    Color.DarkOrange,
        //    Color.DarkOrchid,
        //    Color.DarkRed,
        //    Color.DarkSalmon,
        //    Color.DarkSeaGreen,
        //    Color.DarkSlateBlue,
        //    Color.DarkSlateGray,
        //    Color.DarkTurquoise,
        //    Color.DarkViolet
        //};

        //List<Color> _colors = new List<Color>();

        public ClockForm()
        {
            InitializeComponent();
        }

        private void ClockForm_Load(object sender, EventArgs e)
        {
            TopMost = Program.GlobalTopMost;

            //GetAllColors();

            //var bcr = new BufferedCryptoRandom();

            // set random starting color
            //_currentArgbVal = 0xFF000000 | (uint)bcr.Next(0, int.MaxValue);
            //DateTimeLabelColor = Color.FromArgb((int)_currentArgbVal);

            //DateTimeLabelColor = _colors[bcr.Next(0, _colors.Count)];

            //TimeLabelForeColor = DateTimeLabelColor;
            //DateLabelForeColor = DateTimeLabelColor;

            TimeLabelText = string.Empty;
            DateLabelText = string.Empty;

            // date & time update timer
            dateTimeUpdateTimer.Tick += new EventHandler(UpdateDateTime);
            dateTimeUpdateTimer.Interval = 1000;
            dateTimeUpdateTimer.Start();

            // color update timer
            //argbValUpdateTimer.Tick += new EventHandler(UpdateArgbVal);
            //argbValUpdateTimer.Interval = 1000;
            //argbValUpdateTimer.Start();
        }

        //private void UpdateArgbVal(object sender, EventArgs e)
        //{
        //    _currentArgbVal = 0xFF000000 | ++_currentArgbVal;
        //    DateTimeLabelColor = Color.FromArgb((int)_currentArgbVal);

        //    //var bcr = new BufferedCryptoRandom();
        //    //DateTimeLabelColor = _colors[bcr.Next(0, _colors.Count)];

        //    TimeLabelForeColor = DateTimeLabelColor;
        //    DateLabelForeColor = DateTimeLabelColor;
        //}

        private void UpdateDateTime(object sender, EventArgs e)
        {
            var dateTimeNow = DateTime.Now;
            TimeLabelText = dateTimeNow.ToLongTimeString();
            DateLabelText = dateTimeNow.ToLongDateString();
            toolStripProgressBar.Value = (int)((dateTimeNow.TimeOfDay.TotalSeconds / 86400) * 100);
        }

        //private void GetAllColors()
        //{
        //    foreach (KnownColor colorValue in Enum.GetValues(typeof(KnownColor)))
        //    {
        //        Color color = Color.FromKnownColor(colorValue);

        //        if (!_colors.Contains(color))
        //        {
        //            _colors.Add(color);
        //        }
        //    }
        //}

        private void ClockForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
