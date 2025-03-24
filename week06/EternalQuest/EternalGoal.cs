class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Goal '{Name}' recorded! You earned {Points} points.");
    }

    public override string GetStatus()
    {
        return "[∞] " + Name;
    }

    public override string Serialize()
    {
        return $"EternalGoal,{Name},{Points}";
    }
}
