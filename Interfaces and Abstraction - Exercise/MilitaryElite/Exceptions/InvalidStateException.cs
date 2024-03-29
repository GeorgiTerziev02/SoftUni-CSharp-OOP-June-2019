﻿using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string EXC_MESSAGE = "Invalid mission state";
        public InvalidStateException()
            :base(EXC_MESSAGE)
        {

        }

        public InvalidStateException(string message) 
            : base(message)
        {

        }
    }
}
