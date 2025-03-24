class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' is already completed.");
        }
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X] " + Name : "[ ] " + Name;
    }

    public override string Serialize()
    {
        return $"SimpleGoal,{Name},{Points},{IsCompleted}";
    }
}
