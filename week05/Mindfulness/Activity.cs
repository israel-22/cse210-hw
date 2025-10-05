using System;
using System.IO;
using System.Threading;

public class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting: {Name}");
        Console.WriteLine(Description);
        Console.Write("\nEnter the duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done! You completed the {Name} for {Duration} seconds.");
        SaveToLog(Name, Duration);
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Length;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // ✅ Activity logging improvement
    public void SaveToLog(string activityName, int duration)
    {
        string logEntry = $"{DateTime.Now}: {activityName} completed ({duration} seconds)";
        File.AppendAllText("activity_log.txt", logEntry + Environment.NewLine);
    }
}
