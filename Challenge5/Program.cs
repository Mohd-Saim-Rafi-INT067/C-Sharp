//Payment Gateway Simulation
//1. Create Interface IPayable with method ProcessPayment(decimal amount)
//2. Implement CreditCardPayment and PayPalPayment
//3. Create a processor that accepts any IPayable

//Challenge: Create a BitCoinPayment class. Swap it into the processor without changing the processor's code

using System;

namespace Challenge5{
    public interface IPayable{
        void ProcessPayment(decimal amount);
    }

    public class CreditCardPayment : IPayable{
        public void ProcessPayment(decimal amount){
            Console.WriteLine($"Processing payment of amount : {amount} through Credit Card\n Payment Successful!");
        }
    }

    public class PayPalPayment : IPayable{
        public void ProcessPayment(decimal amount){
            Console.WriteLine($"Processing payment of amount : {amount} through PayPal\n Payment Successful!");
        }
    }

    public class BitCoinPayment : IPayable{
        public void ProcessPayment(decimal amount){
            Console.WriteLine($"Processing payment of amount : {amount} through BitCoin\n Payment Successful!");
        }
    }

    public class Processor{
        public void ProcessPayment(IPayable payment,decimal amount){
            payment.ProcessPayment(amount);
        }
    }

    public class PaymentGatewaySimulation{
        private Processor processor;

        public PaymentGatewaySimulation(){
            processor = new Processor();
        }

        public void RunApplication(){
            bool flag = true;
            while (flag){
                DisplayMenu();
                string choice = Console.ReadLine();
                switch(choice){
                    case "1":
                        decimal amount1 = GetAmount();
                        processor.ProcessPayment(new CreditCardPayment(),amount1);
                        break;
                    case "2":
                        decimal amount2 = GetAmount();
                        processor.ProcessPayment(new PayPalPayment(),amount2);
                        break;
                    case "3":
                        decimal amount3 = GetAmount();
                        processor.ProcessPayment(new BitCoinPayment(),amount3);
                        break;
                    case "4":
                        Console.WriteLine("Thankyou for using Payment Gateway!");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }

        public void DisplayMenu(){
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("1. Credit Card Payment");
            Console.WriteLine("2. PayPal Payment");
            Console.WriteLine("3. BitCoin Payment");
            Console.WriteLine("4. Exit");
            Console.Write("ENTER YOUR CHOICE: ");
        }

        private decimal GetAmount(){
            decimal amount;
            while (true){
                Console.Write("Enter the Amount: ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out amount)){
                    if (amount > 0 ){
                        return amount;
                    }
                    else{
                        Console.WriteLine("Amount should be greater than 0!");
                    }
                }
                else{
                    Console.WriteLine("Invalid Input!");
                }
            }
        }
    }

    class Program{
        static void Main(string[] args){
            PaymentGatewaySimulation Simulation = new PaymentGatewaySimulation();
            Simulation.RunApplication();
        }
    }
}



