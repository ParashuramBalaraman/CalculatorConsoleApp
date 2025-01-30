using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculatorNS;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestAdd()
        {
            double result = new Calculator().Calculate(1, 2, "1");
            Assert.AreEqual(3, result);
        }
    }
}
