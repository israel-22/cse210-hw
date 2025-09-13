using System;
using System.Security.Cryptography.X509Certificates;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> entries;
        public Journal()
        {
            entries = new List<Entry>();
        }
        public void AddEntry(Entry e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e), "Entry cannot be null");
            entries.Add(e);

        }
        public IReadOnlyList<Entry> GetEntries()
        {
            return entries.AsReadOnly();
        }

        public void ShowEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("the diary is empty");
                return;
            }
            Console.WriteLine("=== Diary Entries ===");
            foreach (var e in entries)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("=====================");
        }
        public void Crear()
        {
            entries.Clear();
        }
            
            public void RepleaceEntries(IEnumerable<Entry> newEntries)
        {
            entries = new List<Entry>(newEntries ?? new List<Entry>());

        }
        
        
    }
}
