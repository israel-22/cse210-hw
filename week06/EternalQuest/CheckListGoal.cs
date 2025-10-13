using System;

namespace EternalQuest
{

    public class ChecklistGoal : Goal
    {
        private int _requiredCount;
        private int _currentCount;
        private int _bonusPoints;

        public int RequiredCount { get { return _requiredCount; } private set { _requiredCount = value; } }
        public int CurrentCount { get { return _currentCount; } private set { _currentCount = value; } }
        public int BonusPoints { get { return _bonusPoints; } private set { _bonusPoints = value; } }

        public ChecklistGoal(string title, string description, int pointsEach, int requiredCount, int bonusPoints)
            : base(title, description, pointsEach)
        {
            _requiredCount = requiredCount;
            _currentCount = 0;
            _bonusPoints = bonusPoints;
        }

        public override int RecordEvent()
        {
            if (_currentCount < _requiredCount)
            {
                _currentCount++;
                if (_currentCount == _requiredCount)
                {
                    
                    return Points + BonusPoints;
                }
                else
                {
                   
                    return Points;
                }
            }
            
            return 0;
        }

        public override string GetDetailsString()
        {
            string status = (CurrentCount >= RequiredCount) ? "[X]" : "[ ]";
            return $"{status} {Title} ({Description}) -- Completed {CurrentCount}/{RequiredCount}";
        }

        public override string GetStringRepresentation()
        {

            return $"ChecklistGoal|{Title}|{Description}|{Points}|{CurrentCount}|{RequiredCount}|{BonusPoints}";
        }

        public void SetCurrentCount(int count)
        {
            _currentCount = count;
        }
    }
}
