
//Build a "Console RPG Battler"
// 1. Ask user for name.
// 2. Loop a battle where user chooses "Attack" or "Heal".
// 3. Use Random for damage calculations.
// 4. End loop when HP < 0.

using System;

class Challenge1
{
    static int GetRandomValue()
    {
        int value = Random.Shared.Next(10, 21);
        return value;

    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Your name");
        string playerName = Console.ReadLine();
        int playerHP = 100;
        bool flag = false;

        while (flag == false && playerHP > 0)
        {
            Console.WriteLine("Choose an action: 1. Attack 2. Heal 3. Quit");
            string option = Console.ReadLine();
            int damage = GetRandomValue();
            int heal = GetRandomValue();

            switch (option)
            {
                case "1":
                playerHP = playerHP - damage;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"You attacked, new HP : {playerHP} , damage taken: {damage}");
                Console.ResetColor();
                break;

                case "2":
                Console.BackgroundColor = ConsoleColor.Green;
                playerHP = playerHP + heal;
                Console.WriteLine($"You healed, new HP:  {playerHP}, healed amount: {heal}");
                Console.ResetColor();
                break;

                case "3":
                Console.WriteLine("You wished to Quit the game. Thanks!");
                flag = true;
                break;

                default:
                Console.WriteLine("Invalid option, Please try again");
                break;
            }
            
        }
        if (playerHP > 0)
        {
            Console.BackgroundColor= ConsoleColor.Green;
            Console.WriteLine("Game Over!");
            Console.ResetColor();
        }
        else
        {
            Console.BackgroundColor= ConsoleColor.Red;
            Console.WriteLine("Game Over!");
            Console.ResetColor();
        }
        
    }
}
