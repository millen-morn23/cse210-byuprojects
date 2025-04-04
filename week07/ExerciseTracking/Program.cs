using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Apr 2025", 30, 5.0),
            new Cycling("05 Apr 2025", 40, 20.0),
            new Swimming("07 Apr 2025", 25, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
