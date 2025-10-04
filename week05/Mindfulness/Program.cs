// Program.cs
// Mindfulness program demonstrating inheritance, encapsulation and basic animations.
// Author: (add your name here)
// Notes: To exceed requirements, see comments at the end for ideas.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    // Base class for all activities
    abstract class Activity
    {
        // Encapsulated member variables
        private string _name;
        private string _description;
        private int _durationSeconds;

        // Public properties (controlled access)
        public string Name
        {
            get => _name;
            protected set => _name = value ?? "Unnamed Activity";
        }

        public string Description
        {
            get => _description;
            protected set => _description = value ?? "";
        }

        // Duration in seconds
        public int DurationSeconds
        {
            get => _durationSeconds;
            protected set
            {
                if (value < 0) _durationSeconds = 0;
                else _durationSeconds = value;
            }
        }

        // Constructor
        protected Activity(string name, string description)
        {
            Name = name;
            Description = description;
            DurationSeconds = 0;
        }

        // Public method that runs the full lifecycle of an activity
        public void Start()
        {
            GetDurationFromUser();
            DisplayStartingMessage();
            PrepareToStart();
            Execute(); // Polymorphic behavior - implemented in derived classes
            DisplayEndingMessage();
        }

        // Ask the user for how long they want the activity
        private void GetDurationFromUser()
        {
            Console.Write("Enter duration in seconds for this activity: ");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int secs) && secs >= 0)
                {
                    DurationSeconds = secs;
                    break;
                }
                Console.Write("Invalid input. Please enter a non-negative integer: ");
            }
        }

        // Common starting message
        protected void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {Name} ---");
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.WriteLine($"This activity will last for {DurationSeconds} seconds.");
            Console.WriteLine();
        }

        // Common prepare before starting with a short pause and spinner
        protected void PrepareToStart()
        {
            Console.WriteLine("Get ready...");
            ShowSpinner(3); // show spinner for 3 seconds
            Console.WriteLine();
        }

        // Common ending message
        protected void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(2);
            Console.WriteLine($"You have completed the {Name} for {DurationSeconds} seconds.");
            ShowSpinner(2);
            Console.WriteLine();
            Console.WriteLine("Press Enter to return to main menu...");
            Console.ReadLine();
        }

        // A simple spinner animation for given number of seconds
        protected void ShowSpinner(int seconds)
        {
            char[] sequence = new char[] { '|', '/', '-', '\\' };
            DateTime end = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < end)
            {
                Console.Write(sequence[i % sequence.Length]);
                Thread.Sleep(250);
                Console.Write("\b \b"); // erase char
                i++;
            }
        }

        // A countdown helper (seconds)
        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Derived classes must implement the specific activity behavior
        protected abstract void Execute();
    }

    // Breathing activity
    class BreathingActivity : Activity
    {
        public BreathingActivity() : base(
            "Breathing Activity",
            "This activity will help you relax by walking your breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        protected override void Execute()
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(DurationSeconds);

            while (DateTime.Now < endTime)
            {
                Console.Write("Inhale... ");
                ShowCountdown(4); // inhale for 4 seconds
                Console.WriteLine();
                Thread.Sleep(200); // small pause after countdown

                Console.Write("Exhale... ");
                ShowCountdown(6); // exhale for 6 seconds
                Console.WriteLine();
                Thread.Sleep(200); // small pause
            }
        }
    }

    // Reflection activity
    class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you start?",
            "How did you feel when it was complete?",
            "What made this time different from other times when you didn't succeed as much?",
            "What did you like most about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Random _random = new Random();

        public ReflectionActivity() : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects.")
        { }

        protected override void Execute()
        {
            // Show a random prompt
            string prompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine();
            Console.WriteLine("*** Prompt ***");
            Console.WriteLine(prompt);
            Console.WriteLine();

            // Small pause and spinner before questions
            Console.WriteLine("When you have something in mind, press Enter to continue...");
            Console.ReadLine();
            Console.WriteLine("Now reflect on the following questions:");
            ShowSpinner(2);

            // Show random questions until time is up
            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(DurationSeconds);

            while (DateTime.Now < end)
            {
                string q = _questions[_random.Next(_questions.Count)];
                Console.WriteLine();
                Console.WriteLine($"-- {q}");
                // Pause for reflection with spinner/countdown
                ShowSpinner(5); // show spinner for 5 seconds between questions
                Console.WriteLine();
            }
        }
    }

    // Listing activity
    class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are your personal strengths?",
            "Who are people you have helped this week?",
            "When have you felt the Spirit this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        { }

        protected override void Execute()
        {
            string prompt = _prompts[new Random().Next(_prompts.Count)];
            Console.WriteLine();
            Console.WriteLine("*** Prompt ***");
            Console.WriteLine(prompt);
            Console.WriteLine();

            Console.WriteLine("You will have a short countdown to start, then list as many items as you can.");
            Console.Write("Starting in: ");
            ShowCountdown(5);
            Console.WriteLine();
            Console.WriteLine($"Start listing items now! (Press Enter after each item). You have {DurationSeconds} seconds.");

            List<string> items = new List<string>();
            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(DurationSeconds);

            // Use Console.KeyAvailable to avoid blocking ReadLine
            while (DateTime.Now < end)
            {
                if (Console.KeyAvailable)
                {
                    string item = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        items.Add(item.Trim());
                        Console.WriteLine($"Recorded: {item.Trim()} (Total: {items.Count})");
                    }
                }
                else
                {
                    Thread.Sleep(100); // reduce CPU spin
                }
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} items:");
            foreach (var it in items)
            {
                Console.WriteLine($" - {it}");
            }
        }
    }

    // Main program with menu
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program - Main Menu");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option (1-4): ");

                string option = Console.ReadLine();
                Activity activity = null;

                switch (option)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }

                if (activity != null)
                {
                    activity.Start();
                }
            }

            Console.WriteLine("Thank you for using the Mindfulness Program!");
        }
    }
}
