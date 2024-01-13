using System;

class Program
{
    static void Main(string[] args)
    {
        //A >= 90 B >= 80 C >= 70 D >= 60 F < 60
        Console.Write("What score did you get in your class?: ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);
    }
}