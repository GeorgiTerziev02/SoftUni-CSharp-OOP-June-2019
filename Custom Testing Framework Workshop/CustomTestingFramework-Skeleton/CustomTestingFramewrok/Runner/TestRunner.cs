using CustomTestingFramework.Attributes;
using CustomTestingFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomTestingFramework.Runner
{
    public class TestRunner
    {
        public List<string> Run(string path)
        {
            var listOfResults = new List<string>();

            var testClasses = Assembly
                .LoadFile(path)
                .GetTypes()
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(TestClassAttribute)))
                .ToList();

            foreach (var classType in testClasses)
            {
                var testMethods = classType
                    .GetMethods()
                    .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(TestMethodAttribute)))
                    .ToList();

                var classInstance = Activator.CreateInstance(classType);

                foreach (var testMethod in testMethods)
                {
                    try
                    {
                        var methodResult = testMethod
                            .Invoke(classInstance, new object[] { });

                        listOfResults.Add($"{testMethod.Name} passed successfully!");
                    }
                    catch (TargetInvocationException ex)
                    {
                        listOfResults.Add($"{testMethod.Name} failed! - {ex.InnerException.Message}");
                    }
                }
            }

            return listOfResults;
        }
    }
}
