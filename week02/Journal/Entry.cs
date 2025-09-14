using System;

namespace JournalApp
{
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public Entry() { }

        public Entry(string date, string promp, string response)
        {
            Date = date;
            Prompt = promp;
            Response = response;
        }
        public override string ToString()
        {
            return $"Date:{Date}\nQuestion: {Prompt}\nResponse:{Response}\n";
        }
    
}
}

