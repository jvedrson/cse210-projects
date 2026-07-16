using System;

public class Entry
{
    public string _question;
    public string _answer;
    public DateTime _date;

    public Entry(string question, string answer, DateTime dateTime)
    {
        _question = question;
        _answer = answer;
        _date = dateTime;
    }

    public void DisplayEntry()
    {

    }
}