using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculator.Test
{
    [TestClass]
    public class CalculatorTests
    {
        Calculator objCal;

        [TestInitialize]
        public void Initialize()
        {
            objCal = new Calculator();
        }

        [TestMethod]
        public void Empty_Zero()
        {
            int output= objCal.AddNumbers("");
            Assert.AreEqual(0, output);
        }

        [TestMethod]
        public void CheckSingleNumberSum()
        {
            int output = objCal.AddNumbers("1");
            Assert.AreEqual(1, output);
        }

        [TestMethod]
        public void Check2NumbersSum()
        {
            int output = objCal.AddNumbers("1,2");
            Assert.AreEqual(3, output);
        }

        [TestMethod]
        public void CheckNnumberSum()
        {
            int output = objCal.AddNumbers("1,2,3,5");
            Assert.AreEqual(11, output);
        }

        [TestMethod]
        public void CheckNewLineInputReturnSum()
        {
            int output = objCal.AddNumbers("1\n2,3,4");
            Assert.AreEqual(10, output);
        }
    }
}
