using System;

namespace Oliinyk_Lab4.Tools.Exceptions
{
    internal class PastBirthdayException : ArgumentException
    {
        public PastBirthdayException()
        {
        }

        public PastBirthdayException(string message) : base(message)
        {
        }

        public PastBirthdayException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PastBirthdayException(string message, string paramName) : base(message, paramName)
        {
        }

        public PastBirthdayException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}