using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        public static IDictionary<string, string> ToKeyValues(this string keyValueString, char pairDelim, char keyValueDelim)
        {
            return keyValueString.Split(new[] { pairDelim }, StringSplitOptions.RemoveEmptyEntries)
                .Select(kv => kv.Split(new[] { keyValueDelim }, StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(kv => kv[0], kv => kv[1]);
        }
    }
}