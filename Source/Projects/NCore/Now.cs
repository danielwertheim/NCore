using System;

namespace NCore
{
    public static class Now
    {
        public static Func<DateTime> ValueFn;
        public static Func<DateTime> UtcFn;
 
        public static DateTime Value
        {
            get { return ValueFn.Invoke(); }
        }

        public static DateTime ValueUtc
        {
            get { return UtcFn.Invoke(); }
        }

        static Now()
        {
            Reset();
        }

        public static void Reset()
        {
            ValueFn = () => DateTime.Now;
            UtcFn = () => DateTime.UtcNow;
        }
    }
}