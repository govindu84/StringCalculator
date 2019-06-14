using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        private const string DELIMITER = "//";
        private const int DEFAULT_VALUE = 0;
        private int MAX = 1000;
        List<string> customSeperators = new List<string>() { ",", "\n" };
   
        /// <summary>
        /// Perform Addition of numbers in a input string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int AddNumbers(string input)
        {
            if (String.IsNullOrEmpty(input))
                return DEFAULT_VALUE;
            if (input.StartsWith(DELIMITER))
            {
                input = AddSeperators(input);
            }

            //split the input by provided delimiters
            string[] strInput = input.Split(customSeperators.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var lstNumbers = new List<int>();
            foreach (var num in strInput)
            {
                var number = int.Parse(num);
                if (number < 0)
                {
                    throw new ApplicationException("negatives not allowed in input"); //Throw the exception, if input have negitve numbers
                }
                if (number <= MAX)
                {
                    lstNumbers.Add(number);
                }
            }

            return lstNumbers.Sum();
        }


        private string AddSeperators(string input)
        {
            string[] customSeperatorsInput = { DELIMITER, "[", "]" };
            var customSeperator = input.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();

            input = input.Substring(customSeperator.Length, input.Length - customSeperator.Length);
            var customSeperatorsAll = customSeperator.Split(customSeperatorsInput, StringSplitOptions.RemoveEmptyEntries);

            foreach (var value in customSeperatorsAll)
            {
                customSeperators.Add(value);
            }
            return input;
        }


        static void Main(string[] args)
        {
            Calculator objCal = new Calculator();
            objCal.AddNumbers("//[*][%]\n1*2%3");
        }
    }
}
