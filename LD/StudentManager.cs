using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
                        "Studentu generavimas ir isvedimas i failus (4)\n" +
                        "Studentu isveddimas i failus vargsiukai/kietiakai (5)\n" +
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
                        studentaigenerate();
                    }
                    if (int.Parse(input) == 5)
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
                    Random rnd= new Random(); 
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
            string path = @"C:\Users\algir\Desktop\Studentai.txt";
            string[] records = File.ReadAllLines(path);
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
        }
        public void studentaigenerate()
        {
            for (int i=1;i<=10000000; i++)
            {
                var student = new Student();
                Random rnd = new Random();
                var vardas = "Vardas" + i.ToString();
                var pavarde = "Pavarde" + i.ToString();
                var egz = rnd.Next(1, 11);
                student.Vardas = vardas;
                student.Pavarde = pavarde;
                student.Egz = egz;
                for (int j = 1; j <= 6; j++) 
                {
                    student.Nd.Add(rnd.Next(1, 11));
                }
                Students.Add(student);               
            }
            galutinis();
            Stopwatch sw = new Stopwatch();

            string strPath = Environment.GetFolderPath(
                         System.Environment.SpecialFolder.DesktopDirectory);
            string pathString = System.IO.Path.Combine(strPath, "Studentai");
            System.IO.Directory.CreateDirectory(pathString);
            for (int i = 1; i <= 5; i++) 
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(pathString +@"\Studentai" + i.ToString() + ".txt"))
                {
                    
                    if (i == 1)
                    {
                        sw.Start();
                        file.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} {4, 20} {5,20} {6, 20} {7,20} {8, 20}", "Vardas", "Pavarde", "ND1", "ND2", "ND3", "ND4", "ND5", "ND6", "Egz.\n");
                        for (int j=0;j<1000;j++)
                        { 
                                file.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} {4, 20} {5,20} {6, 20} {7,20} {8, 20}", Students[j].Vardas, Students[j].Pavarde, Students[j].Nd[0], Students[j].Nd[1], Students[j].Nd[2], Students[j].Nd[3], Students[j].Nd[4], Students[j].Nd[5], Students[j].Egz);
                        }
                        sw.Stop();
                        Console.WriteLine("Time Taken-->{0} ms", sw.ElapsedMilliseconds);
                    }
                    if (i == 2)
                    { 
                        sw.Start();
                        file.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} {4, 20} {5,20} {6, 20} {7,20} {8, 20}", "Vardas", "Pavarde", "ND1", "ND2", "ND3", "ND4", "ND5", "ND6", "Egz.\n");
                        for (int j = 0; j < 10000; j++)
                        {
                            file.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} {4, 20} {5,20} {6, 20} {7,20} {8, 20}", Students[j].Vardas, Students[j].Pavarde, Students[j].Nd[0], Students[j].Nd[1], Students[j].Nd[2], Students[j].Nd[3], Students[j].Nd[4], Students[j].Nd[5], Students[j].Egz);
                        }
                        sw.Stop();
                        Console.WriteLine("Time Taken-->{0} ms", sw.ElapsedMilliseconds);
                    }
                    if (i == 3)
                    {
                        sw.Start();
                        file.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} {4, 20} {5,20} {6, 20} {7,20} {8, 20}", "Vardas", "Pavarde", "ND1", "ND2", "ND3", "ND4", "ND5", "ND6", "Egz.\n");
                        for (int j = 0; j < 100000; j++)
                        {
                            file.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} {4, 20} {5,20} {6, 20} {7,20} {8, 20}", Students[j].Vardas, Students[j].Pavarde, Students[j].Nd[0], Students[j].Nd[1], Students[j].Nd[2], Students[j].Nd[3], Students[j].Nd[4], Students[j].Nd[5], Students[j].Egz);
                        }
                        sw.Stop();
                        Console.WriteLine("Time Taken-->{0} ms", sw.ElapsedMilliseconds);
                    }
                    if (i == 4)
                    {
                        sw.Start();
                        file.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} {4, 20} {5,20} {6, 20} {7,20} {8, 20}", "Vardas", "Pavarde", "ND1", "ND2", "ND3", "ND4", "ND5", "ND6", "Egz.\n");
                        for (int j = 0; j < 1000000; j++)
                        {
                            file.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} {4, 20} {5,20} {6, 20} {7,20} {8, 20}", Students[j].Vardas, Students[j].Pavarde, Students[j].Nd[0], Students[j].Nd[1], Students[j].Nd[2], Students[j].Nd[3], Students[j].Nd[4], Students[j].Nd[5], Students[j].Egz);
                        }
                        sw.Stop();
                        Console.WriteLine("Time Taken-->{0} ms", sw.ElapsedMilliseconds);
                    }
                    if (i == 5)
                    {   
                        sw.Start();
                        file.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} {4, 20} {5,20} {6, 20} {7,20} {8, 20}", "Vardas", "Pavarde", "ND1", "ND2", "ND3", "ND4", "ND5", "ND6", "Egz.\n");
                        for (int j = 0; j < 10000000; j++)
                        {
                            file.WriteLine("{0, -20} {1, -20} {2, 20} {3,20} {4, 20} {5,20} {6, 20} {7,20} {8, 20}", Students[j].Vardas, Students[j].Pavarde, Students[j].Nd[0], Students[j].Nd[1], Students[j].Nd[2], Students[j].Nd[3], Students[j].Nd[4], Students[j].Nd[5], Students[j].Egz);
                        }
                        sw.Stop();
                        Console.WriteLine("Time Taken-->{0} ms", sw.ElapsedMilliseconds);
                    }
                    
                }
            }
        }
        public void studentaiprint() 
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string strPath = Environment.GetFolderPath(
                         System.Environment.SpecialFolder.DesktopDirectory);
            string pathString1 = System.IO.Path.Combine(strPath, "Studentai");
            string pathString2 = pathString1;
            string vargsiukai = @"vargšiukai.txt";
            string kietiakai = @"kietiakai.txt";
            System.IO.Directory.CreateDirectory(pathString1);
            pathString1 = System.IO.Path.Combine(pathString1, vargsiukai);
            pathString2 = System.IO.Path.Combine(pathString2, kietiakai);
            using (System.IO.StreamWriter file1 =
            new System.IO.StreamWriter(pathString1))
            using (System.IO.StreamWriter file2 =
            new System.IO.StreamWriter(pathString2))
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
            sw.Stop();
            Console.WriteLine("Time Taken-->{0} ms", sw.ElapsedMilliseconds);
        }
    }
}
