namespace Calculator;

using System;
using System.Reflection;

public static class ApplicationInfo
{
    private static readonly Assembly Ass = Assembly.GetExecutingAssembly();
    private static readonly AssemblyTitleAttribute? Title = Ass.GetCustomAttribute<AssemblyTitleAttribute>();
    private static readonly AssemblyDescriptionAttribute? Description = Ass.GetCustomAttribute<AssemblyDescriptionAttribute>();
    private static readonly AssemblyInformationalVersionAttribute? InformationalVersion = Ass.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

    private const string AppBuild =
#if DEBUG
        " [Debug]";
#else
        "";
#endif

    public static string? AppTitle { get; } = Title?.Title;

    public static string AppHeader { get; } = $"{AppTitle} v{InformationalVersion?.InformationalVersion}{AppBuild}";

    public static string AppInfoFormatted
        => $"{AppHeader}{Environment.NewLine}{Environment.NewLine}" +
           $"Description:{Environment.NewLine}" +
           $"  {Description?.Description}{Environment.NewLine}{Environment.NewLine}" +
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

    public static string ShortcutsFormatted
        => $"The following table contains common keyboard shortcuts (accessible from the main menu):{Environment.NewLine}" +
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
}
