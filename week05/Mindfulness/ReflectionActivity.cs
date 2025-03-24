using System;
using System.Collections.Generic;
using System.Threading;

class ReflectionActivity : Activity
{
    private List<string> _reflectionPrompts = new List<string>
    {
        "Think of a time when you overcame a challenge.",
        "Reflect on a moment of personal growth.",
        "Remember a time when someone helped you.",
        "Think about an accomplishment you are proud of."
    };

    private List<string> _unusedPrompts = new List<string>();

    public ReflectionActivity() : base("Reflection Activity", 
        "This activity helps you think deeply about positive experiences.")
    {
    }

    private int GetDuration()
    {
        return 60; // Default duration of 60 seconds
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}... ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    private void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write($"\r{spinner[i % 4]}");
            Thread.Sleep(500);
        }
        Console.Write("\r "); // Clear the spinner animation
    }

    public override void Run()
    {
        DisplayStartingMessage();

        // Ensure all prompts are used before repeating
        if (_unusedPrompts.Count == 0)
            _unusedPrompts.AddRange(_reflectionPrompts);

        // Select a unique prompt
        Random random = new Random();
        int index = random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);

        Console.WriteLine($"\nReflection Prompt: {prompt}");

        ShowCountdown(5);
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        int numPrompts = 4; // Only show 4 prompts before ending

        for (int i = 0; i < numPrompts && DateTime.Now < endTime; i++)
        {
            Console.Write("\nThink about: ");
            Console.WriteLine(_unusedPrompts[random.Next(_unusedPrompts.Count)]);
            ShowSpinner(5); // Give time to reflect before the next prompt
        }

        DisplayEndingMessage();
    }
}
