using System;

namespace Oliinyk_Lab4.Tools.Exceptions
{
    internal class TooShortSurnameException : ArgumentException
    {
        public TooShortSurnameException()
        {
        }

        public TooShortSurnameException(string message) : base(message)
        {
        }

        public TooShortSurnameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public TooShortSurnameException(string message, string paramName) : base(message, paramName)
        {
        }

        public TooShortSurnameException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}