using System;

class Program
{
    static void Main(string[] args)
    {
        //prompt the user for a score
        Console.Write("What score did you get in your class?: ");
        string input = Console.ReadLine();

        //convert the users input into an int
        int grade = int.Parse(input);
        string letterGrade;

        //A >= 90 B >= 80 C >= 70 D >= 60 F < 60
        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        //print the grade the user recieved
        Console.WriteLine($"The grade you recieved is a {letterGrade}");
    }
}