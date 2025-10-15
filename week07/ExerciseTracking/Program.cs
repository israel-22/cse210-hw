using System;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running (new DateTime(2023, 3, 1), 30, 5),
            new Cycling (new DateTime(2023, 3, 2), 60, 20),
            new Swimming (new DateTime(2023, 3, 3), 45, 30)
        };

        Console.WriteLine("=== Resumment of Activities ===\n");
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
        Console.WriteLine("\nPress all key to exit...");
        Console.ReadKey();
    }
}