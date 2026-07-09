using System;

class Program
{
    static void Main(string[] args)
    {
        string sign = "";
        string letter = "F";

        Console.Write("What is your grade percentage? ");
        int grade = int.Parse(Console.ReadLine());
        int lastDigit = grade % 10;

        if (lastDigit >= 7 && grade > 60 && grade < 90)
        {
            sign = "+";
        }
        else if (lastDigit <= 3 && grade >= 60 && grade < 94)
        {
            sign = "-";
        }

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {

            letter = "B";
        }
        else if (grade >= 70)
        {

            letter = "C";
        }
        else if (grade >= 60)
        {

            letter = "D";
        }

        Console.WriteLine($"\nYour letter grade is {letter}{sign}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations... You have passed!");
        }
        else
        {
            Console.WriteLine("Keep striving... you did not reach the goal this time, but try again.");
        }
    }
}