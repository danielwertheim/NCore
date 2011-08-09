namespace NCore.Validation
{
    public static class Ensure
    {
        public static Param<T> Param<T>(T value, string name)
        {
            return new Param<T>(name, value);
        }
    }
}