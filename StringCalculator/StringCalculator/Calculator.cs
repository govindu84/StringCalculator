using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        string delimiter = "//";
        int Default_Value = 0;
        List<string> customSeperators = new List<string>() { ",", "\n" };
        int max = 1000;

        static void Main(string[] args)
        {
            //Calculator ob = new Calculator();
            //ob.AddNumbers("//[*][%]\n1*2%3");
        }

        public int AddNumbers(string input)
        {
            if (String.IsNullOrEmpty(input))
                return Default_Value;
            if (input.StartsWith(delimiter))
            {
                input = AddSeperators(input);
            }

            string[] strInput = input.Split(customSeperators.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var lstNumbers = new List<int>();
            foreach (var num in strInput)
            {
                var number = int.Parse(num);
                if (number < 0)
                {
                    throw new ApplicationException("negatives not allowed in input");
                }
                if (number <= max)
                {
                    lstNumbers.Add(number);
                }
            }

            return lstNumbers.Sum();
        }
        private string AddSeperators(string input)
        {
            string[] customSeperatorsInput = { delimiter, "[", "]" };
            var customSeperator = input.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();

            input = input.Substring(customSeperator.Length, input.Length - customSeperator.Length);
            var customSeperatorsAll = customSeperator.Split(customSeperatorsInput, StringSplitOptions.RemoveEmptyEntries);

            foreach (var value in customSeperatorsAll)
            {
                customSeperators.Add(value);
            }
            return input;
        }
    }
}
