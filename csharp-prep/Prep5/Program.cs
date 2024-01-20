using System;

class Program
{
    static void DisplayWelcome()
    {
        //Displays the message, "Welcome to the Program!"
        Console.WriteLine("Welcome to the program!");
    }
    
    static string PromptUserName()
    {
        //Asks for and returns the user's name (as a string)
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    
    static int PromptUserNumber()
    {
        //Asks for and returns the user's favorite number (as an integer)
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());
        return favoriteNumber;
    }
    
    static int SquareNumber(int number)
    {
        //Accepts an integer as a parameter and returns that number squared (as an integer)
        int squaredNumber = number * number;
        return squaredNumber;
    }
    
    static void DisplayResult(string name, int number)
    {
        //Accepts the user's name and the squared number and displays them.
        Console.WriteLine($"{name}, the square of your number is {number}");
    }
    
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);
        DisplayResult(name, squaredNumber);
    }
}