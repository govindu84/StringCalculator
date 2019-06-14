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
       [TestMethod]
        public void CheckDifferentDelimiterSum()
        {
            var result = objCal.AddNumbers("//A\n3A4");
            Assert.AreEqual(7, result);
        }
       [TestMethod]
        public void CheckDifferentDelimiterSum2()
        {
            var result = objCal.AddNumbers("//B\n2B3");
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void AddNumber1000Ignored()
        {
            var result = objCal.AddNumbers("2,1001");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CheckNegativeException()
        {
            var result = objCal.AddNumbers("-1");
        }
       
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void SendNegativeandPositive_ThrowsOnlytheNegative()
        {
            var result = objCal.AddNumbers("-1,5");
        }

        [TestMethod]    
        public void AcceptMultipleDelimeters()
        {
            var result = objCal.AddNumbers("//[*][%]\n1*2%3");
            Assert.AreEqual(6, result);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (objCal != null)
            {
                objCal = null;
            }

        }

    }
}
