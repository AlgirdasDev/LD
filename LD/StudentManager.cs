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

        public void menu()
        { 
            stundentai();
            studList();
        }
        public void stundentai()
        {   
                       
            Boolean stop = false;
            while (stop != true) 
            {
                var student = new Student();
                Console.WriteLine("Iveskite studento varda, pavarde ");
                var ivedimas = Console.ReadLine();
                var vardas= ivedimas.Split(" ")?[0];
                var pavarde = ivedimas.Split(" ")?[1];
                Console.WriteLine("Iveskite atliktu namu darbu skaiciu");
                var n = Console.ReadLine();
                for (int i = 0; i < int.Parse(n); i++) 
                {
                    Console.WriteLine("Iveskite namu darbu rezultatus");
                    var nd = Console.ReadLine();
                    student.Nd.Add(double.Parse(nd));
                }
                student.Vardas = vardas;
                student.Pavarde = pavarde;
                Console.WriteLine("Iveskite egzamino rezultata ");
                var egz = Console.ReadLine();
                student.Egz = int.Parse(egz);
                double sum = 0;
                for (int i = 0; i < student.Nd.Count; i++)
                {
                        sum += student.Nd[i];
                }
                double vidurkis = (0.3 * (sum / student.Nd.Count)) + (0.7 * student.Egz);
                student.Galutinis = vidurkis;
                Students.Add(student);
                Console.WriteLine("testi studentu ivedima? (Y/N)");
                var tb = Console.ReadLine();
                if (tb.ToUpper() == "Y") { }
                else stop = true;
            }

            
        }
        public void studList()
        {
            Console.WriteLine("{0,-20} {1,-20} {2,20}","Vardas","Pavarde","Galutinis(Vid.)\n");
            foreach (var student in Students)
            {
                Console.WriteLine("{0, -20} {1, -20} {2, 20}", student.Vardas, student.Pavarde, student.Galutinis.ToString("F"));
            }
        }
    }
}
