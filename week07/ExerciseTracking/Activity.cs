using System;

abstract class Activity
{
    protected string date;
    protected int minutes;

    public Activity(string date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{date} {this.GetType().Name} ({minutes} min) - Distance: {GetDistance():0.0} km, " +
               $"Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}
// This code defines an abstract class `Activity` that serves as a base class for different types of activities.
// It contains properties for the date and duration of the activity, and abstract methods to calculate distance, speed, and pace.