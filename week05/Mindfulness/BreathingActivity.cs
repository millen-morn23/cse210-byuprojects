using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity helps you relax by guiding you through deep breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        BreathingAnimation(5);
        DisplayEndingMessage();
    }

    private void BreathingAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("\rBreathe in: " + new string('*', i + 1));
            Thread.Sleep(500);
        }
        Console.WriteLine("\nHold...");
        Thread.Sleep(2000);

        for (int i = seconds; i > 0; i--)
        {
            Console.Write("\rBreathe out: " + new string('*', i));
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }
}
