using System;

namespace NCore
{
    internal static class Exceptions
    {
         internal static Exception NewException(string message)
         {
             return new NCoreException(message);
         }
    }
}