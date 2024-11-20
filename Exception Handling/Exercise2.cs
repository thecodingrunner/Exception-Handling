using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling
{
    internal class Exercise2
    {
        public static void HealthInsuranceDataInput()
        {
            Console.WriteLine("\n--- Thank you for choosing Blummin Health insurance! ---\n");
            Console.WriteLine("Please input your data:");

            Person inputPerson = GetInput();

            // Name
            
            string name = inputPerson.Name;

            // Age
            int age = (int)inputPerson.Age;

            // Height

            double height = (double)inputPerson.Height;

            // Height
            double weight = (double)inputPerson.Weight;

            // Employment
            bool employed = (bool)inputPerson.Employed;

            // Occupation
            Console.WriteLine("What is your occupation?: ");
            string occupation = Console.ReadLine();

            // Student
            Console.WriteLine("Are you a student?: ");
            string isStudent = Console.ReadLine();

            Console.WriteLine("\nThank you, " + name + ", for providing your information!");
            Console.WriteLine("Your Blummin monthly subscription is: £"
                    + CalculateSubscriptionCharge(age, height, Double.Parse(weight), occupation, bool.Parse(isStudent)));
        }

        private static double CalculateSubscriptionCharge(int age, double height, double weight, string occupation, bool isStudent)
        {
            List<double> factors = new List<double>()
        {
            0.5D, // Base rate
            CalculateAgeFactor(age),
            CalculateHeightFactor(height),
            CalculateWeightFactor(weight),
            occupation.ToLower() == "doctor" ? 0.9D : 1.0D,
            isStudent ? 0.8D : 1.0D
        };

            return factors.Aggregate(1.0, (a, b) => a * b);
        }

        private static double CalculateAgeFactor(int age)
        {
            return Math.Max(100 + (age - 18) * 5, 1);
        }

        private static double CalculateHeightFactor(double height)
        {
            return Math.Abs(Math.Pow(height, 2) - 2);
        }

        private static double CalculateWeightFactor(double weight)
        {
            return 2 * weight;
        }

        private static Person GetInput()
        {
            Person personInput = new Person(null, null, null, null, null, null, null);

            while (!personInput.NameValid)
            {
                try
                {
                    Console.WriteLine("Enter your full name: ");
                    personInput.Name = Console.ReadLine();
                    if (String.IsNullOrEmpty(personInput.Name))
                    {
                        throw new NullReferenceException("No name was entered.");
                    }
                    if (!personInput.Name.Contains(" "))
                    {
                        throw new InvalidNameException("Must include first and last name, seperated by a space");
                    }

                    personInput.NameValid = true;
                }
                catch (InvalidNameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            while (!personInput.AgeValid)
            {
                string ageInput;
                try
                {
                    Console.WriteLine("Enter your age: ");
                    ageInput = Console.ReadLine();

                    if (String.IsNullOrEmpty(ageInput))
                    {
                        throw new NullReferenceException("No age was entered.");
                    }
                    if (!Int32.TryParse(ageInput, out int j))
                    {
                        throw new ArgumentException("An age must be a valid number.");
                    }
                    personInput.Age = j;

                    if (personInput.Age <= 0)
                    {
                        throw new ArgumentException("Age must be above 0");
                    }
                    personInput.AgeValid = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            while (!personInput.HeightValid)
            {
                string heightInput;
                try
                {
                    Console.WriteLine("Enter your height (in meteres): ");
                    heightInput = Console.ReadLine();

                    if (String.IsNullOrEmpty(heightInput))
                    {
                        throw new NullReferenceException("No height was entered.");
                    }
                    if (!Double.TryParse(heightInput, out double j))
                    {
                        throw new ArgumentException("Height must be a valid number.");
                    }
                    personInput.Height = j;

                    if (personInput.Height <= 0)
                    {
                        throw new ArgumentException("Height is too small.");
                    }
                    if (personInput.Height > 3)
                    {
                        throw new ArgumentException("Height is too tall.");
                    }
                    personInput.HeightValid = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            while (!personInput.WeightValid)
            {
                string weightInput;
                try
                {
                    Console.WriteLine("Enter your weight (in kg): ");
                    weightInput = Console.ReadLine();

                    if (String.IsNullOrEmpty(weightInput))
                    {
                        throw new NullReferenceException("No weight was entered.");
                    }
                    if (!Double.TryParse(weightInput, out double j))
                    {
                        throw new ArgumentException("Weight must be a valid number.");
                    }
                    personInput.Weight = j;

                    if (personInput.Weight <= 0)
                    {
                        throw new ArgumentException("Weight is too small.");
                    }
                    if (personInput.Weight > 650)
                    {
                        throw new ArgumentException("You're too heavy.");
                    }
                    personInput.WeightValid = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            while (!personInput.EmployedValid)
            {
                string isEmployedString;
                try
                {
                    Console.WriteLine("Are you employed? (Y/N)");
                    isEmployedString = Console.ReadLine().ToLower();

                    if (isEmployedString != "y" && isEmployedString != "n")
                    {
                        throw new ArgumentException("Please enter a valid response.");
                    }

                    if (isEmployedString == "y")
                    {
                        personInput.Employed = true;
                    } else
                    {
                        personInput.Employed = false;
                    }

                    personInput.EmployedValid = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (personInput.Employed == true)
            {
                while (!personInput.Occupation)
                {
                    try
                    {
                        Console.WriteLine("Enter your full name: ");
                        personInput.Name = Console.ReadLine();
                        if (String.IsNullOrEmpty(personInput.Name))
                        {
                            throw new NullReferenceException("No name was entered.");
                        }
                        if (!personInput.Name.Contains(" "))
                        {
                            throw new InvalidNameException("Must include first and last name, seperated by a space");
                        }

                        personInput.NameValid = true;
                    }
                    catch (InvalidNameException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return personInput;
        }
    }
}
