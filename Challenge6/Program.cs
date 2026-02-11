//Task: "Data Analyzer"
//1. Create a list of 100 Student objects with random grades.
//2. Use LINQ to find: Top 3 students, Average grade, and Failures (< 50).
//Challenge: Group students by Grade (A, B, C) using GroupBy and count how many are in each group.

namespace Challenge6{
    class Program{
        static void Main(string[] args){
            double[] grades = GetRandomGrades(100);
            Console.WriteLine("[" + string.Join(", ", grades) + "]");
            Console.WriteLine("--------------------------------");

            var top3 = grades.OrderByDescending(g=>g).Take(3);
            Console.WriteLine("Top 3: [" + string.Join(", ", top3) + "]");

            var avg = grades.Average();
            Console.WriteLine($"Average: {avg}");

            var failures = grades.Count(g=> g<50);
            Console.WriteLine($"Count of students who failed are: {failures}");

            var groupedGrades = grades.GroupBy(g=> GetLetterGrade(g));
            foreach (var group in groupedGrades.OrderBy(g=>g.Key)){
                Console.WriteLine($"Grade: {group.Key} - Count: {group.Count()} students");
            }

        }
        static double[] GetRandomGrades(int n){
            Random random = new Random();
            double[] grades = new double[n];

            for (int i = 0 ; i < n ; i++){
                grades[i] = Math.Round(random.NextDouble() * 100 , 2);
            }
            return grades;
        }

        static string GetLetterGrade(double grade){
            if (grade >= 90) return "A";
            else if (grade >= 80 && grade < 90) return "B";
            else if (grade >= 70 && grade < 80) return "C";
            else return "F";
        }
    }
}

