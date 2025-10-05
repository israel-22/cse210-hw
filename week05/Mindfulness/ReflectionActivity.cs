using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you helped someone in need.",
        "Think of a moment when you overcame a challenge.",
        "Think of an experience that made you feel grateful."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn from this experience?",
        "How can you apply what you learned today?"
    };

    public ReflectionActivity() 
        : base("Reflection Activity", "This activity helps you reflect on positive moments in your life.") { }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\n" + GetRandomPrompt());
        Console.WriteLine("Take a moment to reflect on the following questions:");
        ShowSpinner(3);

        foreach (string question in _questions)
        {
            Console.WriteLine($"\n{question}");
            ShowSpinner(4);
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
