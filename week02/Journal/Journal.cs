using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

class Journal
{
    private List<string> entries = new List<string>();
    private static List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry(string entry)
{
    Random rand = new Random();
    string prompt = _prompts[rand.Next(_prompts.Count)];
    Console.WriteLine($"Prompt: {prompt}");
    Console.Write("Your Response: ");
    string response = Console.ReadLine();

    string fullEntry = $"{DateTime.Now}: {prompt}\n{response}\n";
    entries.Add(fullEntry);
    Console.WriteLine("\nEntry saved successfully!\n");
}


    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries available.");
        }
        else
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    public void SaveToCsv(string filename)
    {
        try
        {
            File.WriteAllLines(filename, entries);
            Console.WriteLine("Journal saved to CSV successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromCsv(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                entries.AddRange(File.ReadAllLines(filename));
                Console.WriteLine("Journal loaded from CSV successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }


    public void SaveToJson(string filename)
    {
        try
        {
            string json = JsonSerializer.Serialize(entries);
            File.WriteAllText(filename, json);
            Console.WriteLine("Journal saved to JSON successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromJson(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                var loadedEntries = JsonSerializer.Deserialize<List<string>>(json);
                if (loadedEntries != null)
                {
                    entries.AddRange(loadedEntries);
                }
                Console.WriteLine("Journal loaded from JSON successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

}
