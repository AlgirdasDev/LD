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
            bool stop = true;
            while (stop != false)
            {
                Console.WriteLine("Sukurti studenta pasirinkite (1)\n" +
                    "Perziureti studentu sarasa pasirinkti (2)\n" +
                    "Baigti programa iveskite (0)");
                var input = Console.ReadLine();
                if (int.Parse(input) == 1)
                {
                    stundentai();
                }
                if (int.Parse(input) == 2)
                {
                    studList();
                }
                if (int.Parse(input) == 0) stop = false;
            }
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
                List<double> mediana= new List<double>();
                mediana.AddRange(student.Nd);
                mediana.Add(int.Parse(egz));
                if ((mediana.Count) % 2 == 0)
                {
                    double s = (mediana[(mediana.Count-1) / 2] + mediana[mediana.Count / 2]) / 2;
                    student.Mediana = s;
                }
                if ((mediana.Count) % 2 != 0) 
                {
                    double s = mediana[mediana.Count / 2];
                    student.Mediana = s;
                }               
                Students.Add(student);
                Console.WriteLine("testi studentu ivedima? (Y/N)");
                var tb = Console.ReadLine();
                if (tb.ToUpper() == "Y") { }
                else stop = true;
            }

            
        }
        public void studList()
        {
            Console.WriteLine("Iveskite 1 jei norite kad programa spausdintu studentu sarasa pagal Galutinis(Vid.)\n" +
                "Iveskite 2 jei norite kad programa spausintu studentu sarasa pagal Galutinis(Med.)");
            var input = Console.ReadLine();
            if (int.Parse(input) == 1) 
            { 
                Console.WriteLine("{0,-20} {1,-20} {2,20}","Vardas","Pavarde","Galutinis(Vid.)\n");
                foreach (var student in Students)
                {
                    Console.WriteLine("{0, -20} {1, -20} {2, 20} ", student.Vardas, student.Pavarde, student.Galutinis.ToString("F"));
                }
            }
            if (int.Parse(input) == 2)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,20}", "Vardas", "Pavarde", "Galutinis(Med.)\n");
                foreach (var student in Students)
                {
                    Console.WriteLine("{0, -20} {1, -20} {2, 20} ", student.Vardas, student.Pavarde, student.Mediana.ToString("F"));
                }
            }
        }
    }
}
