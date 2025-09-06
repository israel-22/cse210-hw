using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name?");
        string firstName = Console.ReadLine();
        Console.WriteLine("what is your last name?");
        string lastName = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine($"Hello your name is{lastName}: {firstName} {lastName}!");
        
       
    }
}