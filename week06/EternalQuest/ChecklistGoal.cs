class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, int points, int targetCount, int bonus) : base(name, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        Bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            Console.WriteLine($"Progress made on '{Name}'! {CurrentCount}/{TargetCount} completed.");

            if (CurrentCount == TargetCount)
            {
                IsCompleted = true;
                Console.WriteLine($"Goal '{Name}' completed! You earned {Points + Bonus} points.");
            }
        }
    }

    public override string GetStatus()
    {
        return IsCompleted ? $"[X] {Name} - Completed!" : $"[ ] {Name} - {CurrentCount}/{TargetCount} completed";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal,{Name},{Points},{TargetCount},{CurrentCount},{Bonus},{IsCompleted}";
    }
}
