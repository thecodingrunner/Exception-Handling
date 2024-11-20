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
                try
                {
                    double[] inputs = GetUserInputs();
                    Console.WriteLine(Divide(inputs[0], inputs[1]));
                    int divideTest = (int)inputs[0] / (int)inputs[1];
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero. Try again.");
                }
            }

        }
        private static double[] GetUserInputs()
        {
            Console.WriteLine("Enter divisor:");
            if (!Double.TryParse(Console.ReadLine(), out double divisor))
            {
                throw new FormatException("Invalid input. Please try again.");
            }
            Console.WriteLine("Enter dividend:");
            if (!Double.TryParse(Console.ReadLine(), out double dividend))
            {
                throw new FormatException("Invalid input. Please try again.");
            }
            if (divisor < 0 || dividend < 0)
            {
                throw new NegativeIntegerInputException();
            }
            return [divisor, dividend];
        }
    }
}
