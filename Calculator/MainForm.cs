#nullable enable

namespace Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Calculator.Helpers;
    using MathExpressionParser;
    using ProgramUpdater;

    public partial class MainForm : Form
    {
        private const int COMMANDLENGTH = 24;
        private const int UPDATETIMERMS = 1000;

        // flag, that indicates, if calculation process completed successfully
        private bool calculationIsDone = false;

        public MainForm()
        {
            InitializeComponent();

            if (AppSettings.AssemblyExist())
            {
                if (AppSettings.KeyExist("DateTimeStringFormat"))
                {
                    DateTimeStringFormat = AppSettings.ReadKey("DateTimeStringFormat");
                }
            }
        }

        // Boolean flag used to determine when a character other than a number is entered
        private bool NonNumberEntered { get; set; } = false;

        // OutputBuffer list property
        private List<string> OutputBuffer { get; set; } = new List<string>();

        // resultOutputLabel text
        private string ResultOutputLabelText
        {
            get { return resultOutputLabel.Text; }
            set { resultOutputLabel.Text = value; }
        }

        // resultOutputLabel foreground color
        private Color ResultOutputLabelForeColor
        {
            set { resultOutputLabel.ForeColor = value; }
        }

        // memoryOutputLabel text
        private string MemoryOutputLabelText
        {
            get { return memoryOutputLabel.Text; }
            set { memoryOutputLabel.Text = value; }
        }

        private string DateTimeToolStripStatusLabelText
        {
            set { dateTimeToolStripStatusLabel.Text = value; }
        }

        // DateTime structure format string
        private string? DateTimeStringFormat { get; }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            Text = $"{AssemblyInfo.AppHeader}";
            SetTooltips();
            InitTimers();

            if (Program.CmdArgsExist)
            {
                ParseCmdArgs();
            }
        }

        private void SetTooltips()
        {
            // button tooltips
            mainFormToolTip.SetToolTip(backspaceButton, "Backspace");
            mainFormToolTip.SetToolTip(sqrtButton, "Square root");
            mainFormToolTip.SetToolTip(moduloButton, "Modulo");
            mainFormToolTip.SetToolTip(exponentiationButton, "Exponentiation");
            mainFormToolTip.SetToolTip(clearEntryButton, "Clear entry");
            mainFormToolTip.SetToolTip(allClearButton, "All clear");
            mainFormToolTip.SetToolTip(memoryClearButton, "Memory clear");
            mainFormToolTip.SetToolTip(memoryStoreButton, "Store value in memory");
            mainFormToolTip.SetToolTip(memoryRecallButton, "Recall value from memory");

            // label tooltips
            mainFormToolTip.SetToolTip(memoryLabel, "Value stored in memory");
            mainFormToolTip.SetToolTip(memoryOutputLabel, "Value stored in memory");
            mainFormToolTip.SetToolTip(previousCommandLabel, "Previous operation");
        }

        private void InitTimers()
        {
            // date & time update timer
            dateTimeUpdateTimer.Tick += new EventHandler(UpdateDateTime);
            dateTimeUpdateTimer.Interval = UPDATETIMERMS;
            dateTimeUpdateTimer.Start();
        }

        private async Task CheckUpdates()
        {
            try
            {
                var updater = new Updater(
                    AssemblyInfo.BaseDirectory,
                    new Version(GitVersionInformation.SemVer),
                    AssemblyInfo.AppGUID,
                    AssemblyInfo.AppPath,
                    AppSettings.ReadKey("AppVersionsJsonUrl"));

                if (await updater.CheckUpdateIsAvailable())
                {
                    var dr = MessageBox.Show(updater.UpdatePromptFormatted, "Program update required", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        await updater.Update();
                        Close();
                        Dispose();
                        Program.ProgramExit((int)Program.ExitCode.Success);
                    }
                }
                else
                {
                    MessageBox.Show("Program is up to date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ParseCmdArgs()
        {
            var sc = StringComparison.OrdinalIgnoreCase;

            string key1 = "-form";

            if (Program.CmdArgs.ContainsKey(key1))
            {
                if (string.Equals(Program.CmdArgs[key1], "about", sc))
                {
                    ShowAboutForm();
                }
                else if (string.Equals(Program.CmdArgs[key1], "settings", sc))
                {
                    ShowSettingsForm();
                }
                else if (string.Equals(Program.CmdArgs[key1], "numberbaseconverter", sc))
                {
                    ShowNumberBaseConverterForm();
                }
                else if (string.Equals(Program.CmdArgs[key1], "base64converter", sc))
                {
                    ShowBase64StringConverterForm();
                }
                else if (string.Equals(Program.CmdArgs[key1], "filehashcalculator", sc))
                {
                    ShowFileHashCalculatorForm();
                }
                else if (string.Equals(Program.CmdArgs[key1], "hextoasciiconverter", sc))
                {
                    ShowHexToAsciiConverterForm();
                }
                else if (string.Equals(Program.CmdArgs[key1], "shortcuts", sc))
                {
                    ShowKeyboardShortcutsForm();
                }
                else if (string.Equals(Program.CmdArgs[key1], "randomnumbergenerator", sc))
                {
                    ShowRandomNumberGeneratorForm();
                }
                else if (string.Equals(Program.CmdArgs[key1], "asciitable", sc))
                {
                    ShowAsciiTableForm();
                }
                else if (string.Equals(Program.CmdArgs[key1], "clock", sc))
                {
                    ShowClockForm();
                }
                else if (string.Equals(Program.CmdArgs[key1], "randompasswordgenerator", sc))
                {
                    ShowRandomPasswordGeneratorForm();
                }
                else if (string.Equals(Program.CmdArgs[key1], "currencyconverter", sc))
                {
                    ShowCurrencyConverterForm();
                }
                else
                {
                    MessageBox.Show($"Provided cmd arguments are not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show($"Provided cmd arguments are not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateDateTime(object sender, EventArgs e)
        {
            var dateTimeNow = DateTime.Now;

            if (DateTimeStringFormat is null)
            {
                DateTimeToolStripStatusLabelText = $"{dateTimeNow.ToLongDateString()} {dateTimeNow.ToLongTimeString()}";
            }
            else
            {
                DateTimeToolStripStatusLabelText = dateTimeNow.ToString(DateTimeStringFormat);
            }
        }

        private void AnalyzeButtonPressed(object sender, EventArgs e)
        {
            dummyLabel.Focus();
            calculationIsDone = false;

            string button = ((Button)sender).Text;

            // special case, when 'Mod' button text needs to be converted to '%'
            if (button == "Mod")
            {
                button = "%";
            }

            if (OutputBuffer.Count >= COMMANDLENGTH)
            {
                return;
            }

            if (OutputBuffer.LastOrDefault() == "." ||
                OutputBuffer.LastOrDefault() == "+" ||
                OutputBuffer.LastOrDefault() == "-" ||
                OutputBuffer.LastOrDefault() == "*" ||
                OutputBuffer.LastOrDefault() == "/" ||
                OutputBuffer.LastOrDefault() == "^" ||
                OutputBuffer.LastOrDefault() == "(" ||
                OutputBuffer.LastOrDefault() == ")" ||
                OutputBuffer.LastOrDefault() == "%")
            {
                if (OutputBuffer.LastOrDefault() == button)
                {
                    return;
                }
            }

            OutputBuffer.Add(button);

            ResultOutputLabelText = string.Empty;
            ResultOutputLabelForeColor = Color.Black;

            foreach (var cmd in OutputBuffer)
            {
                ResultOutputLabelText += cmd;
            }
        }

        private void CalculateSqrt(object sender, EventArgs e)
        {
            dummyLabel.Focus();

            if (OutputBuffer.Count >= COMMANDLENGTH || OutputBuffer.Count == 0)
            {
                return;
            }

            Calculate($"sqrt{string.Join(string.Empty, OutputBuffer.ToArray())}");
        }

        private void CalculateOneDividedByX(object sender, EventArgs e)
        {
            dummyLabel.Focus();

            if (OutputBuffer.Count >= COMMANDLENGTH || OutputBuffer.Count == 0)
            {
                return;
            }

            Calculate($"1 / {string.Join(string.Empty, OutputBuffer.ToArray())}");
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            dummyLabel.Focus();

            if (OutputBuffer.Count >= COMMANDLENGTH || OutputBuffer.Count == 0 || calculationIsDone)
            {
                return;
            }

            Calculate(string.Join(string.Empty, OutputBuffer.ToArray()));
        }

        private void Calculate(string command)
        {
            previousCommandLabel.Text = string.Empty;

            try
            {
                double result;

                if (command.Contains("sqrt"))
                {
                    double num = double.Parse(command.Replace("sqrt", string.Empty));
                    result = Math.Sqrt(num);
                }
                else
                {
                    result = MathProcessor.Calculate(command);
                }

                previousCommandLabel.Text = $"{command} =";
                OutputBuffer.Clear();
                ResultOutputLabelForeColor = Color.DarkBlue;
                ResultOutputLabelText = result.ToString();

                // split result double value to char array
                char[] tmpChars = result.ToString().ToCharArray();

                // put individual numbers to output buffer list
                foreach (char ch in tmpChars)
                {
                    OutputBuffer.Add(ch.ToString());
                }

                calculationIsDone = true;
            }
            catch (Exception ex)
            {
                ResultOutputLabelForeColor = Color.DarkRed;
                ResultOutputLabelText = "EXCEPTION";
                MessageBox.Show($"{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearEntry();
            }
        }

        private void ClearEntry()
        {
            OutputBuffer.Clear();
            ResultOutputLabelText = "0";
            ResultOutputLabelForeColor = Color.Black;
            previousCommandLabel.Text = string.Empty;
        }

        private void Backspace()
        {
            ResultOutputLabelForeColor = Color.Black;

            if (OutputBuffer.Count >= 1)
            {
                OutputBuffer.RemoveAt(OutputBuffer.Count - 1);
                ResultOutputLabelText = ResultOutputLabelText.Remove(ResultOutputLabelText.Length - 1);

                // handle case, when output buffer contains no elements (set text to '0')
                if (OutputBuffer.Count == 0)
                {
                    ResultOutputLabelText = "0";
                }
            }
        }

        private void CalculatorForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            NonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    NonNumberEntered = true;

                    switch (e.KeyCode)
                    {
                        case Keys.N:
                            ShowNumberBaseConverterForm();
                            break;

                        case Keys.S:
                            ShowSettingsForm();
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

                        case Keys.Return:
                            if (!calculationIsDone)
                            {
                                Calculate(string.Join(string.Empty, OutputBuffer.ToArray()));
                            }

                            break;

                        case Keys.Delete:
                            ClearEntry();
                            break;

                        case Keys.Back:
                            Backspace();
                            break;

                        case Keys.Add:
                            NonNumberEntered = false;
                            break;

                        case Keys.Subtract:
                            NonNumberEntered = false;
                            break;

                        case Keys.Multiply:
                            NonNumberEntered = false;
                            break;

                        case Keys.Divide:
                            NonNumberEntered = false;
                            break;

                        case Keys.Decimal:
                            NonNumberEntered = false;
                            break;

                        case Keys.OemPeriod:
                            NonNumberEntered = false;
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
                NonNumberEntered = true;
            }

            // copy 'CTRL + C' combination check
            if (e.Control && e.KeyCode == Keys.C)
            {
                string tmpStr = ResultOutputLabelText.Trim();

                if (!string.IsNullOrEmpty(tmpStr))
                {
                    Clipboard.SetText(tmpStr);
                }
            }

            // paste CTRL + V combination check
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (!double.TryParse(Clipboard.GetText(), out double doubleVal))
                {
                    MessageBox.Show("Cannot convert clipboard text to double-precision floating-point number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // store resulting string length
                int tmpStrLength = (doubleVal.ToString() + string.Join(string.Empty, OutputBuffer)).Length;

                if (tmpStrLength > COMMANDLENGTH)
                {
                    MessageBox.Show("Cannot insert clipboard content to the output buffer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OutputBuffer.Add(doubleVal.ToString());
                ResultOutputLabelText = string.Empty;

                foreach (var cmd in OutputBuffer)
                {
                    ResultOutputLabelText += cmd;
                }
            }
        }

        private void CalculatorForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (NonNumberEntered)
            {
                e.Handled = true;

                return;
            }

            string button = e.KeyChar.ToString();
            ResultOutputLabelForeColor = Color.Black;

            if (OutputBuffer.Count >= COMMANDLENGTH)
            {
                return;
            }

            if (OutputBuffer.LastOrDefault() == "." ||
                OutputBuffer.LastOrDefault() == "+" ||
                OutputBuffer.LastOrDefault() == "-" ||
                OutputBuffer.LastOrDefault() == "*" ||
                OutputBuffer.LastOrDefault() == "/" ||
                OutputBuffer.LastOrDefault() == "^" ||
                OutputBuffer.LastOrDefault() == "(" ||
                OutputBuffer.LastOrDefault() == ")" ||
                OutputBuffer.LastOrDefault() == "%")
            {
                if (OutputBuffer.LastOrDefault() == button)
                {
                    return;
                }
            }

            calculationIsDone = false;

            OutputBuffer.Add(button);

            ResultOutputLabelText = string.Empty;

            foreach (var cmd in OutputBuffer)
            {
                ResultOutputLabelText += cmd;
            }
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            dummyLabel.Focus();

            Backspace();
        }

        private void ClearEntryButton_Click(object sender, EventArgs e)
        {
            dummyLabel.Focus();

            ClearEntry();
        }

        private void AllClearButton_Click(object sender, EventArgs e)
        {
            dummyLabel.Focus();

            ClearEntry();

            if (!string.IsNullOrEmpty(MemoryOutputLabelText))
            {
                MemoryClear();
            }
        }

        private void MemoryClearButton_Click(object sender, EventArgs e)
        {
            dummyLabel.Focus();

            MemoryClear();
        }

        private void MemoryRecallButton_Click(object sender, EventArgs e)
        {
            dummyLabel.Focus();

            MemoryRecall();
        }

        private void MemoryStoreButton_Click(object sender, EventArgs e)
        {
            dummyLabel.Focus();

            MemoryStore();
        }

        private void MemoryClear()
        {
            if (string.IsNullOrEmpty(MemoryOutputLabelText))
            {
                MessageBox.Show("Memory buffer empty. Nothing to clear.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MemoryOutputLabelText = string.Empty;
            }
        }

        private void MemoryStore()
        {
            if (string.IsNullOrEmpty(MemoryOutputLabelText))
            {
                if (double.TryParse(ResultOutputLabelText, out double tmp))
                {
                    if (tmp == 0)
                    {
                        MessageBox.Show("Only non-zero values can be stored.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    MemoryOutputLabelText = tmp.ToString();
                }
                else
                {
                    MessageBox.Show("Cannot convert to double-precision floating-point number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                MemoryOutputLabelText = ResultOutputLabelText;
            }
            else
            {
                MessageBox.Show("Memory buffer already contains a value. Clear it up first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MemoryRecall()
        {
            if (string.IsNullOrEmpty(MemoryOutputLabelText))
            {
                MessageBox.Show("Memory buffer empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                OutputBuffer.Add(MemoryOutputLabelText);

                ResultOutputLabelText = string.Empty;

                foreach (var cmd in OutputBuffer)
                {
                    ResultOutputLabelText += cmd;
                }
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutForm();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        private void NumberBaseConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNumberBaseConverterForm();
        }

        private void Base64StringConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBase64StringConverterForm();
        }

        private void FileHashCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFileHashCalculatorForm();
        }

        private void HexToAsciiConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHexToAsciiConverterForm();
        }

        private void KeyboardShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowKeyboardShortcutsForm();
        }

        private void RandomNumberGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRandomNumberGeneratorForm();
        }

        private void AsciiTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAsciiTableForm();
        }

        private void RandomPasswordGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRandomPasswordGeneratorForm();
        }

        private void CurrencyConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCurrencyConverterForm();
        }

        private void ShowAboutForm()
        {
            using var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void ShowSettingsForm()
        {
            using var settingsForm = new SettingsForm();

            if (settingsForm.ShowForm)
            {
                settingsForm.ShowDialog();
            }
        }

        private void ShowNumberBaseConverterForm()
        {
            var numberBaseConverterForm = new NumberBaseConverterForm();
            numberBaseConverterForm.Show();
        }

        private void ShowBase64StringConverterForm()
        {
            var stringBase64ConverterForm = new Base64StringConverterForm();
            stringBase64ConverterForm.Show();
        }

        private void ShowFileHashCalculatorForm()
        {
            var fileHashCalculatorForm = new FileHashCalculatorForm();
            fileHashCalculatorForm.Show();
        }

        private void ShowHexToAsciiConverterForm()
        {
            var hexToAsciiConverterForm = new HexToAsciiConverterForm();
            hexToAsciiConverterForm.Show();
        }

        private void ShowKeyboardShortcutsForm()
        {
            using var keyboardShortcutsForm = new KeyboardShortcutsForm();
            keyboardShortcutsForm.ShowDialog();
        }

        private void ShowRandomNumberGeneratorForm()
        {
            var randomNumberGeneratorForm = new RandomNumberGeneratorForm();
            randomNumberGeneratorForm.Show();
        }

        private void ShowAsciiTableForm()
        {
            using var asciiTableForm = new AsciiTableForm();
            asciiTableForm.ShowDialog();
        }

        private void ShowClockForm()
        {
            var clockForm = new ClockForm();
            clockForm.Show();
        }

        private void ShowRandomPasswordGeneratorForm()
        {
            var randomPasswordGeneratorForm = new RandomPasswordGeneratorForm();
            randomPasswordGeneratorForm.Show();
        }

        private void ShowCurrencyConverterForm()
        {
            var currencyConverterForm = new CurrencyConverterForm();
            currencyConverterForm.Show();
        }

        private void TopmostToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            SetProgramTopmostVal(topmostToolStripMenuItem.Checked);
        }

        private void SetProgramTopmostVal(bool val)
        {
            TopMost = val;
            Program.SetGlobalTopMost(val);
        }

        private async void UpdatesMenuItem_Click(object sender, EventArgs e)
        {
            await CheckUpdates();
        }
    }
}
