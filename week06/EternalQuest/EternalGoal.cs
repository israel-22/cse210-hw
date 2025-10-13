using System;

namespace EternalQuest
{
    
    public class EternalGoal : Goal
    {
        public EternalGoal(string title, string description, int points) : base(title, description, points)
        {
        }

        public override int RecordEvent()
        {
         
            return Points;
        }

      
        public override string GetStringRepresentation()
        {

            return $"EternalGoal|{Title}|{Description}|{Points}";
        }
    }
}
