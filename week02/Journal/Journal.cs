using System;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public Entry GetEntry(int index)
    {
        if (index > 0 && index <= _entries.Count)
        {
            return _entries[index - 1];
        }
        else
        {
            Console.WriteLine("Entry number does not exist. Check and try again.");
            return null;
        }
    }


    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void EditEntry(Entry entry, string newAnswer)
    {
        entry.EditEntryText(newAnswer);
        Console.WriteLine("Your entry has beed Edited");
    }

    public void DeleteEntry(Entry entry)
    {
        _entries.Remove(entry);
        Console.WriteLine("Entry has beed Deleted");
    }


    public void DisplayAll()
    {
        if (_entries.Count() > 0)
        {
            for (int i = 0; i < _entries.Count(); i++)
            {
                _entries[i].Display(i);
            }
        }
        else
        {
            Console.WriteLine("You don't have entries in your Journal!");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry item in _entries)
            {
                outputFile.WriteLine($"{item._promptText},{item._entryText},{item._date}");
            }
        }

    }

    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            string prompt = parts[0];
            string entryText = parts[1];
            DateTime date = DateTime.Parse(parts[2]);

            Entry entry = new Entry();
            entry._promptText = prompt;
            entry._entryText = entryText;
            entry._date = date.ToShortDateString();

            _entries.Add(entry);
        }

    }
}