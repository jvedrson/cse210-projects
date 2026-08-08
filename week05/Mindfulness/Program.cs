using System;

/*
The program exceeds the basic requirements. To improve it:

- This program keeps an in-memory session log that tracks how many times each
  activity has been performed during the current run. After every completed
  activity the program prints a small summary so the user can see their progress.

*/

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> sessionLog = new Dictionary<string, int>
        {
            { "Breathing", 0 },
            { "Reflecting", 0 },
            { "Listing", 0 }
        };

        bool running = true;

        do
        {
            Console.Clear();
            DisplayMenu();
            string input = Console.ReadLine();
            int option;

            if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Please enter a number between 1 and 4.");
                ShowPauseSpinner(2);
                continue;
            }

            switch (option)
            {
                case 1:
                    RunActivity(new BreathingActivity(), sessionLog);
                    break;

                case 2:
                    RunActivity(new ReflectingActivity(), sessionLog);
                    break;

                case 3:
                    RunActivity(new ListingActivity(), sessionLog);
                    break;

                case 4:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Wrong choice! Please select a number between 1 and 4.");
                    ShowPauseSpinner(2);
                    break;
            }
        } while (running);
    }

    private static void RunActivity(Activity activity, Dictionary<string, int> sessionLog)
    {
        activity.DisplayStartingMessage();
        activity.Run();

        if (sessionLog.ContainsKey(activity.GetName()))
        {
            sessionLog[activity.GetName()]++;
        }

        Console.WriteLine();
        Console.WriteLine("Session log (activities performed this run):");
        foreach (KeyValuePair<string, int> entry in sessionLog)
        {
            Console.WriteLine($"  {entry.Key}: {entry.Value}");
        }

        Console.WriteLine();
        Console.Write("Press enter to return to the menu...");
        Console.ReadLine();
    }

    private static void ShowPauseSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] frames = { "|", "/", "-", "\\" };
        int frameIndex = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(frames[frameIndex % frames.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frameIndex++;
        }
        Console.WriteLine();
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("\t1. Start breathing activity");
        Console.WriteLine("\t2. Start reflecting activity");
        Console.WriteLine("\t3. Start listing activity");
        Console.WriteLine("\t4. Quit");
        Console.Write("Select a choice from the menu: ");
    }
}
