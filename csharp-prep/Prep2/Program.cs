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

        //gives you a grade based on the score inputed
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

        //adds a + or a - sign based on score inputed
        if (grade % 10 >= 7 && letterGrade != "A" && letterGrade != "F")
        {
            letterGrade += "+";
        }
        else if (grade % 10 < 3 && letterGrade != "F")
        {
            letterGrade += "-";
        }

        //print the grade the user recieved
        Console.WriteLine($"The grade you recieved is a {letterGrade}");

        //tell the user if they passed or not
        if (grade >= 70)
        {
            Console.WriteLine("You passed");
        }
        else
        {
            Console.WriteLine("You didn't pass");
        }
    }
}