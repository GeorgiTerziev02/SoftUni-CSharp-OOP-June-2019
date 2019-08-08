using System;

namespace Logger.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        private const string EXC_MESSAGE = "Invalid DateTime Format!";
        public InvalidDateFormatException()
            : base(EXC_MESSAGE)
        {

        }

        public InvalidDateFormatException(string message)
            : base(message)
        {

        }

        public InvalidDateFormatException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
