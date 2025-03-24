using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;
    private string filePath = "goals.txt";

    public void CreateGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        Console.WriteLine("Select goal type: ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(name, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record progress:");
        DisplayGoals();
        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordEvent();
            score += goals[index].Points;
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(score);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                string type = parts[0];
                string name = parts[1];
                int points = int.Parse(parts[2]);

                if (type == "SimpleGoal")
                {
                    bool isCompleted = bool.Parse(parts[3]);
                    SimpleGoal goal = new SimpleGoal(name, points);
                    goal.SetCompletion(isCompleted); // FIX: Use method to update IsCompleted
                    goals.Add(goal);
                }
                else if (type == "EternalGoal")
                {
                    goals.Add(new EternalGoal(name, points));
                }
                else if (type == "ChecklistGoal")
                {
                    int target = int.Parse(parts[3]);
                    int current = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    bool isCompleted = bool.Parse(parts[6]);

                    ChecklistGoal goal = new ChecklistGoal(name, points, target, bonus)
                    {
                        CurrentCount = current
                    };
                    goal.SetCompletion(isCompleted); // FIX: Use method to update IsCompleted
                    goals.Add(goal);
                }
            }
        }
    }
}
