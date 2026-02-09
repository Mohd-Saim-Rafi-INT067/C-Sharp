//TASK: Employee payroll system
//1. Base class Employee(Name,ID) with abstract CalculatePay()
//2. Derived classes : FullTime(fixed salary) and Contractor(hourly rate)
//4. Store all in a list<Employee> and calculate total payroll.

//Challenge: Add a manager class that inherits FullTime but adds a Bonus Property to the pay calculation


namespace Challenge4{
    static class Validator{
        public static bool ValidateName(string name , out string errorMessage){
            if (string.IsNullOrWhiteSpace(name)){
                errorMessage = "Name cannot be empty";
                return false;
            }
            if (name.Length < 3){
                errorMessage = "Name must be at least 3 characters";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
        
        public static bool ValidatePositiveNumber(double value, string fieldName, out string errorMessage){
            if (value <= 0){
                errorMessage = $"{fieldName} must be greater than 0";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
    }

    static class Input{
        static public int GetMenuChoice(int min,int max){
            while (true){
                Console.Write("Enter your choice:");
                if (int.TryParse(Console.ReadLine(),out int choice) && choice >= min && choice <= max){
                    return choice;
                }
                else{
                    Console.WriteLine("Please enter a valid Choice");
                }
            }
        }

        public static string GetValidName(string prompt){
            while(true){
                Console.Write(prompt);
                string name = Console.ReadLine();
                if (Validator.ValidateName(name,out string errorMessage)){
                    return name;
                }
                else{
                    Console.WriteLine(errorMessage);
                }
            }
        }

        public static double GetValidDouble(string prompt, string fieldName){
            while(true){
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(),out double value)){
                    if (Validator.ValidatePositiveNumber(value,fieldName,out string errorMessage)){
                        return value;
                    }
                    Console.WriteLine(errorMessage);
                }
                else{
                    Console.WriteLine("please enter a valid number");
                }
            }
        }

        public static int GetValidInt(string prompt, string fieldName){
            while(true){
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(),out int value) && value > 0){
                    return value;
                }
                Console.WriteLine($"{fieldName} must be greater than 0");
            }
        }
    } 
    abstract class Employee{
        private static int _nextID = 100;
        public int ID { get; private set;}

        private string _name;
        public string name{
            get{
                return _name;
            }
            set{
                if (Validator.ValidateName(value,out String errorMessage)){
                    _name = value;
                }
                else{
                    throw new ArgumentException(errorMessage);
                }
            }
        }

        public Employee(string name){
            this.name = name;
            ID = _nextID++;
        }

        public abstract double CalculatePay();

        public virtual void Display(){
            Console.WriteLine($"ID: {ID} Name: {name} Pay: Rs. {CalculatePay()}");
        }
    }

    class FullTime : Employee{
        public double Salary { get; set;}

        public FullTime(string name, double salary) : base(name){
            Salary = salary;
        }

        public override double CalculatePay(){
            return Salary;
        }
    }

    class Contractor : Employee{
        public double HourlyRate { get; set;}
        public int HoursWorked { get; set;}

        public Contractor(string name , double hourlyRate, int hoursWorked) : base(name){
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override double CalculatePay(){
            return HourlyRate * HoursWorked;
        }
    }

    class Manager : FullTime{
        public double Bonus { get; set;}

        public Manager(string name, double salary, double bonus) : base(name,salary){
            Bonus = bonus;
        }

        public override double CalculatePay(){
            return base.CalculatePay() + Bonus;
        }

        public override void Display(){
            Console.WriteLine($"ID: {ID} Name: {name} Base: Rs. {Salary} Bonus: Rs. {Bonus} TotalPay: Rs. {CalculatePay()}");
        }
    }

    
    class PayrollManager{
        private List<Employee> employees = new List<Employee>();

        public void AddFullTimeEmployee(){
            Console.WriteLine("Adding full time employee ");
            string name = Input.GetValidName("Enter Name: ");
            double salary = Input.GetValidDouble("Enter the salary: ", "Salary");
            employees.Add(new FullTime(name,salary));
        }

        public void AddContractorEmployee(){
            Console.WriteLine("Adding contractor employee");
            string name = Input.GetValidName("Enter Name: ");
            double hourlyRate = Input.GetValidDouble("Enter the hourlyRate: ", "HourlyRate");
            int hoursWorked = Input.GetValidInt("Enter the hoursWorked: ","HoursWorked");
            employees.Add(new Contractor(name,hourlyRate,hoursWorked));
        }
        public void AddManagerEmployee(){
            Console.WriteLine("Adding manager employee ");
            string name = Input.GetValidName("Enter Name: ");
            double salary = Input.GetValidDouble("Enter the salary: ", "Salary");
            double bonus = Input.GetValidDouble("Enter the bonus: ", "bonus");
            employees.Add(new Manager(name,salary,bonus));
        }

        public void DisplayAllEmployees(){
            if (employees.Count == 0){
                Console.WriteLine("No employees found");
                return;
            }

            Console.WriteLine("********** Employee Payroll System ************");
            double TotalPayroll = 0;
            foreach(Employee e in employees){
                TotalPayroll += e.CalculatePay();
                e.Display();
            }
            Console.WriteLine($"*********************************************** \nTotal Payroll: {TotalPayroll}");
        }
    }


    class Program{
        static void Main(string[] args){        
            PayrollManager payroll = new PayrollManager();
            bool flag = true;

            static void DisplayMenu(){
                Console.WriteLine("1. Add Full Time Employee");
                Console.WriteLine("2. Add Contractor Employee");
                Console.WriteLine("3. Add Manager Employee");
                Console.WriteLine("4. Display All Employees");
                Console.WriteLine("5. Exit");
            }

            while (flag){
                DisplayMenu();
                int choice = Input.GetMenuChoice(1,6);
                switch (choice){
                    case 1:
                        payroll.AddFullTimeEmployee();
                        break;
                    case 2:
                        payroll.AddContractorEmployee();
                        break;
                    case 3:
                        payroll.AddManagerEmployee();
                        break;
                    case 4:
                        payroll.DisplayAllEmployees();
                        break;
                    case 5:
                        flag = false;
                        Console.WriteLine("Thanks for using Employee Payroll System");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}