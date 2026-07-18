using System;

public class Entry
{
    public string _promptText;
    public string _entryText;
    public string _date;

    public void EditEntryText(string newEntryText)
    {
        _entryText = newEntryText;
    }


    public void Display(int index)
    {
        Console.WriteLine($"\nEntry #{index + 1}");
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
    }
}