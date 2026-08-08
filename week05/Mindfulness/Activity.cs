using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity()
    {

    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        int duration;
        while (!int.TryParse(input, out duration) || duration <= 0)
        {
            Console.Write("Please enter a positive whole number of seconds: ");
            input = Console.ReadLine();
        }
        SetDuration(duration);

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] frames = { "|", "/", "-", "\\" };
        int frameIndex = 0;

        while (DateTime.Now < endTime)
        {
            string frame = frames[frameIndex % frames.Length];
            Console.Write(frame);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frameIndex++;
        }

        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }

    // For my log system using with RunActivity() method
    public virtual void Run() {}
}
