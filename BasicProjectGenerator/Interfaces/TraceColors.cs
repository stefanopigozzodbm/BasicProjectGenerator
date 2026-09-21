using System.Drawing;

namespace Basic_Project_Generator.Interfaces
{
    /// <summary>Costanti di colore standard da passare esplicitamente a TraceWriter.Write(...).</summary>
    public static class TraceColors
    {
        public static readonly Color Default = SystemColors.WindowText;
        public static readonly Color Ok = Color.Green;
        public static readonly Color Warning = Color.DarkOrange;
        public static readonly Color Error = Color.Red;
    }
}