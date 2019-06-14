using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {

        char[] customSeperator = { ',', '\n' };

        static void Main(string[] args)
        {
            //Calculator ob = new Calculator();
            //ob.AddNumbers("1\n2,3\n4");
        }

        public int AddNumbers(string input)
        {
            if (String.IsNullOrEmpty(input))
                return 0;

            string[] strInput = input.Split(customSeperator);
            int sum = 0;
            foreach (string value in strInput)
            {
                sum += Convert.ToInt32(value);
            }
            return sum;
        }

    }
}
