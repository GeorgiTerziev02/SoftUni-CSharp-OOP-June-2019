using System;

namespace CustomTestingFramework.Exceptions
{
    public class TestException : Exception
    {
        public TestException(string message) 
            : base(message)
        {

        }
    }
}
