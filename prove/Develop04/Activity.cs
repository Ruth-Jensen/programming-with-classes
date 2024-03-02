using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name; // Name of the activity
    private string _description; // Description of the activity
    protected int _duration; // Duration of the activity in seconds

    // Constructor to initialize name and description of the activity
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Method to start the activity
    public void StartActivity ()
    {
        Console.WriteLine($"Welcome to the {_name} \n"); // Print welcome message with activity name
        Console.WriteLine(_description + "\n"); // Print activity description

        Console.Write("How long, in seconds, would you like your session? "); // Prompt for duration input
        int userInput = int.Parse(Console.ReadLine()); // Read user input for duration
        _duration = userInput; // Set duration

        Console.Clear(); // Clear the console screen
        Console.WriteLine("Get ready..."); // Print preparation message
        Spinner(4); // Call spinner method with duration of 4 seconds
    }

    // Method to end the activity
    public void EndActivity()
    {
        Console.WriteLine("Well done!!"); // Print congratulations message
        Spinner(4); // Call spinner method with duration of 4 seconds
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}."); // Print completion message
        Spinner(4); // Call spinner method with duration of 4 seconds
        Console.Clear(); // Clear the console screen
    }

    // Method to get a random string from a given list
    public string GetRandomString(List<string> stringList)
    {
        // Parameters:
        //   stringList: List<string> - The list of strings to choose from
        // Returns:
        //   string - The randomly chosen string

        Random random = new Random(); // Create a new random object
        int Index = random.Next(0, stringList.Count); // Generate a random index within the range of the list
        return stringList[Index]; // Return the string at the randomly chosen index
    }

    // Method to display countdown
    public void Counter (string prompt, int length)
    {
        // Parameters:
        //   prompt: string - The prompt to display before the countdown
        //   length: int - The length of the countdown

        Console.Write(prompt); // Display prompt
        for (int l = length; l > 0; l--) // Loop for countdown
        {
            Console.Write(l); // Display current countdown value
            Thread.Sleep(1000); // Wait for 1 second
            Console.Write(new string('\b', l.ToString().Length)); // Move cursor back
            Console.Write(new string(' ', l.ToString().Length)); // Clear previous character
            Console.Write(new string('\b', l.ToString().Length)); // Move cursor back again
        }
        Console.WriteLine(); // Move cursor to next line after countdown
    }

    // Method to display spinner animation
    public void Spinner(int duration)
    {
        // Parameters:
        //   duration: int - The duration of the spinner animation in seconds

        List<char> animation = new List<char>(); // Create a list to store animation characters
        for (int d = duration; d > 0; d--) // Loop to Add animation characters
        {
            animation.Add('|');
            animation.Add('/');
            animation.Add('-');
            animation.Add('\\');
        }

        foreach(char a in animation) // Loop to display animation
        {
            Console.Write(a); // Display current animation character
            Thread.Sleep(250); // Wait for 0.25 seconds
            Console.Write('\b'); // Move cursor back
        }
        Console.WriteLine(' '); // Clear previous character and move cursor to next line after animation
    }
}
