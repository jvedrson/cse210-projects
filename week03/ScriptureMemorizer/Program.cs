using System;

/*
The program exceeds the basic requirements; to improve it, I added:

- A menu to choose 1 of 3 books (Old Testament, New Testament, and The Book of Mormon)
- A new "ScriptureGenerator" class
- 5 predefined scriptures for these books
- They will be displayed randomly

This will give the user more options for studying the scriptures.
*/

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        Console.WriteLine("Welcome to Scripture Memorizer");

        DisplayMenu();
        string book = Console.ReadLine();

        ScriptureGenerator scriptureGenerator = new ScriptureGenerator();
        Scripture scripture = scriptureGenerator.GetRandomScripture(book);

        do
        {
            Console.WriteLine($"\n{scriptureGenerator.GetBookSelected()}");
            Console.WriteLine(scripture.GetDisplayText());

            Console.Write("\nPress enter to continue or type 'quit' to finish: ");
            string enter = Console.ReadLine();

            if (scripture.IsCompletelyHidden() || enter != null && enter == "quit")
            {
                running = false;
                break;
            }
            else
            {
                Console.Clear();
                scripture.HideRandomWords(3);
            }
        } while (running);
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nChoose the book option you would like to learn from ");
        Console.WriteLine("1. Old Testament");
        Console.WriteLine("2. New Testament");
        Console.WriteLine("3. The Book of Mormon");
        Console.Write("Enter your option (default Old Testament): ");
    }
}