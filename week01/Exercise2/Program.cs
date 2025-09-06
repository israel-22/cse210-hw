using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grade percentage:");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        string letter = "";

        if (grade >= 90)
        { letter = "A"; }
        else if (grade >= 80)
        { letter = "B"; }
        else if (grade >= 70)
        { letter = "C"; }
        else if (grade >= 60)
        { letter = "D"; }
        else
        { letter = "F"; }


    }

    string sing = "";
    int lastDigit = grade % 10;
    if{letter != "F"}
    
}