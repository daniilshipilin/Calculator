using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Calculator
{
    static class Program
    {
        #region Cmd arguments

        public static Dictionary<string, string> CmdArgs = new Dictionary<string, string>();
        public static bool CmdArgsExist { get; private set; } = false;

        #endregion

        #region Fields

        static bool _globalTopMost = false;

        #endregion

        #region Properties

        // global static TopMost flag
        public static bool GlobalTopMost
        {
            get { return (_globalTopMost); }

            private set { _globalTopMost = value; }
        }

        #endregion

        #region Exitcode enum

        public enum ExitCode : int
        {
            Success = 0,
            AnotherInstanceRunning = 1,
            IncorrectArgs = 2,
            Error = 4
        }

        #endregion

        //#region Libraries versions dictionary

        //public static Dictionary<string, Version> LibrariesUsedDict { get; } = new Dictionary<string, Version>
        //{
        //    { "ProgramUpdater.dll", Version.Parse("0.0.1.1") },
        //    { "Crypto.dll", Version.Parse("0.1.6824.20712") }
        //};

        //#endregion

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // check if arguments are passed
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                EnumCmdArgs();
            }

            //CheckLibraries();

            Application.Run(new MainForm());

            ProgramExit();
        }

        //private static void CheckLibraries()
        //{
        //    foreach (var lib in LibrariesUsedDict)
        //    {
        //        var assembly = Assembly.LoadFrom(lib.Key);
        //        var version = assembly.GetName().Version;

        //        if (version != lib.Value)
        //        {
        //            MessageBox.Show($"{lib.Key} assembly version check failed.\nTarget version: {lib.Value}\nDll version: {version}");
        //        }
        //    }
        //}

        public static void ProgramExit(ExitCode exitCode = ExitCode.Success)
        {
            Environment.Exit((int)exitCode);
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
                for (int i = 1; i < args.Length; i += 2)
                {
                    CmdArgs.Add(args[i], args[i + 1]);
                }

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
                                 $"  • Currency converter.\r\n" +
                                 "\r\n" +
                                 "This program uses:\r\n" +
                                 "Jace.NET calculation engine library v1.0.0 © Pieter De Rycke 2020.";

            return (programInfo);
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

            return (shortcuts);
        }
    }
}
