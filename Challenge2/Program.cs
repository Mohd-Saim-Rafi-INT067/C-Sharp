//TASK: Gradebook Manager
//1. Create Method to AddGrade, CalculateAverage and PrintReport
//2. Use a List<int> to store the grades dynamically(unlike fixed array)

class GradeBook{
    private List<int> grades = new List<int>();
    public void AddGrades(params int[] NewGrades){
        foreach(int grade in NewGrades){
            grades.Add(grade);
        }
    }
    public double CalculateAverage(){
        if (grades.Count == 0) return 0; 
        double sum = 0;
        foreach(int grade in grades){
            sum += grade;
        }
        return sum / grades.Count;
    }

    public void PrintReport(){
        Console.Write($"\nGrades: {string.Join(", ", grades)}\nAverage: {CalculateAverage()}\n");
    }
}

class Program{
    static void Main(string[] args){
        GradeBook gradebook = new GradeBook();
        while (true){
            Console.Write("\nEnter the grade(s) (or 'q' to quit): ");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "q"){
                break;
            }
           
            string [] grades = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            foreach(string _grade in grades){
                if (!int.TryParse(_grade, out int grade)){
                    Console.WriteLine("Invalid Input! Not a number");
                    continue;
                }

                if (grade < 0){
                    Console.WriteLine("Enter a number greater than 0");
                    continue;
                }
                gradebook.AddGrades(grade);
            }
        }
        gradebook.PrintReport();
    }
}
