using System;

class Program
{
    static void Main()
    {
        ActivityLog activityLog = new ActivityLog();
        activityLog.LoadLogFromFile(); // Load previous activity logs if available

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Dr Millen's Mindfulness Program!");
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Gratitude Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new GratitudeActivity();
                    break;
                case "4":
                    activityLog.DisplayLog();
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    continue;
                case "5":
                    activityLog.SaveLogToFile(); // Save activity logs before exiting
                    Console.WriteLine("Goodbye! Your activity log has been saved.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    continue;
            }

            if (activity != null)
            {
                activity.Run();
                activityLog.RecordActivity(activity.GetType().Name); // Track completed activity
            }
        }
    }
}
