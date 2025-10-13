using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nEternal Quest - Menu");
                Console.WriteLine("1. Create new goal");
                Console.WriteLine("2. List goals");
                Console.WriteLine("3. Record an event (complete goal)");
                Console.WriteLine("4. Show score");
                Console.WriteLine("5. Save goals");
                Console.WriteLine("6. Load goals");
                Console.WriteLine("7. Quit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        CreateGoalFlow(manager);
                        break;
                    case "2":
                        manager.ListGoals();
                        break;
                    case "3":
                        if (manager.Goals.Count == 0)
                        {
                            Console.WriteLine("No goals to record. Create some first.");
                        }
                        else
                        {
                            manager.ListGoals();
                            Console.Write("Select goal number to record event: ");
                            if (int.TryParse(Console.ReadLine(), out int idx))
                            {
                                manager.RecordEvent(idx - 1);
                            }
                            else
                            {
                                Console.WriteLine("Invalid number.");
                            }
                        }
                        break;
                    case "4":
                        manager.ShowScore();
                        break;
                    case "5":
                        Console.Write("Enter filename to save (e.g., goals.txt): ");
                        manager.SaveToFile(Console.ReadLine());
                        break;
                    case "6":
                        Console.Write("Enter filename to load (e.g., goals.txt): ");
                        manager.LoadFromFile(Console.ReadLine());
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }

            Console.WriteLine("Good luck on your Eternal Quest!");
        }

        static void CreateGoalFlow(GoalManager manager)
        {
            Console.WriteLine("Choose goal type:");
            Console.WriteLine("1. SimpleGoal (one-time)");
            Console.WriteLine("2. EternalGoal (repeatable)");
            Console.WriteLine("3. ChecklistGoal (complete N times)");
            Console.Write("Selection: ");

            string choice = Console.ReadLine();

            Console.Write("Enter title: ");
            string title = Console.ReadLine();

            Console.Write("Enter description: ");
            string desc = Console.ReadLine();

            Console.Write("Enter points (integer): ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid points. Defaulting to 100.");
                points = 100;
            }

            switch (choice)
            {
                case "1":
                    manager.AddGoal(new SimpleGoal(title, desc, points));
                    Console.WriteLine("Simple goal created.");
                    break;
                case "2":
                    manager.AddGoal(new EternalGoal(title, desc, points));
                    Console.WriteLine("Eternal goal created.");
                    break;
                case "3":
                    Console.Write("Enter required count (how many times to complete): ");
                    if (!int.TryParse(Console.ReadLine(), out int required))
                    {
                        required = 3;
                        Console.WriteLine("Invalid input. Defaulting to 3.");
                    }
                    Console.Write("Enter bonus points when completed: ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus))
                    {
                        bonus = 500;
                        Console.WriteLine("Invalid input. Defaulting to 500.");
                    }
                    manager.AddGoal(new ChecklistGoal(title, desc, points, required, bonus));
                    Console.WriteLine("Checklist goal created.");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
