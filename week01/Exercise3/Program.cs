using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = false;
        int gamesPlayed = 1;
        Console.WriteLine("Welcome to Guess My Number game!");

        do
        {
            Random randomGenerator = new Random();
            int winnerNumber = randomGenerator.Next(1, 100);
            int attempts = 0;
            bool isGuessing;

            Console.WriteLine(winnerNumber);
            do
            {
                Console.Write("What is your guess? ");
                int userNumber = int.Parse(Console.ReadLine());
                attempts += 1;

                isGuessing = userNumber != winnerNumber;

                if (isGuessing && (userNumber < winnerNumber))
                {
                    Console.WriteLine("Higher");
                }
                else if (isGuessing && (userNumber > winnerNumber))
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    if (attempts == 1)
                    {
                        Console.WriteLine("Incredible!!! Just one attempt and you guessed it!\n");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it! Attempts made: {attempts}\n");
                    }

                    Console.Write("Do you want to play again (yes or y)? ");
                    string response = Console.ReadLine();

                    if (response == "yes" || response == "y")
                    {
                        playAgain = true;
                        gamesPlayed += 1;
                    }
                    else
                    {
                        playAgain = false;
                    }
                }
            } while (isGuessing);

            if (playAgain)
            {
                Console.WriteLine("\nNew number generated!");
            }
            else
            {
                Console.WriteLine($"\nGames played: {gamesPlayed}");
            }
        } while (playAgain);
    }
}