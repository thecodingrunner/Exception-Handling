using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling
{
    internal class Exercise1
    {
        public static int? Divide(double a, double b)
        {
                return (int)a / (int)b;
        }
        public static void DivideUserInputs()
        {

            while (true)
            {
                InputResult inputs = GetUserInputs();
                if (inputs.Success)
                {
                    Console.WriteLine(Divide(inputs.Result[0], inputs.Result[1]));
                    break;
                } else
                {
                    Console.WriteLine(inputs.Message);
                }
            }

        }
        private static InputResult GetUserInputs()
        {
            Console.WriteLine("Enter divisor:");
            if (!Double.TryParse(Console.ReadLine(), out double divisor))
            {
                return new InputResult(false, null, "Invalid input. Please try again.");
            }
            Console.WriteLine("Enter dividend:");
            if (!Double.TryParse(Console.ReadLine(), out double dividend))
            {
                return new InputResult(false, null, "Invalid input. Please try again.");
            }

            if (dividend == 0) return new InputResult(false, null, "Cannot divide by 0. Please try again.");
            
            List<double> invalidInputs = new List<double>();
            if (divisor < 0) invalidInputs.Add(divisor);
            if (dividend < 0) invalidInputs.Add(dividend);

            if (invalidInputs.Count == 1)
            {
                return new InputResult(false, null, $"The following negative integer(s) are not allowed in this operation: [{invalidInputs[0]}]");
            } else if (invalidInputs.Count == 2)
            {
                return new InputResult(false, null, $"The following negative integer(s) are not allowed in this operation: [{invalidInputs[0]}] and [{invalidInputs[1]}]");
            }
            return new InputResult(true, [divisor, dividend], "");
        }
    }
}
