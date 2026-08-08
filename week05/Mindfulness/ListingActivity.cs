using System;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private Random _random = new Random();

    public ListingActivity()
    {
        SetName("Listing");
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are things you are grateful for?",
            "What are some recent acts of kindness you have witnessed or experienced?",
            "What are small wins you have had recently?"
        };
    }

    public override void Run()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();
        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(0, _prompts.Count);
        return _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
            {
                items.Add(entry);
            }
        }

        return items;
    }
}
