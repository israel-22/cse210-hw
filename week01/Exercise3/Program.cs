using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        while (playAgain == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int attempts = 0;
            int maxAttempts = 10;

            Console.WriteLine("I have selected a number between 1 and 100. Can you guess it?");
            Console.WriteLine($"You have {maxAttempts} attempts to guess the number.");

            while (guess != magicNumber && attempts < maxAttempts)
            {
                Console.Write("What is your guess?");
                string line = Console.ReadLine();
                if (!int.TryParse(line, out guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }
                attempts++;

                if (guess < magicNumber && attempts < maxAttempts)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber && attempts < maxAttempts)
                {
                    Console.WriteLine("Lower.");
                }
                else
                {
                    Console.WriteLine($"Your guessed it in {attempts} attempts.");
                }

            }
            if(guess != magicNumber)
            {
                Console.WriteLine($"Sorry, you've used all your attempts. The number was {magicNumber}.");
            }
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain= Console.ReadLine().ToLower();
        }
     Console.WriteLine("Thank you for playing! Goodbye.");

    }
}