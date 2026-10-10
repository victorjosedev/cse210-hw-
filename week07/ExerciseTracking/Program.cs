using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("       EXERCISE TRACKING PROGRAM (WEEK 07)       ");
        Console.WriteLine("=================================================");
        Console.WriteLine();

        List<Activity> activities = new List<Activity>();

        // Create at least one activity of each type
        activities.Add(new Running("03 Nov 2022", 30, 4.8));
        activities.Add(new StationaryBicycle("04 Nov 2022", 45, 20.0));
        activities.Add(new Swimming("05 Nov 2022", 40, 30));

        // Iterate through the list polymorphically calling GetSummary()
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine();
        Console.WriteLine("=================================================");
    }
}