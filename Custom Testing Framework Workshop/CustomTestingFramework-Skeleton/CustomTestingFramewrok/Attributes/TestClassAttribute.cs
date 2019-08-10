using System;

namespace CustomTestingFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestClassAttribute : Attribute
    {
        public TestClassAttribute()
        {
        }
    }
}
