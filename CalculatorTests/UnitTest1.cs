using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestAdd()
        {
            var calc = new Calculator();
            Assert.AreEqual(8, calc.Add(5, 3));
        }
        [TestMethod]
        public void TestSubtract()
        {
            var calc = new Calculator();
            Assert.AreEqual(2, calc.Subtract(5, 3));
        }
        [TestMethod]
        public void TestMultiply()
        {
            var calc = new Calculator();
            Assert.AreEqual(15, calc.Multiply(5, 3));
        }
        [TestMethod]
        public void TestDivide()
        {
            var calc = new Calculator();
            Assert.AreEqual(1, calc.Divide(5, 3));
        }
        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void TestDivideByZero()
        {
            var calc = new Calculator();
            calc.Divide(5, 0);
        }
    }
}
