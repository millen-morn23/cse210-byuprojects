using System;
using System.Collections.Generic;
using System.Threading;

class GratitudeActivity : Activity
{
    private List<string> _gratitudePrompts = new List<string>
    {
        "What are three things you are grateful for today?",
        "Who are the people in your life you are thankful for?",
        "What experiences have brought you joy recently?",
        "What small things in your daily life bring you happiness?",
        "What skills or talents are you grateful to have?"
    };

    private List<string> _motivationQuotes = new List<string>
    {
        "Gratitude turns what we have into enough.",
        "The more you practice gratitude, the more you have to be grateful for.",
        "Gratitude is not only the greatest of virtues but the parent of all others.",
        "Be thankful for what you have; you'll end up having more."
    };

    public GratitudeActivity() : base("Gratitude Activity", 
        "This activity helps you focus on the good things in your life by listing things you are grateful for.")
    {
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}... ");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\nStart!");
    }

    private int GetDuration()
    {
        return 60; // Default duration of 60 seconds
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        string prompt = _gratitudePrompts[random.Next(_gratitudePrompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("Take a moment to think, then start listing when ready...");
        Console.WriteLine("Type as many gratitude items as you can. Press Enter on a blank line to finish early.");

        ShowCountdown(5);

        List<string> gratitudeList = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter a gratitude item: ");
            string response = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(response))
                break; // Stop asking when the user presses Enter without typing

            gratitudeList.Add(response);
        }

        Console.WriteLine($"\nYou listed {gratitudeList.Count} things you are grateful for.");
        Console.WriteLine($"Here's a motivational quote: \"{_motivationQuotes[random.Next(_motivationQuotes.Count)]}\"");

        DisplayEndingMessage();
    }
}
