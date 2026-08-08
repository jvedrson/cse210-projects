using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<int> _remainingQuestionIndexes;
    private Random _random = new Random();

    public ReflectingActivity()
    {
        SetName("Reflecting");
        SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone you care about.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you faced a fear and overcame it.",
            "Think of a time when you persevered through a hard season of life.",
            "Think of a time when you turned a failure into a lesson."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
            "What is one thing you can take away from this experience?"
        };
    }

    public override void Run()
    {
        DisplayPrompt();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();
        DisplayQuestions();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(0, _prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        if (_remainingQuestionIndexes == null || _remainingQuestionIndexes.Count == 0)
        {
            _remainingQuestionIndexes = new List<int>();
            for (int i = 0; i < _questions.Count; i++)
            {
                _remainingQuestionIndexes.Add(i);
            }
        }

        int pick = _random.Next(0, _remainingQuestionIndexes.Count);
        int questionIndex = _remainingQuestionIndexes[pick];
        _remainingQuestionIndexes.RemoveAt(pick);

        return _questions[questionIndex];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    public void DisplayQuestions()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        string question;
        int secondsPerQuestion = 15;

        do
        {
            question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(secondsPerQuestion);
            Console.WriteLine();
        } while (DateTime.Now < endTime);
    }
}
