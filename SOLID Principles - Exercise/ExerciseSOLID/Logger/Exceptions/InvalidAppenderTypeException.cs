﻿using System;

namespace Logger.Exceptions
{
    public class InvalidAppenderTypeException : Exception
    {
        private const string EXC_MESSAGE = "Invalid Appender Type!";
        public InvalidAppenderTypeException()
            : base(EXC_MESSAGE)
        {

        }

        public InvalidAppenderTypeException(string message)
            : base(message)
        {

        }
    }
}
