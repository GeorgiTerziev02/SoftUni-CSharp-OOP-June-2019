using System;
using System.Linq;

namespace ValidPerson
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        "value",
                        "The first name cannot be null or empty.");
                }

                foreach (char c in value)
                {
                    if(!char.IsLetter(c))
                    {
                        throw new InvalidPersonNameException();
                    }
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        "value",
                        "The last name cannot be null or empty.");
                }

                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new InvalidPersonNameException();
                    }
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException(
                        "value",
                        "Age should be in the range [0 ... 120].");
                }

                this.age = value;
            }
        }
    }
}
