using System;
using System.Collections.Generic;
using System.Threading;

public class BreathingActivity : Activity
{
    // Constructor to initialize name and description of the breathing activity
    public BreathingActivity(string name, string description) : base(name, description) { }

    // Method to run the breathing activity
    public void RunActivity()
    {
        StartActivity(); // Start the breathing activity

        DateTime startTime = DateTime.Now; // Get the current time as the start time of the activity
        DateTime endTime = startTime.AddSeconds(_duration); // Calculate the end time of the activity based on the duration

        while(DateTime.Now < endTime) // Loop until the current time reaches the end time
        {
            Counter("Breath in...", 4); // Display countdown for breathing in
            Counter("Now breath out...", 6); // Display countdown for breathing out
            Console.WriteLine(); // Move to the next line after each breathing cycle
        }

        EndActivity(); // End the breathing activity
    }
}
