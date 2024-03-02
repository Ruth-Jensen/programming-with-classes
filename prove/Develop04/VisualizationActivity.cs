using System;
using System.Collections.Generic;
using System.Threading;

public class VisualizationActivity : Activity
{
    // List of prompts for the user to visualize
    private List<string> _prompts = new List<string> {"Imagine yourself standing on a peaceful beach, feeling the warm sand between your toes and hearing the gentle sound of waves crashing.", "Picture yourself walking through a serene forest, surrounded by tall trees, dappled sunlight, and the earthy scent of nature.", "Visualize yourself sitting beside a tranquil mountain stream, listening to the soothing sound of flowing water and feeling a gentle breeze against your skin.", "Envision yourself lying in a lush green meadow, watching the clouds drift lazily across the sky and feeling the warmth of the sun on your face.", "Imagine yourself floating on a calm lake, feeling completely weightless and relaxed as you gaze up at the clear blue sky above.", "Picture yourself standing atop a majestic mountain peak, breathing in the crisp, fresh air and taking in the breathtaking panoramic views all around you.", "Visualize yourself sitting beside a crackling campfire under a starry night sky, feeling the warmth of the flames and listening to the peaceful sounds of nature.", "Envision yourself strolling through a vibrant flower garden, surrounded by colorful blooms and the sweet scent of flowers in bloom.", "Picture yourself sitting on a tranquil meditation cushion in a serene temple, surrounded by flickering candlelight and the sound of soft chanting.", "Imagine yourself floating weightlessly in the vastness of space, surrounded by twinkling stars and distant galaxies, feeling a sense of peace and wonder."};
    
    // Constructor to initialize name and description of the visualization activity
    public VisualizationActivity(string name, string description) : base(name, description) { }

    // Method to run the visualization activity
    public void RunActivity()
    {
        StartActivity(); // Start the visualization activity

        Console.WriteLine("Try to envision each of the following prompts. Let your imagination take you to a different place."); // Display a message for visualization
        Counter("You may begin in: ", 5); // Display countdown before starting visualization

        // Loop through prompts for visualization
        for(int n = 3; n > 0; n--)
        {
            Console.Clear(); // Clear console for new prompt
            Console.WriteLine("Try to envision each of the following prompts. Let your imagination take you to a different place. \n"); // Display a message for visualization
            Console.WriteLine(GetRandomString(_prompts)); // Display a random prompt for visualization
            Spinner(_duration / 3); // Display spinner animation for a third of the activity duration
        }

        EndActivity(); // End the activity
    }

}