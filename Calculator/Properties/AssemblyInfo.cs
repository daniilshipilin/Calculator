using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Calculator")]
[assembly: AssemblyDescription("A simple basic calculator.")]
[assembly: AssemblyProduct("Calculator")]
[assembly: AssemblyCopyright("ds (daniil.shipilin@gmail.com)")]
[assembly: AssemblyTrademark("ds (daniil.shipilin@gmail.com)")]
[assembly: Guid("cff8b2ce-eb3a-44f7-b5da-fb2e70efdbe6")]
[assembly: ComVisible(true)]

namespace Calculator
{
    public static class AssemblyInfo
    {
        static readonly Assembly _ass = Assembly.GetExecutingAssembly();
        static readonly AssemblyTitleAttribute _title = _ass.GetCustomAttributes<AssemblyTitleAttribute>().FirstOrDefault();
        static readonly AssemblyProductAttribute _product = _ass.GetCustomAttributes<AssemblyProductAttribute>().FirstOrDefault();
        static readonly AssemblyDescriptionAttribute _description = _ass.GetCustomAttributes<AssemblyDescriptionAttribute>().FirstOrDefault();
        static readonly AssemblyCopyrightAttribute _copyright = _ass.GetCustomAttributes<AssemblyCopyrightAttribute>().FirstOrDefault();
        static readonly AssemblyTrademarkAttribute _trademark = _ass.GetCustomAttributes<AssemblyTrademarkAttribute>().FirstOrDefault();
        static readonly GuidAttribute _guid = _ass.GetCustomAttributes<GuidAttribute>().FirstOrDefault();

        public static string BaseDirectory { get; } = AppDomain.CurrentDomain.BaseDirectory;
        public static string AppPath { get; } = _ass.Location;
        public static string AppTitle { get; } = _title.Title;
        public static string AppHeader { get; } = $"{_title.Title} v{GitVersionInformation.SemVer}";
        public static string AppAuthor { get; } = _copyright.Copyright;
        public static string AppDescription { get; } = _description.Description;
        public static string AppGUID { get; } = _guid.Value;

        /// <summary>
        /// Formatted application info string.
        /// </summary>
        public static string AppInfoFormatted { get; } =
            $"{AppHeader}{Environment.NewLine}" +
            $"{GitVersionInformation.InformationalVersion}{Environment.NewLine}" +
            $"Author: {AppAuthor}{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Description:{Environment.NewLine}" +
            $"  {AppDescription}{Environment.NewLine}";
    }
}
