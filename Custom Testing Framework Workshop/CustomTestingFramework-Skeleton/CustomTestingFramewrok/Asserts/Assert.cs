using CustomTestingFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTestingFramework.Asserts
{
    public abstract class Assert
    {
        public static bool AreEqual(int a, int b)
        {
            if (a != b)
            {
                throw new TestException("Values are different!");
            }

            return true;
        }
    }
}
