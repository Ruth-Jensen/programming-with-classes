using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    // List of prompts for user to list
    private List<string> _prompts = new List<string> {"Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};

    // Constructor to initialize name and description of the listing activity
    public ListingActivity(string name, string description) : base(name, description) { }

    // Method to run the listing activity
    public void RunActivity()
    {
        int numberListed = 0; // Initialize the count of listed items
        StartActivity(); // Start the listing activity

        Console.WriteLine("List as many responses you can to the following prompt:"); // Display a message prompting the user to list items
        Console.WriteLine($"--- {GetRandomString(_prompts)} ---"); // Display a random prompt for listing
        Counter("You may begin in: ", 5); // Display countdown before starting listing

        DateTime startTime = DateTime.Now; // Get the current time as the start time of the activity
        DateTime endTime = startTime.AddSeconds(_duration); // Calculate the end time of the activity based on the duration

        while(DateTime.Now < endTime) // Loop until the current time reaches the end time
        {
            Console.Write("> "); // Prompt the user to input an item
            Console.ReadLine(); // Read the input
            numberListed ++; // Increment the count of listed items
        }
        Console.WriteLine($"You have listed {numberListed} items! \n"); // Display the total count of listed items
        EndActivity(); // End the listing activity
    }
}
