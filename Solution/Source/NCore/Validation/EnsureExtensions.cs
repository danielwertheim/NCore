using System;
using System.Collections.Generic;
using System.Diagnostics;
using NCore.Resources;

namespace NCore.Validation
{
    public static class Ensure
    {
        public static T This<T>(T value)
        {
            return value;
        }
    }

    public static class EnsureExtensions
    {
        [DebuggerStepThrough]
        public static Guid IsNotEmpty(this Guid value, string name)
        {
            if(Guid.Empty.Equals(value))
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsNonEmptyGuid, name);

            return value;
        }

        [DebuggerStepThrough]
        public static ICollection<T> HasItems<T>(this ICollection<T> items, string name)
        {
            if (items == null || items.Count < 1)
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsNonEmptyCollection, name);

            return items;
        }

        [DebuggerStepThrough]
        public static T IsNotNull<T>(this T item, string name) where T : class
        {
            if (item == null)
                throw new ArgumentNullException(name, ExceptionMessages.EnsureExtensions_IsNotNull);

            return item;
        }

        [DebuggerStepThrough]
        public static int IsGtThan(this int value, int limit, string name)
        {
            if (value <= limit)
                throw new ArgumentOutOfRangeException(name, ExceptionMessages.EnsureExtensions_IsGtThan.Inject(value, limit));

            return value;
        }

        [DebuggerStepThrough]
        public static int IsGteThan(this int value, int limit, string name)
        {
            if (!(value >= limit))
                throw new ArgumentOutOfRangeException(name, ExceptionMessages.EnsureExtensions_IsGteThan.Inject(value, limit));

            return value;
        }

        [DebuggerStepThrough]
        public static int IsInRange(this int value, int min, int max, string name)
        {
            if (value < min)
                throw new ArgumentOutOfRangeException(name, ExceptionMessages.EnsureExtensions_IsInRange_ToLow.Inject(value, min));

            if (value > max)
                throw new ArgumentOutOfRangeException(name, ExceptionMessages.EnsureExtensions_IsInRange_ToHigh.Inject(value, max));

            return value;
        }

        [DebuggerStepThrough]
        public static string HasNonWhiteSpaceValue(this string item, string name)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentNullException(name);

            return item;
        }

        [DebuggerStepThrough]
        public static T IsTrue<T>(this T value, Func<T, bool> expression, string paramName)
        {
            if(!expression(value))
                throw new ArgumentException("", paramName);

            return value;
        }

        [DebuggerStepThrough]
        public static T IsFalse<T>(this T value, Func<T, bool> expression, string paramName)
        {
            if (expression(value))
                throw new ArgumentException("", paramName);

            return value;
        }
    }
}