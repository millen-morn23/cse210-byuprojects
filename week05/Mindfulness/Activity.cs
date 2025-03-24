using System;
using System.Collections.Generic;
using System.Threading;

class Activity
{
    protected string _name;
    protected string _description;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public virtual void Run() {}

    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"\nStarting {_name}...");
        Console.WriteLine(_description);
        Thread.Sleep(2000);
    }

    private List<string> _encouragementMessages = new List<string>
    {
        "Great job! Keep practicing mindfulness.",
        "You're doing amazing! Keep it up.",
        "That was a great session! Try again later for more benefits.",
        "Every step counts. Well done!"
    };

    protected void DisplayEndingMessage()
    {
        Random random = new Random();
        Console.WriteLine($"\n{_encouragementMessages[random.Next(_encouragementMessages.Count)]}");
        Thread.Sleep(3000);
    }
}
