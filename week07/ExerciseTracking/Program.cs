using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running_1 = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        activities.Add(running_1);
        Cycling cycling_1 = new Cycling(new DateTime(2022, 11, 3), 45, 15.0);
        activities.Add(cycling_1);
        Swimming swimming_1 = new Swimming(new DateTime(2022, 11, 3), 25, 10);
        activities.Add(swimming_1);

        Swimming swimming_2 = new Swimming(new DateTime(2026, 8, 11), 25, 13);
        activities.Add(swimming_2);
        Cycling cycling_2 = new Cycling(new DateTime(2026, 8, 11), 60, 18.5);
        activities.Add(cycling_2);
        Running running_2 = new Running(new DateTime(2026, 8, 11), 30, 5.0);
        activities.Add(running_2);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}




