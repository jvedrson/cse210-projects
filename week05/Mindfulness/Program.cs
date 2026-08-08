using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        do
        {
            Console.Clear();
            DisplayMenu();
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.DisplayStartingMessage();
                    breathing.Run();
                    break;

                case 2:
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.DisplayStartingMessage();
                    break;

                case 3:
                    ListingActivity listing = new ListingActivity();
                    listing.DisplayStartingMessage();
                    break;

                case 4:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Wrong choice!");
                    break;
            }
        } while (running);
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("\t1. Start breathing activity");
        Console.WriteLine("\t2. Start reflecting activity");
        Console.WriteLine("\t3. Start listing activity");
        Console.WriteLine("\t4. Quit");
        Console.Write("Select a choice from the menu: ");
    }
}