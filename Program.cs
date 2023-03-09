using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
        Scripture scripture = new Scripture();
        string userChoice = "";
        Console.Clear();

        
        while (userChoice != "QUIT")
        {
            // If we number the choices, they might want to type in numbers
            // Also, if we follow the customer documentation, what issues might we run into for localization? (Enter/Return/⏎)

            // Console.Clear();
            // Console.WriteLine("""
            // 1. Display scripture
            // 2. QUIT
            // """);
            scripture.DisplayScripture();
            Console.WriteLine("Press ENTER to remove random words or type QUIT to close program: ");
            userChoice = Console.ReadLine();
            if (userChoice == "")
            {
                scripture.HideWords();
                Console.Clear();
            }

        }


        
    }
}