using System;

namespace EternalQuest
{
   
    public static class GoalFactory
    {
        public static Goal CreateFromString(string data)
        {
           
            if (string.IsNullOrWhiteSpace(data)) return null;

            string[] parts = data.Split('|');
            if (parts.Length == 0) return null;

            string type = parts[0];

            try
            {
                if (type == "SimpleGoal" && parts.Length >= 5)
                {
                    string title = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);
                    var g = new SimpleGoal(title, description, points);
                    if (isComplete)
                    {
                        
                        g.RecordEvent(); 
                    }
                    return g;
                }
                else if (type == "EternalGoal" && parts.Length >= 4)
                {
                    string title = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    return new EternalGoal(title, description, points);
                }
                else if (type == "ChecklistGoal" && parts.Length >= 7)
                {
                    string title = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    int current = int.Parse(parts[4]);
                    int required = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);
                    var cg = new ChecklistGoal(title, description, points, required, bonus);
                    
                    cg.SetCurrentCount(current);
                    return cg;
                }
            }
            catch
            {
               
                return null;
            }

            return null;
        }
    }
}
