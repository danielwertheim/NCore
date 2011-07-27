using System.Diagnostics;

namespace NCore
{
    public static class StringExtensions
    {
        [DebuggerStepThrough]
        public static string Inject(this string format, params object[] formattingArgs)
        {
            return string.Format(format, formattingArgs);
        }

        [DebuggerStepThrough]
        public static string Inject(this string format, params string[] formattingArgs)
        {
            return string.Format(format, formattingArgs);
        }
    }
}