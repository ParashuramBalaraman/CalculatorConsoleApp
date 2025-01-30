using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculatorNS;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestAddInt()
        {
            double result = new Calculator().Calculate(10, 32, "1");
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void TestSubtractInt()
        {
            double result = new Calculator().Calculate(45, 41, "2");
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestMultiplyInt()
        {
            double result = new Calculator().Calculate(5, 4, "3");
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TestDivideInt()
        {
            double result = new Calculator().Calculate(672, 16, "4");
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void TestAddFloat()
        {
            double result = new Calculator().Calculate(11.3, 8.5, "1");
            Assert.AreEqual(19.8, result);
        }

        [TestMethod]
        public void TestSubtractFloat()
        {
            double result = new Calculator().Calculate(32.7, 15.9, "2");
            Assert.AreEqual(16.8, result);
        }

        [TestMethod]
        public void TestMultiplyFloat()
        {
            double result = new Calculator().Calculate(5.4, 6.3, "3");
            Assert.AreEqual(34.02, result);
        }

        [TestMethod]
        public void TestDivideFloat()
        {
            double result = new Calculator().Calculate(15.8, 22.3, "4");
            Assert.AreEqual(0.7085, result);
        }
    }
}
