using System;
using System.Collections.Generic;

namespace JournalApp
{
    public class PromptGenerator
    {
        private List<string> prompts;
        private Random rnd;

        public PromptGenerator()
        {
            rnd = new Random();
            prompts = new List<string>()
            {
                "What was the best part of your day?",
                "What are you grateful for today?",
                "Describe a challenge you faced today and how you overcame it.",
                "What is something new you learned today?",
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "What did I learn today that I'd like to remember?",
                "What made me smile today?",
                "If I could replay one moment from today, what would it be and why?",
                "What challenge did I face today and how did I resolve it (or will I try to resolve it)?",
                "What am I grateful for today?"
            };

        }

        public string GetRandomPrompt()
        {
            int index = rnd.Next(prompts.Count);
            return prompts[index];
        }
        public void AddPrompt(string promp)
        {
            if (!string.IsNullOrEmpty(promp))
            prompts.Add(promp);
         }
    }
}