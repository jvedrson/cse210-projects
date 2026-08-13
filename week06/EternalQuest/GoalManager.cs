using System;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";
        while (choice != "8")
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Edit Goal");
            Console.WriteLine("  5. Delete Goal");
            Console.WriteLine("  6. Load Goals");
            Console.WriteLine("  7. Record Event");
            Console.WriteLine("  8. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    EditGoal();
                    break;
                case "5":
                    DeleteGoal();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    RecordEvent();
                    break;
                case "8":
                    Console.WriteLine("Goodbye, keep up the great work on your Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        switch (typeChoice)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record. Create a goal first.");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int id = int.Parse(Console.ReadLine());

        Goal goal = FindGoalById(id);
        if (goal == null)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        // Track whether the goal was already complete before recording so we can detect a bonus.
        bool wasCompleteBefore = goal.IsComplete();

        goal.RecordEvent();

        int earned = goal.GetPoints();
        _score += earned;

        string message = $"Congratulations! You have earned {earned} points!";

        // Award bonus if a checklist goal was just completed for the first time.
        if (!wasCompleteBefore && goal.IsComplete() && goal is ChecklistGoal checklist)
        {
            _score += checklist.GetBonus();
            message += $" Plus a bonus of {checklist.GetBonus()} points for completing the goal!";
        }

        Console.WriteLine(message);
        Console.WriteLine($"You now have {_score} points.");
    }

    public void DeleteGoal()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to delete.");
            return;
        }

        ListGoalDetails();
        Console.Write("Enter the ID of the goal you want to delete: ");
        int id = int.Parse(Console.ReadLine());

        Goal goal = FindGoalById(id);
        if (goal == null)
        {
            Console.WriteLine("No goal found with that ID.");
            return;
        }

        _goals.Remove(goal);
        Console.WriteLine($"Goal '{goal.GetShortName()}' (ID {goal.GetId()}) was deleted successfully.");
    }

    public void EditGoal()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to edit.");
            return;
        }

        ListGoalDetails();
        Console.Write("Enter the ID of the goal you want to edit: ");
        int id = int.Parse(Console.ReadLine());

        Goal goal = FindGoalById(id);
        if (goal == null)
        {
            Console.WriteLine("No goal found with that ID.");
            return;
        }

        Console.WriteLine("Which field would you like to edit?");
        Console.WriteLine("  1. Name");
        Console.WriteLine("  2. Description");
        Console.WriteLine("  3. Points");
        if (goal is SimpleGoal)
        {
            Console.WriteLine("  4. Is Complete (yes/no)");
        }
        else if (goal is ChecklistGoal)
        {
            Console.WriteLine("  4. Amount Completed");
            Console.WriteLine("  5. Target");
            Console.WriteLine("  6. Bonus");
        }
        Console.Write("Your choice: ");
        string fieldChoice = Console.ReadLine();

        switch (fieldChoice)
        {
            case "1":
                Console.Write("Enter the new name: ");
                goal.SetShortName(Console.ReadLine());
                Console.WriteLine("Name updated.");
                break;
            case "2":
                Console.Write("Enter the new description: ");
                goal.SetDescription(Console.ReadLine());
                Console.WriteLine("Description updated.");
                break;
            case "3":
                Console.Write("Enter the new point value: ");
                goal.SetPoints(int.Parse(Console.ReadLine()));
                Console.WriteLine("Points updated.");
                break;
            case "4":
                if (goal is SimpleGoal simple)
                {
                    Console.Write("Is the goal complete? (yes/no): ");
                    string answer = Console.ReadLine().Trim().ToLower();
                    simple.SetIsComplete(answer == "yes" || answer == "y");
                    Console.WriteLine("Completion status updated.");
                }
                else if (goal is ChecklistGoal checklist)
                {
                    Console.Write("Enter the new amount completed: ");
                    checklist.SetAmountCompleted(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Amount completed updated.");
                }
                break;
            case "5":
                if (goal is ChecklistGoal checklistTarget)
                {
                    Console.Write("Enter the new target: ");
                    checklistTarget.SetTarget(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Target updated.");
                }
                else
                {
                    Console.WriteLine("Invalid option for this goal type.");
                }
                break;
            case "6":
                if (goal is ChecklistGoal checklistBonus)
                {
                    Console.Write("Enter the new bonus value: ");
                    checklistBonus.SetBonus(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Bonus updated.");
                }
                else
                {
                    Console.WriteLine("Invalid option for this goal type.");
                }
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private Goal FindGoalById(int id)
    {
        foreach (Goal goal in _goals)
        {
            if (goal.GetId() == id)
            {
                return goal;
            }
        }
        return null;
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split(":");
            string goalType = parts[0];
            string[] details = parts[1].Split(",");

            string name = details[0];
            string description = details[1];
            int points = int.Parse(details[2]);

            switch (goalType)
            {
                case "SimpleGoal":
                    bool isComplete = bool.Parse(details[3]);
                    SimpleGoal simple = new SimpleGoal(name, description, points);
                    if (isComplete)
                    {
                        simple.RecordEvent();
                    }
                    _goals.Add(simple);
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "ChecklistGoal":
                    int bonus = int.Parse(details[3]);
                    int target = int.Parse(details[4]);
                    int amountCompleted = int.Parse(details[5]);
                    ChecklistGoal checklist = new ChecklistGoal(name, description, points, target, bonus);
                    for (int j = 0; j < amountCompleted; j++)
                    {
                        checklist.RecordEvent();
                    }
                    _goals.Add(checklist);
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}