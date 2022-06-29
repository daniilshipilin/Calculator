namespace Calculator;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

public static class ApplicationInfo
{
    private static readonly Assembly Ass = Assembly.GetExecutingAssembly();
    private static readonly AssemblyTitleAttribute? Title = Ass.GetCustomAttributes<AssemblyTitleAttribute>().FirstOrDefault();
    private static readonly AssemblyProductAttribute? Product = Ass.GetCustomAttributes<AssemblyProductAttribute>().FirstOrDefault();
    private static readonly AssemblyDescriptionAttribute? Description = Ass.GetCustomAttributes<AssemblyDescriptionAttribute>().FirstOrDefault();
    private static readonly AssemblyCopyrightAttribute? Copyright = Ass.GetCustomAttributes<AssemblyCopyrightAttribute>().FirstOrDefault();

    public const string AppBuild =
#if DEBUG
        " [Debug]";
#else
        "";
#endif

    public static IReadOnlyList<string> Args { get; private set; } = new List<string>();

    public static string BaseDirectory => Path.GetDirectoryName(ExePath) ?? string.Empty;

    public static string ExePath { get; } = Process.GetCurrentProcess().MainModule?.FileName ?? string.Empty;

    public static string AppTitle { get; } = Title?.Title ?? string.Empty;

    public static string AppProduct { get; } = Product?.Product ?? string.Empty;

    public static string AppHeader { get; } = $"{AppTitle} v{GitVersionInformation.SemVer}{AppBuild}";

    public static string AppAuthor { get; } = Copyright?.Copyright ?? string.Empty;

    public static string AppDescription { get; } = Description?.Description ?? string.Empty;

    public static Guid AppGUID { get; } = new Guid("cff8b2ce-eb3a-44f7-b5da-fb2e70efdbe6");

    /// <summary>
    /// Gets application info formatted string.
    /// </summary>
    public static string AppInfoFormatted =>
        $"{AppHeader}{Environment.NewLine}" +
        $"{GitVersionInformation.InformationalVersion}{Environment.NewLine}" +
        $"Author: {AppAuthor}{Environment.NewLine}{Environment.NewLine}" +
        $"Description:{Environment.NewLine}" +
        $"  {AppDescription}";

    public static string AppInfoExtendedFormatted =>
        $"{AppInfoFormatted}{Environment.NewLine}" +
        $"Features:{Environment.NewLine}" +
        $"  • A simple basic calculator;{Environment.NewLine}" +
        $"  • Number base converter;{Environment.NewLine}" +
        $"  • Base64 string converter;{Environment.NewLine}" +
        $"  • File hash calculator;{Environment.NewLine}" +
        $"  • Hex to Ascii text converter;{Environment.NewLine}" +
        $"  • Random number & random image generator;{Environment.NewLine}" +
        $"  • Random password generator;{Environment.NewLine}" +
        $"  • Currency converter;{Environment.NewLine}" +
        $"  • Fuelcost calculator.{Environment.NewLine}";

    public static string ShortcutsFormatted =>
        $"The following table contains common keyboard shortcuts (accessible from the main menu):{Environment.NewLine}" +
        $"{Environment.NewLine}" +
        $"  'N' - Number Base converter;{Environment.NewLine}" +
        $"  'B' - Base64 String converter;{Environment.NewLine}" +
        $"  'H' - File Hash calculator;{Environment.NewLine}" +
        $"  'A' - Hex to Ascii text converter;{Environment.NewLine}" +
        $"  'G' - Random number generator;{Environment.NewLine}" +
        $"  'P' - Random password generator;{Environment.NewLine}" +
        $"  'R' - Currency converter;{Environment.NewLine}" +
        $"  'F' - Fuelcost calculator;{Environment.NewLine}" +
        $"  'C' - Digital clock;{Environment.NewLine}" +
        $"  'ESCAPE' - close current menu.";

    /// <summary>
    /// Sets application command line arguments.
    /// </summary>
    public static void SetArgs(string[] args) => Args = args.ToList();
}
