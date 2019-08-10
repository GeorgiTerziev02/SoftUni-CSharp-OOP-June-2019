using CustomTestingFramework.Asserts;
using CustomTestingFramework.Attributes;
using MySpecialApp;

namespace CustomTestingFramework.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void ShouldSumSuccessfullyTwoValue()
        {
            //arrange
            int a = 10;
            int b = 20;
            int expectedResult = 30;

            //act
            Calculator calculator = new Calculator();
            var actualResult = calculator.Sum(a, b);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ShouldDivideSuccessfullyTwoValue()
        {
            //arrange
            int a = 10;
            int b = 1;
            int expectedResult = 55;

            //act
            Calculator calculator = new Calculator();
            var actualResult = calculator.Divide(a, b);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
