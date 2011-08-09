namespace NCore.Validation
{
    public class Param<T>
    {
        public readonly string Name;

        public readonly T Value;

        internal Param(string name, T value)
        {
            Name = name;
            Value = value;
        }
    }
}