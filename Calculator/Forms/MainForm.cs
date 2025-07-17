namespace Calculator.Forms;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationUpdater;
using Calculator.Helpers;
using Calculator.Helpers.MathExpressionParser;

public partial class MainForm : Form
{
    private const int CommandLength = 24;
    private const int DateTimeUpdateTimerMs = 1000;

    // flag, that indicates, if calculation process completed successfully
    private bool calculationIsDone = false;

    private string dateTimeStringFormat = string.Empty;

    private IUpdater? updater;

    // Boolean flag used to determine when a character other than a number is entered
    private bool NonNumberEntered = false;

    // OutputBuffer list property
    private List<string> OutputBuffer { get; set; } = new List<string>();

    public MainForm()
    {
        this.InitializeComponent();
    }

    private async void CalculatorForm_Load(object sender, EventArgs e)
    {
        AppSettings.CheckSettings();
        this.Text = $"{ApplicationInfo.AppHeader}";
        this.dateTimeStringFormat = AppSettings.DateTimeStringFormat;
        this.SetTooltips();
        this.InitTimers();

        // init program updater
        this.InitUpdater();

        // check for updates
        await this.CheckUpdates();
    }

    private void SetTooltips()
    {
        // button tooltips
        this.mainFormToolTip.SetToolTip(this.backspaceButton, "Backspace");
        this.mainFormToolTip.SetToolTip(this.sqrtButton, "Square root");
        this.mainFormToolTip.SetToolTip(this.moduloButton, "Modulo");
        this.mainFormToolTip.SetToolTip(this.exponentiationButton, "Exponentiation");
        this.mainFormToolTip.SetToolTip(this.clearEntryButton, "Clear entry");
        this.mainFormToolTip.SetToolTip(this.allClearButton, "All clear");
        this.mainFormToolTip.SetToolTip(this.memoryClearButton, "Memory clear");
        this.mainFormToolTip.SetToolTip(this.memoryStoreButton, "Store value in memory");
        this.mainFormToolTip.SetToolTip(this.memoryRecallButton, "Recall value from memory");

        // label tooltips
        this.mainFormToolTip.SetToolTip(this.memoryLabel, "Value stored in memory");
        this.mainFormToolTip.SetToolTip(this.memoryOutputLabel, "Value stored in memory");
        this.mainFormToolTip.SetToolTip(this.previousCommandLabel, "Previous operation");
    }

    private void InitTimers()
    {
        // date & time update timer
        this.dateTimeUpdateTimer.Tick += this.UpdateDateTime;
        this.dateTimeUpdateTimer.Interval = DateTimeUpdateTimerMs;
        this.dateTimeUpdateTimer.Start();
    }

    private void InitUpdater()
    {
        try
        {
            this.updater = new Updater(
                ApplicationInfo.BaseDirectory,
                Version.Parse(GitVersionInformation.SemVer),
                ApplicationInfo.AppGUID,
                ApplicationInfo.ExePath);
        }
        catch (Exception ex)
        {
            ShowExceptionMessage(ex);
        }
    }

    private async Task CheckUpdates(bool forceCheck = false)
    {
        if (this.updater is null)
        {
            return;
        }

        try
        {
            this.updatesMenuItem.Enabled = false;

            if (forceCheck)
            {
                AppSettings.UpdateUpdatesLastCheckedTimestamp();

                if (await this.updater.CheckUpdateIsAvailable())
                {
                    var dr = MessageBox.Show(
                        new Form { TopMost = true },
                        this.updater.GetUpdatePrompt(),
                        "Program update",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        var updateForm = new Form
                        {
                            Text = "Program update",
                            Width = 300,
                            Height = 150,
                            FormBorderStyle = FormBorderStyle.FixedSingle,
                            StartPosition = FormStartPosition.CenterScreen,
                            ShowInTaskbar = false,
                            ShowIcon = false,
                            MinimizeBox = false,
                            MaximizeBox = false,
                            TopMost = AppSettings.TopMost,
                        };

                        var label = new Label
                        {
                            Size = new Size(300, 100),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Text = $"Updating {ApplicationInfo.AppTitle} v{GitVersionInformation.SemVer} to version v{this.updater.ServerVersion}"
                        };

                        updateForm.Controls.Add(label);
                        updateForm.Show();

                        await this.updater.Update();
                        Program.ProgramExit();
                    }

                    return;
                }

                MessageBox.Show(
                    "Current program version is up to date.",
                    "Program update",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if ((DateTime.Now - AppSettings.UpdatesLastCheckedTimestamp).Days >= 1)
            {
                AppSettings.UpdateUpdatesLastCheckedTimestamp();

                if (await this.updater.CheckUpdateIsAvailable())
                {
                    var dr = MessageBox.Show(
                        new Form { TopMost = true },
                        $"Newer program version available.{Environment.NewLine}" +
                        $"Current: {this.updater.ClientVersion}{Environment.NewLine}" +
                        $"Available: {this.updater.ServerVersion}",
                        "Program update",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                }
            }
        }
        catch (Exception ex)
        {
            ShowExceptionMessage(ex);
        }
        finally
        {
            this.updatesMenuItem.Enabled = true;
        }
    }

    private static void ShowExceptionMessage(Exception ex)
    {
        MessageBox.Show(
            new Form { TopMost = true },
            ex.Message,
            ex.GetType().ToString(),
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }

    private void UpdateDateTime(object? sender, EventArgs e) => this.dateTimeToolStripStatusLabel.Text = DateTime.Now.ToString(this.dateTimeStringFormat);

    private void AnalyzeButtonPressed(object sender, EventArgs e)
    {
        this.dummyLabel.Focus();
        this.calculationIsDone = false;

        string button = ((Button)sender).Text;

        // special case, when 'Mod' button text needs to be converted to '%'
        if (button == "Mod")
        {
            button = "%";
        }

        if (this.OutputBuffer.Count >= CommandLength)
        {
            return;
        }

        if (this.OutputBuffer.LastOrDefault() is
            "." or
            "+" or
            "-" or
            "*" or
            "/" or
            "^" or
            "(" or
            ")" or
            "%")
        {
            if (this.OutputBuffer.LastOrDefault() == button)
            {
                return;
            }
        }

        this.OutputBuffer.Add(button);

        this.resultOutputLabel.Text = string.Empty;
        this.resultOutputLabel.ForeColor = Color.Black;

        foreach (string? cmd in this.OutputBuffer)
        {
            this.resultOutputLabel.Text += cmd;
        }
    }

    private void CalculateSqrt(object sender, EventArgs e)
    {
        this.dummyLabel.Focus();

        if (this.OutputBuffer.Count is >= CommandLength or 0)
        {
            return;
        }

        this.Calculate($"sqrt{string.Join(string.Empty, this.OutputBuffer.ToArray())}");
    }

    private void CalculateOneDividedByX(object sender, EventArgs e)
    {
        this.dummyLabel.Focus();

        if (this.OutputBuffer.Count is >= CommandLength or 0)
        {
            return;
        }

        this.Calculate($"1 / {string.Join(string.Empty, this.OutputBuffer.ToArray())}");
    }

    private void EqualsButton_Click(object sender, EventArgs e)
    {
        this.dummyLabel.Focus();

        if (this.OutputBuffer.Count >= CommandLength || this.OutputBuffer.Count == 0 || this.calculationIsDone)
        {
            return;
        }

        this.Calculate(string.Join(string.Empty, this.OutputBuffer.ToArray()));
    }

    private void Calculate(string command)
    {
        this.previousCommandLabel.Text = string.Empty;

        try
        {
            decimal result;

            if (command.Contains("sqrt"))
            {
                decimal num = decimal.Parse(command.Replace("sqrt", string.Empty));
                result = (decimal)Math.Sqrt((double)num);
            }
            else
            {
                result = MathProcessor.Calculate(command);
            }

            this.previousCommandLabel.Text = $"{command} =";
            this.OutputBuffer.Clear();
            this.resultOutputLabel.ForeColor = Color.DarkBlue;
            this.resultOutputLabel.Text = result.ToString();

            // split result value to char array
            char[] tmpChars = result.ToString().ToCharArray();

            // put individual numbers to output buffer list
            foreach (char ch in tmpChars)
            {
                this.OutputBuffer.Add(ch.ToString());
            }

            this.calculationIsDone = true;
        }
        catch (Exception ex)
        {
            ShowExceptionMessage(ex);
            this.ClearEntry();
        }
    }

    private void ClearEntry()
    {
        this.OutputBuffer.Clear();
        this.resultOutputLabel.Text = "0";
        this.resultOutputLabel.ForeColor = Color.Black;
        this.previousCommandLabel.Text = string.Empty;
    }

    private void Backspace()
    {
        this.resultOutputLabel.ForeColor = Color.Black;

        if (this.OutputBuffer.Count >= 1)
        {
            this.OutputBuffer.RemoveAt(this.OutputBuffer.Count - 1);
            this.resultOutputLabel.Text = this.resultOutputLabel.Text.Remove(this.resultOutputLabel.Text.Length - 1);

            // handle case, when output buffer contains no elements (set text to '0')
            if (this.OutputBuffer.Count == 0)
            {
                this.resultOutputLabel.Text = "0";
            }
        }
    }

    private void CalculatorForm_KeyDown(object sender, KeyEventArgs e)
    {
        // Initialize the flag to false.
        this.NonNumberEntered = false;

        // Determine whether the keystroke is a number from the top of the keyboard.
        if (e.KeyCode is < Keys.D0 or > Keys.D9)
        {
            // Determine whether the keystroke is a number from the keypad.
            if (e.KeyCode is < Keys.NumPad0 or > Keys.NumPad9)
            {
                this.NonNumberEntered = true;

                switch (e.KeyCode)
                {
                    case Keys.N:
                        ShowNumberBaseConverterForm();
                        break;

                    case Keys.B:
                        ShowBase64StringConverterForm();
                        break;

                    case Keys.H:
                        ShowFileHashCalculatorForm();
                        break;

                    case Keys.A:
                        ShowHexToAsciiConverterForm();
                        break;

                    case Keys.G:
                        ShowRandomNumberGeneratorForm();
                        break;

                    case Keys.P:
                        ShowRandomPasswordGeneratorForm();
                        break;

                    case Keys.R:
                        ShowCurrencyConverterForm();
                        break;

                    case Keys.F:
                        ShowFuelcostCalculatorForm();
                        break;

                    case Keys.Return:
                        if (!this.calculationIsDone)
                        {
                            this.Calculate(string.Join(string.Empty, this.OutputBuffer.ToArray()));
                        }

                        break;

                    case Keys.Delete:
                        this.ClearEntry();
                        break;

                    case Keys.Back:
                        this.Backspace();
                        break;

                    case Keys.Add:
                        this.NonNumberEntered = false;
                        break;

                    case Keys.Subtract:
                        this.NonNumberEntered = false;
                        break;

                    case Keys.Multiply:
                        this.NonNumberEntered = false;
                        break;

                    case Keys.Divide:
                        this.NonNumberEntered = false;
                        break;

                    case Keys.Decimal:
                        this.NonNumberEntered = false;
                        break;

                    case Keys.OemPeriod:
                        this.NonNumberEntered = false;
                        break;

                    default:
                        break;
                }

                // key 'C' launches Clock
                if (!e.Control && e.KeyCode == Keys.C)
                {
                    ShowClockForm();
                    return;
                }
            }
        }

        // if shift key was pressed, it's not a number.
        if (ModifierKeys == Keys.Shift)
        {
            this.NonNumberEntered = true;
        }

        // copy 'CTRL + C' combination check
        if (e.Control && e.KeyCode == Keys.C)
        {
            string tmpStr = this.resultOutputLabel.Text.Trim();

            if (!string.IsNullOrEmpty(tmpStr))
            {
                Clipboard.SetDataObject(tmpStr);
            }
        }

        // paste CTRL + V combination check
        else if (e.Control && e.KeyCode == Keys.V)
        {
            var iData = Clipboard.GetDataObject();

            if (!iData!.GetDataPresent(DataFormats.Text))
            {
                return;
            }

            if (!decimal.TryParse((string)Clipboard.GetDataObject()!.GetData(DataFormats.Text)!, out decimal parsedValue))
            {
                MessageBox.Show("Cannot convert clipboard text to number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // store resulting string length
            int tmpStrLength = (parsedValue.ToString() + string.Join(string.Empty, this.OutputBuffer)).Length;

            if (tmpStrLength > CommandLength)
            {
                MessageBox.Show("Cannot insert clipboard content to the output buffer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.OutputBuffer.Add(parsedValue.ToString());
            this.resultOutputLabel.Text = string.Empty;

            foreach (string? cmd in this.OutputBuffer)
            {
                this.resultOutputLabel.Text += cmd;
            }
        }
    }

    private void CalculatorForm_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Check for the flag being set in the KeyDown event.
        if (this.NonNumberEntered)
        {
            e.Handled = true;

            return;
        }

        string button = e.KeyChar.ToString();
        this.resultOutputLabel.ForeColor = Color.Black;

        if (this.OutputBuffer.Count >= CommandLength)
        {
            return;
        }

        if (this.OutputBuffer.LastOrDefault() is
            "." or
            "+" or
            "-" or
            "*" or
            "/" or
            "^" or
            "(" or
            ")" or
            "%")
        {
            if (this.OutputBuffer.LastOrDefault() == button)
            {
                return;
            }
        }

        this.calculationIsDone = false;

        this.OutputBuffer.Add(button);

        this.resultOutputLabel.Text = string.Empty;

        foreach (string? cmd in this.OutputBuffer)
        {
            this.resultOutputLabel.Text += cmd;
        }
    }

    private void BackspaceButton_Click(object sender, EventArgs e)
    {
        this.dummyLabel.Focus();

        this.Backspace();
    }

    private void ClearEntryButton_Click(object sender, EventArgs e)
    {
        this.dummyLabel.Focus();

        this.ClearEntry();
    }

    private void AllClearButton_Click(object sender, EventArgs e)
    {
        this.dummyLabel.Focus();

        this.ClearEntry();

        if (!string.IsNullOrEmpty(this.memoryOutputLabel.Text))
        {
            this.MemoryClear();
        }
    }

    private void MemoryClearButton_Click(object sender, EventArgs e)
    {
        this.dummyLabel.Focus();

        this.MemoryClear();
    }

    private void MemoryRecallButton_Click(object sender, EventArgs e)
    {
        this.dummyLabel.Focus();

        this.MemoryRecall();
    }

    private void MemoryStoreButton_Click(object sender, EventArgs e)
    {
        this.dummyLabel.Focus();

        this.MemoryStore();
    }

    private void MemoryClear()
    {
        if (string.IsNullOrEmpty(this.memoryOutputLabel.Text))
        {
            MessageBox.Show("Memory buffer empty. Nothing to clear.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            this.memoryOutputLabel.Text = string.Empty;
        }
    }

    private void MemoryStore()
    {
        if (string.IsNullOrEmpty(this.memoryOutputLabel.Text))
        {
            if (decimal.TryParse(this.resultOutputLabel.Text, out decimal tmp))
            {
                if (tmp == 0)
                {
                    MessageBox.Show("Only non-zero values can be stored.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                this.memoryOutputLabel.Text = tmp.ToString();
            }
            else
            {
                MessageBox.Show("Cannot convert to number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.memoryOutputLabel.Text = this.resultOutputLabel.Text;
        }
        else
        {
            MessageBox.Show("Memory buffer already contains a value. Clear it up first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void MemoryRecall()
    {
        if (string.IsNullOrEmpty(this.memoryOutputLabel.Text))
        {
            MessageBox.Show("Memory buffer empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            this.OutputBuffer.Add(this.memoryOutputLabel.Text);

            this.resultOutputLabel.Text = string.Empty;

            foreach (string? cmd in this.OutputBuffer)
            {
                this.resultOutputLabel.Text += cmd;
            }
        }
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e) => ShowAboutForm();

    private void NumberBaseConverterToolStripMenuItem_Click(object sender, EventArgs e) => ShowNumberBaseConverterForm();

    private void Base64StringConverterToolStripMenuItem_Click(object sender, EventArgs e) => ShowBase64StringConverterForm();

    private void FileHashCalculatorToolStripMenuItem_Click(object sender, EventArgs e) => ShowFileHashCalculatorForm();

    private void HexToAsciiConverterToolStripMenuItem_Click(object sender, EventArgs e) => ShowHexToAsciiConverterForm();

    private void KeyboardShortcutsToolStripMenuItem_Click(object sender, EventArgs e) => ShowKeyboardShortcutsForm();

    private void RandomNumberGeneratorToolStripMenuItem_Click(object sender, EventArgs e) => ShowRandomNumberGeneratorForm();

    private void AsciiTableToolStripMenuItem_Click(object sender, EventArgs e) => ShowAsciiTableForm();

    private void RandomPasswordGeneratorToolStripMenuItem_Click(object sender, EventArgs e) => ShowRandomPasswordGeneratorForm();

    private void CurrencyConverterToolStripMenuItem_Click(object sender, EventArgs e) => ShowCurrencyConverterForm();

    private void FuelcostCalculatorToolStripMenuItem_Click(object sender, EventArgs e) => ShowFuelcostCalculatorForm();

    private static void ShowAboutForm()
    {
        using var aboutForm = new AboutForm();
        aboutForm.ShowDialog();
    }

    private static void ShowNumberBaseConverterForm()
    {
        var numberBaseConverterForm = new NumberBaseConverterForm();
        numberBaseConverterForm.Show();
    }

    private static void ShowBase64StringConverterForm()
    {
        var stringBase64ConverterForm = new Base64StringConverterForm();
        stringBase64ConverterForm.Show();
    }

    private static void ShowFileHashCalculatorForm()
    {
        var fileHashCalculatorForm = new FileHashCalculatorForm();
        fileHashCalculatorForm.Show();
    }

    private static void ShowHexToAsciiConverterForm()
    {
        var hexToAsciiConverterForm = new HexToAsciiConverterForm();
        hexToAsciiConverterForm.Show();
    }

    private static void ShowKeyboardShortcutsForm()
    {
        using var keyboardShortcutsForm = new KeyboardShortcutsForm();
        keyboardShortcutsForm.ShowDialog();
    }

    private static void ShowRandomNumberGeneratorForm()
    {
        var randomNumberGeneratorForm = new RandomNumberGeneratorForm();
        randomNumberGeneratorForm.Show();
    }

    private static void ShowAsciiTableForm()
    {
        using var asciiTableForm = new AsciiTableForm();
        asciiTableForm.ShowDialog();
    }

    private static void ShowClockForm()
    {
        var clockForm = new ClockForm();
        clockForm.Show();
    }

    private static void ShowRandomPasswordGeneratorForm()
    {
        var randomPasswordGeneratorForm = new RandomPasswordGeneratorForm();
        randomPasswordGeneratorForm.Show();
    }

    private static void ShowCurrencyConverterForm()
    {
        var currencyConverterForm = new CurrencyConverterForm();
        currencyConverterForm.Show();
    }

    private static void ShowFuelcostCalculatorForm()
    {
        var fuelcostCalculatorForm = new FuelcostCalculatorForm();
        fuelcostCalculatorForm.Show();
    }

    private void TopmostToolStripMenuItem_CheckedChanged(object sender, EventArgs e) => this.SetProgramTopmostVal(this.topmostToolStripMenuItem.Checked);

    private void SetProgramTopmostVal(bool val)
    {
        this.TopMost = val;
        AppSettings.TopMost = val;
    }

    private async void UpdatesMenuItem_Click(object sender, EventArgs e) => await this.CheckUpdates(true);
}
