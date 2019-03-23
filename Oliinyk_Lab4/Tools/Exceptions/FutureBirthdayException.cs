using System;

namespace Oliinyk_Lab4.Tools.Exceptions
{
    internal class FutureBirthdayException : ArgumentException
    {
        public FutureBirthdayException()
        {
        }

        public FutureBirthdayException(string message) : base(message)
        {
        }

        public FutureBirthdayException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public FutureBirthdayException(string message, string paramName) : base(message, paramName)
        {
        }

        public FutureBirthdayException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}