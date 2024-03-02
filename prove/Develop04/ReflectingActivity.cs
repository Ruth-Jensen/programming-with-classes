using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    // List of prompts for reflection
    private List<string> _prompts = new List<string>{"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."}; 
    // List of questions for reflection
    private List<string> _questions = new List<string>{"Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"}; 

    // Constructor to initialize name and description of the reflecting activity
    public ReflectingActivity(string name, string description) : base(name, description) { }

    // Method to run the reflecting activity
    public void RunActivity()
    {
        StartActivity(); // Start the reflecting activity

        // Display a random prompt for reflection
        Console.WriteLine("Consider the following prompt: \n"); 
        Console.WriteLine($"--- {GetRandomString(_prompts)} --- \n");
        // Wait for user to press enter
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience."); // Display a message for reflection
        Counter("You may begin in: ", 5); // Display countdown before starting reflection
        Console.Clear(); // Clear the console screen

        Console.Write($"> {GetRandomString(_questions)} "); // Display a random question for reflection
        Spinner(_duration / 2); // Display spinner animation for half of the activity duration

        Console.Write($"> {GetRandomString(_questions)} "); // Display another random question for reflection
        Spinner(_duration / 2); // Display spinner animation for the remaining half of the activity duration
        Console.WriteLine(); // Move to the next line

        EndActivity(); // End the reflecting activity
    }
}