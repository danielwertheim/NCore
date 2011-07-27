using System;
using System.Collections.Generic;
using System.Diagnostics;
using NCore.Resources;

namespace NCore
{
    public static class ValidationExtensions
    {
        [DebuggerStepThrough]
        public static Guid AssertNotEmpty(this Guid value, string name)
        {
            if(Guid.Empty.Equals(value))
                throw new ArgumentNullException(name);

            return value;
        }

        [DebuggerStepThrough]
        public static ICollection<T> AssertHasItems<T>(this ICollection<T> items, string name)
        {
            if (items == null || items.Count < 1)
                throw new ArgumentNullException(name);

            return items;
        }

        [DebuggerStepThrough]
        public static T AssertNotNull<T>(this T item, string name) where T : class
        {
            if (item == null)
                throw new ArgumentNullException(name);

            return item;
        }

        [DebuggerStepThrough]
        public static int AssertGt(this int value, int limit, string name)
        {
            if (value <= limit)
                throw new ArgumentOutOfRangeException(name, ExceptionMessages.ValidationExtensions_AssertGt.Inject(value, limit));

            return value;
        }

        [DebuggerStepThrough]
        public static int AssertGte(this int value, int limit, string name)
        {
            if (!(value >= limit))
                throw new ArgumentOutOfRangeException(name, ExceptionMessages.ValidationExtensions_AssertGte.Inject(value, limit));

            return value;
        }

        [DebuggerStepThrough]
        public static int AssertInRange(this int value, int min, int max, string name)
        {
            if (value < min)
                throw new ArgumentOutOfRangeException(name, ExceptionMessages.ValidationExtensions_AssertInRange_ToLow.Inject(value, min));

            if (value > max)
                throw new ArgumentOutOfRangeException(name, ExceptionMessages.ValidationExtensions_AssertInRange_ToHigh.Inject(value, max));

            return value;
        }

        [DebuggerStepThrough]
        public static string AssertNotNullOrWhiteSpace(this string item, string name)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentNullException(name);

            return item;
        }
    }
}