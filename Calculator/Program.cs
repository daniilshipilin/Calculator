namespace Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public static class Program
    {
        public enum ExitCode : int
        {
            Success = 0,
            AnotherInstanceRunning = 1,
            IncorrectArgs = 2,
            Error = 4,
        }

        public static IReadOnlyDictionary<string, string> CmdArgs { get; private set; }

        public static bool CmdArgsExist { get; private set; }

        // global static TopMost flag
        public static bool GlobalTopMost { get; set; }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // check if arguments are passed
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                EnumCmdArgs();
            }

            Application.Run(new MainForm());

            ProgramExit();
        }

        public static void ProgramExit(ExitCode exitCode = ExitCode.Success)
        {
            Environment.Exit((int)exitCode);
        }

        public static void SetGlobalTopMost(bool val)
        {
            GlobalTopMost = val;
        }

        public static string GetInfo()
        {
            string programInfo = $"{AssemblyInfo.AppHeader}\r\n" +
                                 $"{GitVersionInformation.InformationalVersion}\r\n" +
                                 $"Author: {AssemblyInfo.AppAuthor}\r\n" +
                                 $"\r\n" +
                                 $"Features:\r\n" +
                                 $"  • A simple basic calculator;\r\n" +
                                 $"  • Number base converter;\r\n" +
                                 $"  • Base64 string converter;\r\n" +
                                 $"  • File hash calculator;\r\n" +
                                 $"  • Hex to Ascii text converter;\r\n" +
                                 $"  • Random number & random image generator;\r\n" +
                                 $"  • Random password generator;\r\n" +
                                 $"  • Currency converter.\r\n";

            return programInfo;
        }

        public static string GetShortcuts()
        {
            string shortcuts = $"The following table contains common keyboard shortcuts(accessible from the main menu):\r\n" +
                               $"\r\n" +
                               $"    'N' - Number Base converter;\r\n" +
                               $"    'B' - Base64 String converter;\r\n" +
                               $"    'H' - File Hash calculator;\r\n" +
                               $"    'A' - Hex to Ascii text converter;\r\n" +
                               $"    'G' - Random number generator;\r\n" +
                               $"    'P' - Random password generator;\r\n" +
                               $"    'R' - Currency converter;\r\n" +
                               $"    'C' - Digital clock;\r\n" +
                               $"    'S' - Settings menu;\r\n" +
                               $"    'ESCAPE' - close current menu.";

            return shortcuts;
        }

        private static void EnumCmdArgs()
        {
            string[] args = Environment.GetCommandLineArgs();

            // handle special case, when we pass single argument
            if (args.Length == 2 && args[1] == "/?")
            {
                ShowAboutForm();

                ProgramExit();
            }

            try
            {
                var dict = new Dictionary<string, string>();

                for (int i = 1; i < args.Length; i += 2)
                {
                    dict.Add(args[i], args[i + 1]);
                }

                CmdArgs = dict;
                CmdArgsExist = true;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show($"Provided incorrect number of cmd arguments", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ProgramExit(ExitCode.IncorrectArgs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ProgramExit(ExitCode.IncorrectArgs);
            }
        }

        private static void ShowAboutForm()
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
}
