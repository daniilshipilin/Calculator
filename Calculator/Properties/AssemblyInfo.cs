using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Calculator")]
[assembly: AssemblyDescription("A simple basic calculator.")]
[assembly: AssemblyProduct("Calculator")]
[assembly: AssemblyCopyright("Daniil Shipilin")]
[assembly: AssemblyTrademark("Daniil Shipilin")]
[assembly: Guid("cff8b2ce-eb3a-44f7-b5da-fb2e70efdbe6")]
[assembly: ComVisible(true)]

namespace Calculator
{
    public static class AssemblyInfo
    {
        private static readonly Assembly Ass = Assembly.GetExecutingAssembly();
        private static readonly AssemblyTitleAttribute Title = Ass.GetCustomAttributes<AssemblyTitleAttribute>().FirstOrDefault();
        private static readonly AssemblyDescriptionAttribute Description = Ass.GetCustomAttributes<AssemblyDescriptionAttribute>().FirstOrDefault();
        private static readonly AssemblyCopyrightAttribute Copyright = Ass.GetCustomAttributes<AssemblyCopyrightAttribute>().FirstOrDefault();
        private static readonly GuidAttribute GUID = Ass.GetCustomAttributes<GuidAttribute>().FirstOrDefault();

        public static string BaseDirectory { get; } = AppDomain.CurrentDomain.BaseDirectory;

        public static string AppPath { get; } = Ass.Location;

        public static string AppTitle { get; } = Title.Title;

        public static string AppHeader { get; } = $"{Title.Title} v{GitVersionInformation.SemVer}";

        public static string AppAuthor { get; } = Copyright.Copyright;

        public static string AppDescription { get; } = Description.Description;

        public static Guid AppGUID { get; } = new Guid(GUID.Value);

        /// <summary>
        /// Gets formatted application info string.
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
