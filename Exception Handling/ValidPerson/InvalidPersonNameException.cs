using System;
using System.Runtime.Serialization;

namespace ValidPerson
{
    class InvalidPersonNameException : Exception
    {
        private const string INVALID_NAME = "Name must contain only letters";
        public InvalidPersonNameException()
            :base(INVALID_NAME)
        {

        }

        public InvalidPersonNameException(string message) 
            : base(message)
        {

        }

    }
}
