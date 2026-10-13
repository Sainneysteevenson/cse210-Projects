using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 3, 15), 30, 3.0),
            new Cycling(new DateTime(2024, 3, 15), 45, 18.0),
            new Swimming(new DateTime(2024, 3, 15), 60, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}