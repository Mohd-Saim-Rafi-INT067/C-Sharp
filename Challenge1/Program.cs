using System;

class Challenge1
{
    static int GetRandomValue()
    {
        int value = Random.Shared.Next(10, 21);
        return value;
    }

    static void NameValidation(string? name)
    {
        if (name == "" || name.Length < 3)
        {
            Console.Write("Invalid name, Please enter a valid name: ");
            NameValidation(Console.ReadLine());
        }
        else
        {
            Console.Write($"\nWelcome {name} to the RPG Battler Game!");
            Console.Write("\nYou start with 100 HP. Try to survive as long as you can!");
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter Your name:  ");
        string? playerName = Console.ReadLine();
        NameValidation(playerName);

        int playerHP = 100;
        bool flag = true;

        while (flag  && playerHP > 0)
        {
            Console.ResetColor();
            Console.Write("\nChoose an action: \n1. Attack \n2. Heal \n3. Quit\n");
            string option = Console.ReadLine();
            int damage = GetRandomValue();
            int heal = GetRandomValue();

            switch (option)
            {
                case "1":
                playerHP = playerHP - damage;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write($"\nYou attacked the opponent, Your new HP : {playerHP} , damage taken: {damage}");
                Console.ResetColor();
                break;

                case "2":
                playerHP = playerHP + heal;
                if (playerHP > 100)
                {
                    playerHP = 100;
                }
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write($"\nYou healed, Your new HP:  {playerHP}, healed amount: {heal}");
                Console.ResetColor();
                break;

                case "3":
                Console.Write("\nYou wished to Quit the game. Thanks for playing!");
                Console.ResetColor();
                flag = false;
                break;

                default:
                Console.Write("\nInvalid option, Please try again");
                Console.ResetColor();
                break;
            }
            
        }
        if (playerHP > 0)
        {
            Console.BackgroundColor= ConsoleColor.Green;
            Console.Write("\nGame Over! You Survived!");
            Console.ResetColor();
        }
        else
        {
            Console.BackgroundColor= ConsoleColor.Red;
            Console.Write("\nGame Over! You Died!");
            Console.ResetColor();
        }
        
    }
}
