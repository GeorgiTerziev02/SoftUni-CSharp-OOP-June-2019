using System;

namespace CustomTestingFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodAttribute : Attribute
    {
        public TestMethodAttribute()
        {
        }
    }
}
