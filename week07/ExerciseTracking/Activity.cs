using System;
using System.Collections.Generic;

// clase base : Activity
abstract class Activity
{
    private DateTime date;
    private int durationMinutes;
    public Activity(DateTime date, int durationMinutes)
    {
        this.date = date;
        this.durationMinutes = durationMinutes;
    }
    //Propierties inneritance
    public DateTime Date => date;
    public int DurationMinutes => durationMinutes;

    // Method abstract (implement in derived classes)
    public abstract double GetDistance(); // in kilometers
    public abstract double GetSpeed();    // in km/h
    public abstract double GetPace();     // in min/km

    // Base Method to get summary
    public virtual string GetSummary()
    {
        return $"{date:dd MMM yyyy}{this.GetType().Name} ({durationMinutes}min):" +
               $" Distance: {GetDistance():0.0} km, Velocidad: {GetSpeed():0.0} min/km";
    }

}

