using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;
        public bool IsComplete { get { return _isComplete; } private set { _isComplete = value; } }

        public SimpleGoal(string title, string description, int points) : base(title, description, points)
        {
            _isComplete = false;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                IsComplete = true;
                return Points;
            }
            return 0;
        }

        public override string GetDetailsString()
        {
            string status = IsComplete ? "[X]" : "[]";
            return $"{status}{Title} ({Description})";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal|{Title}|{Description}|{Points}|{IsComplete}";
        }
    }
 }