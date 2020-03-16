using System;
using System.Collections.Generic;
using System.Text;

namespace LD
{
    class StudentManager
    {
        public List<Student> Students { get; set; }

        public StudentManager()
        {
            Students = new List<Student>();
        }

        public void stundentai()
        {
            Students = new List<Student>();
            Console.WriteLine("Iveskite studento varda, pavarde, namu darbu ir egzamino rezultata\n ");
            Boolean stop = false;
            while (stop != true) 
            {
                var ivedimas = Console.ReadLine();
                var vardas= ivedimas.Split(" ")?[0];
                var pavarde = ivedimas.Split(" ")?[1];
                var nd = ivedimas.Split(" ")?[2];
                var egz = ivedimas.Split(" ")?[3];
                var student = new Student();
                student.Vardas = vardas;
                student.Pavarde = pavarde;
                student.Nd.Add(double.Parse(nd));
                student.Egz = int.Parse(egz);
                Students.Add(student);
                Console.WriteLine("testi ivedima iveskite Y baigti N");
                var tb = Console.ReadLine();
                if (tb.ToUpper() == "Y") { }
                else stop = true;
            }

            foreach (var student in Students)
            {
                Console.WriteLine("{0} {1} {2} {3}", student.Vardas, student.Pavarde, student.Nd[0], student.Egz);
            }
        }
    }
}
