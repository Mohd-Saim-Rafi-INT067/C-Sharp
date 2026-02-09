//TASK: E-Commerce Product System
//1. Create a product class with properties: Id, Name, Price, Stock
//2.Logic: Sell() method decreases stock.Prevent negative stock(Encapsulation) 
//Challenge - Create a static field TotalProductsSold that tracks sales across all instances of Product.


namespace Challenge3{
    class Validator{
        public static bool ValidateName(string name, out string errorMessage){
            if (string.IsNullOrWhiteSpace(name)){
                errorMessage = "Name cannot be empty";
                return false;
            }
            if (name.Length < 3){
                errorMessage = "Name cannot be less than 3 characters";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidatePrice(decimal price, out string errorMessage){
            if (price <= 0){
                errorMessage = "Price must be greater than 0";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateStock(int stock, out string errorMessage){
            if (stock < 0){
                errorMessage = "Stock cannot be negative";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
    }

    class Input{
        public static int GetMenuChoice(int min, int max){
            while (true){
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine() , out int choice) && (choice >= min && choice <= max)){
                    return choice;
                }
                else{
                    Console.WriteLine("Please enter a valid choice");
                }
            }
        }

        public static string GetValidName(string prompt, string fieldName){
            while(true){
                Console.Write(prompt);
                string name = Console.ReadLine();
                if (Validator.ValidateName(name, out string errorMessage)){
                    return name;
                }
                else{
                    Console.WriteLine(errorMessage);
                }
            }
        }

        public static decimal GetValidPrice(string prompt, string fieldName){
            while(true){
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine() , out decimal value) && value > 0){
                    if (Validator.ValidatePrice(value, out string errorMessage)){
                        return value;
                    }
                    Console.WriteLine(errorMessage);
                }
                else{
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }

        public static int getValidStock(string prompt, string fieldName){
            while(true){
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine() , out int value) && value > 0){
                    if (Validator.ValidateStock(value, out string errorMessage)){
                        return value;
                    }
                    Console.WriteLine(errorMessage);
                }
                else{
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }

        public static int getValidQuantity(string prompt, string fieldName){
            while(true){
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine() , out int value) && value > 0){
                    return value;
                }
                else{
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
    }

    public class Product{

        private static int _nextId = 1;
        public int Id { get; }
        
        private string _name;
        public string Name {
            get{
                return _name;
            }
            private set{
                if (Validator.ValidateName(value, out string errorMessage)){
                    _name = value;
                }
                else{
                    Console.WriteLine(errorMessage);
                }
            }
        }
        private decimal _price;
        public decimal Price {
            get{
                return _price;
            }
            private set{
                if (Validator.ValidatePrice(value, out string errorMessage)){
                    _price = value;
                }
                else{
                    Console.WriteLine(errorMessage);
                }
            }
        }
        public int Stock { get; private set;}
        public static int TotalProductsSold { get; private set; }

        public Product(string name, decimal price, int stock){
            if (!Validator.ValidateStock(stock, out string errorMessage)){
                Console.WriteLine(errorMessage);
            }
            Id = _nextId++;
            Name = name;
            Price = price;
            Stock = stock;
        }
        public bool Sell(int quantity){
            if (quantity <= 0){
                Console.WriteLine("Invalid Quantity!");
                return false;
            }
            if (quantity > Stock){
                Console.WriteLine("Insufficient Stock!");
                return false;
            }
            Stock -= quantity;
            TotalProductsSold += quantity;
            Console.WriteLine($"Successfully Sold {quantity} of {Name}");
            return true;
        }

        public void Display(){
            Console.WriteLine($"Id: {Id} , Name: {Name} , Price: {Price} , Stock: {Stock}");
        }
    }

    public class ProductManager{
        private List<Product> products = new List<Product>();

        public void AddProduct(){
            Console.WriteLine("Add new Product");
            string name = Input.GetValidName("Enter Name: " , "Name");
            decimal price = Input.GetValidPrice("Enter Price: " , "Price");
            int stock = Input.getValidStock("Enter Stock: " , "Stock");
            products.Add(new Product(name , price , stock));
        }

        public void DisplayAllProducts(){
            if (products.Count == 0){
                Console.WriteLine("No products found");
            }
            Console.WriteLine("********** Product List ************");
            // Console.WriteLine($"{"ID"} , {"Name"} , {"Price"} , {"Stock"}");
            foreach(Product p in products){
                p.Display();
            }
            Console.WriteLine("************************************");
            Console.WriteLine($"Total Products Sold: {Product.TotalProductsSold}");
        }

        public void SellProduct(){
            if (products.Count == 0){
                Console.WriteLine("No products found");
                return;
            }
            Console.WriteLine("********** Sell Product ************");
            DisplayAllProducts();
            
            Console.WriteLine("Enter productId to sell product");
            if (int.TryParse(Console.ReadLine(), out int id)){
                Product product = products.Find(p => p.Id == id);
                if (product == null){
                    Console.WriteLine("Product not found");
                }
                int quantity = Input.getValidQuantity("Enter Quantity: " , "Quantity");
                product.Sell(quantity);
            }
            else{
                Console.WriteLine("Invalid Product Id");
            }
        }
    }

    public class Program{
        static void Main(string[] args){
            ProductManager productManager = new ProductManager();
            bool flag = true;
            while (flag){
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display All Products");
                Console.WriteLine("3. Sell Product");
                Console.WriteLine("4. Exit");
                int choice = Input.GetMenuChoice(1,4);
                switch (choice){
                    case 1:
                        productManager.AddProduct();
                        break;
                    case 2:
                        productManager.DisplayAllProducts();
                        break;
                    case 3:
                        productManager.SellProduct();
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;            
                }
            }    
        }
    }
}