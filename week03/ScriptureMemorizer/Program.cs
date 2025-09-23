using System;

class Program
{
    static void Main(string[] args)
    {

        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, 
            "For God so loved the world that he gave his one and only Son, " +
            "that whoever believes in him shall not perish but have eternal life.");

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        while (true)
        {
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit" || scripture.AllWordsHidden())
                break;

            scripture.HideRandomWords();
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }

        Console.WriteLine("\nProgram ended. Goodbye!");
    }
}
