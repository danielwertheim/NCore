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

    public static class EnsureGuidExtensions
    {
        [DebuggerStepThrough]
        public static Guid IsNotEmpty(this Guid value, string name)
        {
            if (Guid.Empty.Equals(value))
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsNonEmptyGuid, name);

            return value;
        }
    }

    public static class EnsureStringExtensions
    {
        [DebuggerStepThrough]
        public static string HasNonWhiteSpaceValue(this string item, string name)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_HasNonWhiteSpaceValue, name);

            return item;
        }
    }

    public static class EnsureNumericExtensions
    {
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
    }

    public static class EnsureCollectionExtensions
    {
        [DebuggerStepThrough]
        public static ICollection<T> HasItems<T>(this ICollection<T> items, string name)
        {
            if (items == null || items.Count < 1)
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsNonEmptyCollection, name);

            return items;
        }
    }

    public static class EnsureObjectExtensions
    {
        [DebuggerStepThrough]
        public static T IsNotNull<T>(this T item, string name) where T : class
        {
            if (item == null)
                throw new ArgumentNullException(name, ExceptionMessages.EnsureExtensions_IsNotNull);

            return item;
        }        
    }

    public static class EnsureExpressionExtensions
    {
        [DebuggerStepThrough]
        public static T IsTrueFor<T>(this Func<T, bool> expression, T value, string paramName)
        {
            if (!expression(value))
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsTrueFor, paramName);

            return value;
        }

        [DebuggerStepThrough]
        public static T IsFalseFor<T>(this Func<T, bool> expression, T value, string paramName)
        {
            if (expression(value))
                throw new ArgumentException(ExceptionMessages.EnsureExtensions_IsFalseFor, paramName);

            return value;
        }
    }
}