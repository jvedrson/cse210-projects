using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] splitText = text.Split(" ");

        foreach (var item in splitText)
        {
            _words.Add(new Word(item));
        }
    }

    public void HideRandomWords(int numbersToHide)
    {
        Random randomGenerator = new Random();
        int totalHiddenWords = 0;

        while (totalHiddenWords < numbersToHide && !IsCompletelyHidden())
        {
            Word word = _words[randomGenerator.Next(0, _words.Count)];
            if (!word.IsHidden())
            {
                word.Hide();
                ++totalHiddenWords;
            }
        }
    }

    public string GetDisplayText()
    {
        string newText = "";
        foreach (var word in _words)
        {
            newText += " " + word.GetDisplayText();
        }
        return $"{_reference.GetDisplayText()} {newText}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}