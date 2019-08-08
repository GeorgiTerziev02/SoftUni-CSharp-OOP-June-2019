using System;

namespace Problem04Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string EXC_MESSAGE = "Invalid URL!";

        public InvalidURLException()
            : base(EXC_MESSAGE)
        {

        }

        public InvalidURLException(string message)
            : base(message)
        {

        }
    }
}
