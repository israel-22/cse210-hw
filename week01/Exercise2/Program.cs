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
        
    string sing = "";
    int lastDigit = grade % 10;

    if (letter != "F")
    {
      if(lastDigit >=7)

      { sing ="+";}
      else if (lastDigit < 3)
       {sing = "-";}

    }
    
if (letter == "A" && sing == "+")
{
    sing = "";
}

Console.WriteLine($"Your letter grade is: {letter}{sing}");
if (grade >= 70)
{
    Console.WriteLine("Congratulations, you passed the course!");
}
else
{
    Console.WriteLine("Better luck next time! keep trying!");
}
    }
    
}
   

 
 
    
