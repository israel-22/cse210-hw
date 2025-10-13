using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        private string _title;
        private string _description;
        private int _points;

        public string Title { get { return _title; } set { _title = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public int Points { get { return _points; } set { _points = value; } }


        protected Goal(string title, string description, int point)
        {
            _title = title;
            _description = description;
            _points = point;
        }

        public abstract int RecordEvent();
        public virtual string GetDetailsString()
        {
            return $"{Title} ({Description})";
        }
         
         public abstract string GetStringRepresentation();

    }
}