using System;

namespace Oliinyk_Lab4.Tools.Exceptions
{
    internal class TooShortNameException : ArgumentException
    {
        public TooShortNameException()
        {
        }

        public TooShortNameException(string message) : base(message)
        {
        }

        public TooShortNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public TooShortNameException(string message, string paramName) : base(message, paramName)
        {
        }

        public TooShortNameException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}