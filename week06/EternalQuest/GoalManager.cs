using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{

    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();
        public int Score { get { return _score; } private set { _score = value; } }

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void AddGoal(Goal g)
        {
            if (g != null) _goals.Add(g);
        }

        public void ListGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available.");
                return;
            }

            int index = 1;
            foreach (var g in _goals)
            {
                Console.WriteLine($"{index}. {g.GetDetailsString()}");
                index++;
            }
        }

        public void RecordEvent(int goalIndex)
        {
            if (goalIndex < 0 || goalIndex >= _goals.Count)
            {
                Console.WriteLine("Invalid goal selection.");
                return;
            }

            var g = _goals[goalIndex];
            int earned = g.RecordEvent();
            _score += earned;
            Console.WriteLine($"You earned {earned} points!");
            Console.WriteLine($"Total score: {_score}");
        }

        public void ShowScore()
        {
            Console.WriteLine($"Your total score: {_score}");
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
               
                writer.WriteLine(_score);

               
                foreach (var g in _goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }
            }

            Console.WriteLine($"Saved to {filename}");
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0) return;

           
            _goals.Clear();
            _score = 0;

            
            int savedScore;
            if (int.TryParse(lines[0], out savedScore))
            {
                _score = savedScore;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                var goal = GoalFactory.CreateFromString(line);
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }

            Console.WriteLine($"Loaded {_goals.Count} goals. Score restored to {_score}.");
        }
    }
}
