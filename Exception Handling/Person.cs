using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling
{
    public class Person
    {
        public string? Name { get; set; }
        public bool NameValid { get; set; }
        public int? Age { get; set; }
        public bool AgeValid { get; set; }
        public double? Height { get; set; }
        public bool HeightValid { get; set; }
        public double? Weight { get; set; }
        public bool WeightValid { get; set; }   
        public bool? Employed { get; set; }
        public bool EmployedValid { get; set; }
        public string? Occupation { get; set; }
        public bool OccupationValid { get; set; }
        public bool? Student { get; set; }
        public bool StudentValid { get; set; }


        public Person(string? name, int? age, double? height, double? weight, bool? employed, string? occupation, bool? student)
        {
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
            Employed = employed;
            Occupation = occupation;
            Student = student;

            NameValid = false;
            AgeValid = false;
            HeightValid = false;
            WeightValid = false;
            EmployedValid = false;
            OccupationValid = false;
            StudentValid = false;
        }
    }
}
