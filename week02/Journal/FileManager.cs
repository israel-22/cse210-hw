using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;


namespace JournalApp
{
    public class FileManager
    {
        private const char SEP = '|';
        public static void SaveToCsv(string filename, IEnumerable<Entry> entries)
        {
            using (var write = new StreamWriter(filename, false, Encoding.UTF8))
            {
                foreach (var e in entries)
                {
                    var safePrompt = e.Prompt?.Replace("\r", "").Replace("\n", " ");
                    var safeResponse = e.Prompt?.Replace("\r", "").Replace("\n", " ");
                    write.WriteLine($"{e.Date}{SEP}{safePrompt}{SEP}{safeResponse}");
                }
            }

        }
        public static IEnumerable<Entry> LoadFromCsv(string filename)
        {
            var list = new List<Entry>();
            if (!File.Exists(filename)) throw new FileNotFoundException("File not found", filename);

            var lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(SEP);
                string date = parts.Length > 0 ? parts[0] : "";
                string prompt = parts.Length > 1 ? parts[1] : "";
                string response = parts.Length > 2 ? parts[2] : "";
                list.Add(new Entry(date, prompt, response));
            }
            return list;
        }
        public static void SaveToJson(string filename, IEnumerable<Entry> entries)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var Json = JsonSerializer.Serialize(entries, options);
        File.WriteAllText( filename, Json, Encoding.UTF8);

        }
        public static IEnumerable<Entry> LoadFromJson(string filename)
        {
            if (!File.Exists(filename)) throw new FileNotFoundException("File not found", filename);
            var json = File.ReadAllText(filename);
            var entries = JsonSerializer.Deserialize<List<Entry>>(json);
            return entries ?? new List<Entry>();
        } 

    }
}