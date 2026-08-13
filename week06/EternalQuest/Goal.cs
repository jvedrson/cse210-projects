using System;

public abstract class Goal
{
    private static int _nextId = 1;
    protected int _id;
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _id = _nextId;
        _nextId++;
        _shortName = name;
        _description = description;
        _points = points;
    }

    public int GetId()
    {
        return _id;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void SetShortName(string name)
    {
        _shortName = name;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public void SetPoints(int points)
    {
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox = "[ ]";
        if (IsComplete())
        {
            checkbox = "[X]";
        }
        return $"{checkbox} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}