using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        static void Main(string[] args)
        {
            
        }

        public int AddNumbers(string input)
        {
            if (String.IsNullOrEmpty(input))
                return 0;

            string[] strInput = input.Split(',');
            int sum = 0;
            foreach (string value in strInput)
            {
                sum += Convert.ToInt32(value);
            }
            return sum;
        }
    }
}
