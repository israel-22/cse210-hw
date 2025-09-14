using System;
using System.IO;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            var prompts = new PromptGenerator();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n --- Menu of Journal App ---");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file (CSV)");
                Console.WriteLine("4. Load the journal from a file (CSV)");
                Console.WriteLine("5. Save the journal to a file (JSON)");
                Console.WriteLine("6. Load the journal from a file (JSON)");
                Console.WriteLine("7. Clear actual entries");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            WriteNewEntry(journal, prompts);
                            break;
                        case "2":
                            journal.ShowEntries();
                            break;
                        case "3":
                            SaveCsv(journal);
                            break;
                        case "4":
                            LoadCsv(journal);
                            break;
                        case "5":
                            SaveJson(journal);
                            break;
                        case "6":
                            LoadJson(journal);
                            break;
                        case "7":
                            Console.Write("Are you sure you want to clear all entries? (y/n): ");
                            var confirm = Console.ReadLine();
                            if (confirm?.ToLower() == "y")
                            {
                                journal.ClearEntries();
                                Console.WriteLine("All entries have been cleared.");
                            }
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
            Console.WriteLine("Exiting the Journal App. Goodbye!");
        }

        static void WriteNewEntry(Journal journal, PromptGenerator prompts)
        {
            var prompt = prompts.GetRandomPrompt();
            Console.WriteLine($"\nPrompt: {prompt}");
            Console.Write("Your response: ");
            var response = Console.ReadLine();

            var dateText = DateTime.Now.ToShortDateString();
            var entry = new Entry(dateText, prompt, response ?? "");
            journal.AddEntry(entry);
            Console.WriteLine("Entry saved in memory.");
        }

        static void SaveCsv(Journal journal)
        {
            Console.Write("Name of file to save (.txt or .csv): ");
            var filename = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filename)) { Console.WriteLine("Invalid name."); return; }

            FileManager.SaveToCsv(filename, journal.GetEntries());
            Console.WriteLine($"Journal saved to (CSV) {filename}");
        }

        static void LoadCsv(Journal journal)
        {
            Console.Write("Name of file to load (CSV): ");
            var filename = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filename)) { Console.WriteLine("Invalid name."); return; }

            var entries = FileManager.LoadFromCsv(filename);
            journal.ReplaceEntries(entries); // corregido para coincidir con Journal.cs
            Console.WriteLine($"Journal loaded from (CSV) {filename}");
        }

        static void SaveJson(Journal journal)
        {
            Console.Write("Name of file to save (JSON, for example: mydiary.json): ");
            var filename = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filename)) { Console.WriteLine("Invalid name."); return; }

            FileManager.SaveToJson(filename, journal.GetEntries());
            Console.WriteLine($"Journal saved to (JSON) {filename}");
        }

        static void LoadJson(Journal journal)
        {
            Console.Write("Name of file to load (JSON): ");
            var filename = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filename)) { Console.WriteLine("Invalid name."); return; }

            var entries = FileManager.LoadFromJson(filename);
            journal.ReplaceEntries(entries); // corregido
            Console.WriteLine($"Journal loaded from (JSON) {filename}");
        }
    }
}
