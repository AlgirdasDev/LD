using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
                try
                {

                    Console.WriteLine("Sukurti studenta pasirinkite (1)\n" +
                        "Perziureti studentu sarasa pasirinkti (2)\n" +
                        "Nuskaityti studentus is failo (3)\n" +
                        "Studentu isvedimas i failus vargsiukai/kietiakai (4)\n" +
                        "Baigti programa iveskite (0)\n");
                    var input = Console.ReadLine();
                    if (int.Parse(input) == 1)
                    {
                        stundentai();
                    }
                    if (int.Parse(input) == 2)
                    {
                        studList();
                    }
                    if (int.Parse(input) == 3)
                    {
                        studentaifile(); 
                    }
                    if (int.Parse(input) == 4)
                    {
                        studentaiprint();
                    }
                    if (int.Parse(input) == 0) stop = false;
                }
                catch (FormatException e) 
                {
                    Console.WriteLine("\nERROR \n");
                    Console.WriteLine($"Generated message: {e.Message}");
                    Console.WriteLine("\nPress enter to continue");
                    Console.ReadLine();
                }
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
                student.Vardas = vardas;
                student.Pavarde = pavarde;
                Console.WriteLine("Jei norite sugeneruoti atsitiktinius pazymius iveskite (Y/N)");
                var generuoti = Console.ReadLine();
                if (generuoti.ToUpper() == "Y")
                {
                    Random rnd= new Random(); ;
                    for (int i = 0; i < 3; i++)
                    {
                        student.Nd.Add(rnd.Next(1,11));
                    }
                    student.Egz = rnd.Next(1, 11);
                }
                else
                {
                    Console.WriteLine("Jei zinote atliktu namu darbu skaiciu iveskite (Y/N)");
                    var nezinomi = Console.ReadLine();
                    if (nezinomi.ToUpper() == "Y")
                    {
                        Console.WriteLine("Iveskite atliktu namu darbu skaiciu");
                        var n = Console.ReadLine();
                        for (int i = 0; i < int.Parse(n); i++)
                        {
                            Console.WriteLine("Iveskite namu darbu rezultatus");
                            var nd = Console.ReadLine();
                            student.Nd.Add(double.Parse(nd));
                        }
                    }
                    if (nezinomi.ToUpper() == "N")
                    {
                        List<double> nzn = new List<double>();
                        Console.WriteLine("Iveskite namu darbu rezultatus baigus ivedima iveskite 'STOP'");
                        bool no = false;
                        while (no != true)
                        {
                            var pazymiai = Console.ReadLine();
                            if (pazymiai.ToUpper() == "STOP") no = true;
                            else student.Nd.Add(double.Parse(pazymiai));
                        }
                    }
                    
                    Console.WriteLine("Iveskite egzamino rezultata ");
                    var egz = Console.ReadLine();
                    student.Egz = int.Parse(egz);
                }
                Students.Add(student);
                
                Console.WriteLine("testi studentu ivedima? (Y/N)");
                var tb = Console.ReadLine();
                if (tb.ToUpper() == "Y") { }
                else stop = true;
            }
            galutinis();
            
        }
        public void galutinis() 
        {
            foreach (var student in Students)
            {
                double sum = 0;
                for (int i = 0; i < student.Nd.Count; i++)
                {
                    sum += student.Nd[i];
                }
                double vidurkis = (0.3 * (sum / student.Nd.Count)) + (0.7 * student.Egz);
                student.Galutinis = vidurkis;
                List<double> mediana = new List<double>();
                mediana.AddRange(student.Nd);
                mediana.Add(student.Egz);
                mediana.Sort();
                if ((mediana.Count) % 2 == 0)
                {
                    double s = (mediana[(mediana.Count - 1) / 2] + mediana[mediana.Count / 2]) / 2;
                    student.Mediana = s;
                }
                if ((mediana.Count) % 2 != 0)
                {
                    double s = mediana[mediana.Count / 2];
                    student.Mediana = s;
                }
            }
        }
        public void studList()
        {
            try
            {
                Console.WriteLine("Iveskite 1 jei norite kad programa spausdintu studentu sarasa pagal Galutinis(Vid.)\n" +
                    "Iveskite 2 jei norite kad programa spausdintu studentu sarasa pagal Galutinis(Med.)\n" +
                    "Iveskite 3 jei norite kad programa spausdintu studentu Galutinis(Vid.) ir Galutinis(Med.)");
                var input = Console.ReadLine();
                if (int.Parse(input) == 1)
                {
                    Console.WriteLine("{0,-20} {1,-20} {2,20}", "Vardas", "Pavarde", "Galutinis(Vid.)\n");
                    foreach (var student in Students.OrderBy(x => x.Vardas))
                    {
                        Console.WriteLine("{0, -20} {1, -20} {2, 20} ", student.Vardas, student.Pavarde, student.Galutinis.ToString("F"));
                    }
                }
                if (int.Parse(input) == 2)
                {
                    Console.WriteLine("{0,-20} {1,-20} {2,20}", "Vardas", "Pavarde", "Galutinis(Med.)\n");
                    foreach (var student in Students.OrderBy(x => x.Vardas))
                    {
                        Console.WriteLine("{0, -20} {1, -20} {2, 20} ", student.Vardas, student.Pavarde, student.Mediana.ToString("F"));
                    }
                }
                if (int.Parse(input) == 3)
                {

                    Console.WriteLine("{0,-20} {1,-20} {2,20} {3,20}", "Vardas", "Pavarde", "Galutinis(Vid.)", "Galutinis(Med.)\n");
                    foreach (var student in Students.OrderBy(x => x.Vardas))
                    {
                        Console.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} ", student.Vardas, student.Pavarde, student.Galutinis.ToString("F"), student.Mediana.ToString("F"));
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("\nERROR \n");
                Console.WriteLine($"Generated message: {e.Message}");
                Console.WriteLine("\nPress enter to continue");
                Console.ReadLine();
            }
        }
        public void studentaifile() 
        {
            List<String> path = new List<string>();
            for(int i =1; i <= 3; i++) 
            {
                string dir = @"C:\Users\algir\Desktop\Studentai"+i.ToString()+".txt";
                path.Add(dir);
            }
            for (int j = 0; j < path.Count; j++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                string[] records = File.ReadAllLines(path[j]);
                var eile = new List<String>();
                var pirmaeil = true;
                foreach (string record in records)
                {
                    if (pirmaeil)
                    {
                        eile = record.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                        pirmaeil = false;
                        continue;
                    }
                    var student = new Student();
                    var vardas = record.Split(' ', StringSplitOptions.RemoveEmptyEntries)?[0];
                    var pavarde = record.Split(' ', StringSplitOptions.RemoveEmptyEntries)?[1];
                    student.Vardas = vardas;
                    student.Pavarde = pavarde;
                    foreach (var studeile in eile.Where(nd => nd.Contains("ND")))
                    {
                        var pazymiai = record.Split(' ', StringSplitOptions.RemoveEmptyEntries)?[eile.IndexOf(studeile)];
                        student.Nd.Add(double.Parse(pazymiai));
                    }
                    var EgzIndex = eile.IndexOf("Egz.");
                    var egz = record.Split(' ', StringSplitOptions.RemoveEmptyEntries)?[EgzIndex];
                    student.Egz = double.Parse(egz);
                    Students.Add(student);
                }
                galutinis();
                sw.Stop();
                Console.WriteLine("Time Taken-->{0} ms", sw.ElapsedMilliseconds);
                
            }
        }
        public void studentaiprint() 
        {
            string pathString = @"C:\Users\algir\Desktop\Studentai";
            System.IO.Directory.CreateDirectory(pathString);
            using (System.IO.StreamWriter file1 =
            new System.IO.StreamWriter(@"C:\Users\algir\Desktop\Studentai\vargšiukai.txt"))
            using (System.IO.StreamWriter file2 =
            new System.IO.StreamWriter(@"C:\Users\algir\Desktop\Studentai\kietiakai.txt"))
                {
                    file1.WriteLine("{0,-20} {1,-20} {2,20} {3,20}", "Vardas", "Pavarde", "Galutinis(Vid.)", "Galutinis(Med.)\n");
                    file2.WriteLine("{0,-20} {1,-20} {2,20} {3,20}", "Vardas", "Pavarde", "Galutinis(Vid.)", "Galutinis(Med.)\n");
                foreach (var student in Students.OrderBy(x => x.Vardas))
                    {
                    if(student.Galutinis <5)
                        file1.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} ", student.Vardas, student.Pavarde, student.Galutinis.ToString("F"), student.Mediana.ToString("F"));
                    else
                        file2.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} ", student.Vardas, student.Pavarde, student.Galutinis.ToString("F"), student.Mediana.ToString("F"));
                }
                }
        }
    }
}
