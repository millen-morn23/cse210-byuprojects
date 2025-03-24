using System;
using System.Collections.Generic;
using System.IO;

class ActivityLog
{
    private Dictionary<string, int> _activityCount = new Dictionary<string, int>();

    public void RecordActivity(string activityName)
    {
        if (_activityCount.ContainsKey(activityName))
            _activityCount[activityName]++;
        else
            _activityCount[activityName] = 1;
    }

    public void SaveLogToFile()
    {
        using (StreamWriter writer = new StreamWriter("activity_log.txt"))
        {
            foreach (var entry in _activityCount)
                writer.WriteLine($"{entry.Key}:{entry.Value}");
        }
    }

    public void LoadLogFromFile()
    {
        if (File.Exists("activity_log.txt"))
        {
            string[] lines = File.ReadAllLines("activity_log.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                    _activityCount[parts[0]] = int.Parse(parts[1]);
            }
        }
    }

    public void DisplayLog()
    {
        Console.WriteLine("\n--- Activity Log ---");
        foreach (var entry in _activityCount)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} times");
        }
    }
}
