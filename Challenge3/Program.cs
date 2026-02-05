//TASK: E-Commerce Product System
//1. Create a product class with properties: Id, Name, Price, Stock
//2.Logic: Sell() method decreases stock.Prevent negative stock(Encapsulation) 
//Challenge - Create a static field TotalProductsSold that tracks sales across all instances of Product.


namespace Challenge3{
    public class Product{

        private static int _nextId = 1;
        public int Id { get; }
        public string Name { get; }
        public double Price { get; set;}
        public int Stock { get; private set;}
        public static int TotalProductsSold { get; private set; }

        public Product(string name, double price, int stock){
            if (stock < 0){
                throw new ArgumentException("Stock cannot be negative");
            }
            Id = _nextId++;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void Sell(int quantity){
            if (quantity <= 0){
                Console.WriteLine("Invalid Quantity");
                return;
            }
            if (quantity > Stock){
                Console.WriteLine("Insufficient Stock");
                return;
            }
            Stock -= quantity;
            TotalProductsSold += quantity;
        }

        public void Display(){
            Console.WriteLine($"Id: {Id} , Name: {Name} , Price: {Price} , Stock: {Stock}");
        }
        
    }

    public class Program{
        static void Main(string[] args){
            Product p1 = new Product("Laptop" , 50000, 10);
            Product p2 = new Product("Mobile" , 10000, 5);
            p1.Display();
            p2.Display();
            p1.Sell(100);
            p1.Display();

        }
    }
}