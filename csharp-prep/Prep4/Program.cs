using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        List<int> sortedNumbers;
        int userInput = 1;
        int sum = 0;
        int largestNum;
        int smallestPos;
        float average = 0;
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (userInput != 0)
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }
        
        sortedNumbers = numbers;
        sortedNumbers.Sort();
        sortedNumbers.Reverse();
        if (sortedNumbers[0] > 0)
        {
            smallestPos = sortedNumbers[0];
            foreach (int number in sortedNumbers)
            {
                if (number < smallestPos && number > 0)
                {
                    smallestPos = number;
                }
            }
        }
        else
        {
            smallestPos = 0;
        }
        sortedNumbers.Sort();

        largestNum = numbers[0];
        foreach (int number in numbers)
        {
            sum += number;
            if (number > largestNum)
            {
                largestNum = number;
            }

        }
        average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNum}");
        if (smallestPos != 0)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPos}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers.");
        }
        Console.WriteLine("The sorted list is:");
        foreach(int number in sortedNumbers)
        {
            Console.WriteLine(number);
        }
    }
}