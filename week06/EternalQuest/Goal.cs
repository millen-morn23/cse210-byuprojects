abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public void SetCompletion(bool status)
    {
        IsCompleted = status;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();
}
