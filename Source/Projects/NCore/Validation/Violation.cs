using System;

namespace NCore.Validation
{
    [Serializable]
    public class Violation
    {
        public enum Types
        {
            Generic,
            Required,
            NotUnique,
            NotFound
        }
        public string Key { get; private set; }
        public string Message { get; private set; }
        public Types Type { get; private set; }

        public Violation(string key, string message, Types type = Types.Generic)
        {
            if(string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("key");
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException("message");

            Key = key;
            Message = message;
            Type = type;
        }
    }
}