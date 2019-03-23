using System;

namespace Oliinyk_Lab4.Tools.Exceptions
{
    internal class UncorrectEmailException : ArgumentException
    {
        public UncorrectEmailException()
        {
        }

        public UncorrectEmailException(string message) : base(message)
        {
        }

        public UncorrectEmailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UncorrectEmailException(string message, string paramName) : base(message, paramName)
        {
        }

        public UncorrectEmailException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}