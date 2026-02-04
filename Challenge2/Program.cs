//TASK: Gradebook Manager
//1. Create Method to AddGrade, CalculateAverage and PrintReport
//2. Use a List<int> to store the grades dynamically(unlike fixed array)

class GradeBook{
    public List<int> grades = new List<int>();

    public void AddGrade(int grade){
        grades.Add(grade);
    }

    public double CalculateAverage(){
        double sum = 0;
        foreach(int i in grades){
            sum += i;
        }
        return sum / grades.Count;
    }

    public void PrintReport(){
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Write("\nGrades: ");
        Console.Write(string.Join(", ", grades));
        Console.Write($"\nAverage: {CalculateAverage()}\n");
        Console.ResetColor();
    }
}

class Program{
    static void Main(string[] args){
        GradeBook gradebook = new GradeBook();
        while (true){
            Console.Write("\nEnter the grade (or 'q' to quit): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "q"){
                break;
            }
            if (!int.TryParse(input, out int grade)){
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid number");
                Console.ResetColor();  
            }
            if (grade > 0 ){
                gradebook.AddGrade(grade);
            }
            else{
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR! grade cannot be negative");
                Console.ResetColor();
            }
        }
        gradebook.PrintReport();
    }
}
