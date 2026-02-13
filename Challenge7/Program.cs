//Task: "Data Analyzer V2 - Updated generation logic"
//1. Instead of using Loops to generate Students objects, Split generation into 4 threads.
//2. Each thread generates 25 students and merge results
using System;
using System.Threading;
using System.Linq;

namespace Challenge7{
    class Program{
        static void Main(string[] args){
            double[] grades = GetRandomGrades(100);
            Console.WriteLine("[" + string.Join(", ", grades) + "]");
            Console.WriteLine("--------------------------------");

            var top3 = grades.OrderByDescending(g=>g).Take(3);
            Console.WriteLine("Top 3: [" + string.Join(", ", top3) + "]");

            var avg = Math.Round(grades.Average(),4);
            Console.WriteLine($"Average: {avg}");

            var failures = grades.Count(g=> g<50);
            Console.WriteLine($"Count of students who failed are: {failures}");

            var groupedGrades = grades.GroupBy(g=> GetLetterGrade(g));
            foreach (var group in groupedGrades.OrderBy(g=>g.Key)){
                Console.WriteLine($"Grade: {group.Key} - Count: {group.Count()} students");
            }

        }
        static double[] GetRandomGrades(int n){
            double[] grades = new double[n];

            Thread t1 = new Thread(()=>GenerateGrade(grades,0,25));
            Thread t2 = new Thread(()=>GenerateGrade(grades,25,25));
            Thread t3 = new Thread(()=>GenerateGrade(grades,50,25));
            Thread t4 = new Thread(()=>GenerateGrade(grades,75,25));

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();

            return grades;
        }

        static void GenerateGrade(double[] grades, int start, int count){
            Random random = new Random();
            for (int i = 0 ; i < count ; i++){
                grades[start+i] = Math.Round(random.NextDouble() * 100 , 2);
            }
        }


        static string GetLetterGrade(double grade){
            if (grade >= 90) return "A";
            else if (grade >= 80 && grade < 90) return "B";
            else if (grade >= 70 && grade < 80) return "C";
            else return "F";
        }
    }
}
