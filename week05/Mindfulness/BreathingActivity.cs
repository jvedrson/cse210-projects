using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        SetName("Breathing");
        SetDescription("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

    public override void Run()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountDown(4);

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("Now breathe out... ");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}
