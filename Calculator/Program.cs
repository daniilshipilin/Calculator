namespace Calculator;

using System;
using System.Diagnostics;
using System.Windows.Forms;
using Calculator.Forms;

public static class Program
{
    public enum ExitCode
    {
        Success = 0,
        AnotherInstanceRunning = 1,
        IncorrectArgs = 2,
        Error = 4,
    }

    [STAThread]
    public static void Main(string[] args)
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // check, if there is another instance running
        if (CheckAnotherInstanceIsRunning(ApplicationInfo.AppTitle))
        {
            MessageBox.Show(
                new Form { TopMost = true },
                $"Another instance of '{ApplicationInfo.AppTitle}' is running",
                "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            ProgramExit(ExitCode.AnotherInstanceRunning);
        }

        // handle special case, when we pass single argument
        if (args.Length == 1 && args[0].Equals("/?"))
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
            return;
        }

        ApplicationInfo.SetArgs(args);
        Application.Run(new MainForm());

        ProgramExit(ExitCode.Success);
    }

    public static void ProgramExit(ExitCode exitCode = ExitCode.Success) => Environment.Exit((int)exitCode);

    private static bool CheckAnotherInstanceIsRunning(string programName) => Process.GetProcessesByName(programName).Length > 1;
}
