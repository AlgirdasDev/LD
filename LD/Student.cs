using System;
using System.Collections.Generic;
using System.Text;

namespace LD
{
    class Student
    {
        public string Vardas { get; set; }

        public string Pavarde { get; set; }

        public List<double> Nd { get; set; }

        public double Egz { get; set; }

        public double Galutinis { get; set; }

        public double Mediana { get; set; }
        public Student()
        {
            Nd = new List<double>();
        }
    }
}
