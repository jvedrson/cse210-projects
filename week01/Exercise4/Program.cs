using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> userNumbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber;
        do
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                userNumbers.Add(userNumber);
            }

        } while (userNumber != 0);

        int sum = 0;
        foreach (int num in userNumbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");

        double average = (double)sum / userNumbers.Count;
        Console.WriteLine($"The average is: {average}");

        int maxNumber = int.MinValue;
        foreach (int num in userNumbers)
        {
            if (num > maxNumber)
            {
                maxNumber = num;
            }
        }
        Console.WriteLine($"The largest number is: {maxNumber}");

        int minNumber = int.MaxValue;
        foreach (int num in userNumbers)
        {
            if (num > 0 && num < minNumber)
            {
                minNumber = num;
            }
        }
        Console.WriteLine($"The smallest positive number is: {minNumber}");

        userNumbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int num in userNumbers)
        {
            Console.WriteLine(num);
        }
    }
}
