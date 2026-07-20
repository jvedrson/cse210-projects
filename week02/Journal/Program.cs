using System;

/*
The program exceeds the basic requirements; to improve it, I added two more
options to the menu: Edit and Delete.This would allow the user more flexibility,
and I thought it was important to do this with the end user in mind.

To achieve this, I focused on finding the tasks in the list, so I created a function
called `GetEntry` that takes the ID as an input and returns either Entry or null.
This makes it easy to determine whether to continue with the action.
*/
class Program
{
    static void Main(string[] args)
    {
        bool notQuit = true;
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to your private Journal!");

        do
        {
            DisplayMenu();
            int userMenu = int.Parse(Console.ReadLine());

            switch (userMenu)
            {
                case 1: // Write
                    string promptText = promptGenerator.GetRandomPrompt();
                    Console.Write($"{promptText}\n> ");
                    string entryText = Console.ReadLine();
                    string shortDate = DateTime.Now.ToShortDateString();

                    Entry entryToWrite = new Entry();
                    entryToWrite._promptText = promptText;
                    entryToWrite._entryText = entryText;
                    entryToWrite._date = shortDate;

                    journal.AddEntry(entryToWrite);
                    break;
                case 2: // Edit
                    if (journal._entries.Count > 0)
                    {
                        Console.Write("> Entry #");
                        int idxEdit = int.Parse(Console.ReadLine());

                        Entry entryToEdit = journal.GetEntry(idxEdit);

                        if (entryToEdit != null)
                        {
                            Console.Write($"{entryToEdit._date} - Prompt: {entryToEdit._promptText}\n> ");
                            string entryTextToEdit = Console.ReadLine();
                            journal.EditEntry(entryToEdit, entryTextToEdit);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have entries in your Journal!");
                    }
                    break;
                case 3: // Delete
                    if (journal._entries.Count > 0)
                    {
                        Console.Write("> Entry #");
                        int idxDelete = int.Parse(Console.ReadLine());

                        Entry entryToDelete = journal.GetEntry(idxDelete);

                        if (entryToDelete != null)
                        {
                            journal.DeleteEntry(entryToDelete);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have entries in your Journal!");
                    }
                    break;
                case 4: // Display
                    journal.DisplayAll();
                    break;
                case 5: // Load
                    Console.Write("What is the filename? ");
                    string fileToLoad = Console.ReadLine();
                    journal.LoadFromFile(fileToLoad);
                    break;
                case 6: // Save
                    Console.Write("What is the filename? ");
                    string fileToSave = Console.ReadLine();
                    journal.SaveToFile(fileToSave);
                    break;
                case 9: // Quit
                    notQuit = false;
                    break;
                default:
                    break;
            }
        } while (notQuit);
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nPlease select one of the following choices: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Edit");
        Console.WriteLine("3. Delete");
        Console.WriteLine("4. Display");
        Console.WriteLine("5. Load");
        Console.WriteLine("6. Save");
        Console.WriteLine("9. Quit");
        Console.Write("What would you like to do? ");
    }
}