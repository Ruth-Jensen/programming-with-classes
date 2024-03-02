using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear(); // Clear the console screen

        // Create instances of each activity
        BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowing. CLear your mind and focus on your breathing");
        ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        ListingActivity listingActivity = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        VisualizationActivity visualizationActivity = new VisualizationActivity("Visualization Activity", "In this activity, you will be prompted to imagine serene scenes like beaches or forests, allowing you to relieve stress and tension through calming imagery.");

        string userInput; // Variable to store user input
        bool isRunning = true; // Boolean flag to control the main loop
        
        while(isRunning) // Main loop
        {
            Console.WriteLine("Menu Options:"); // Display menu options
            Console.WriteLine("     1. Start Breathing Activity:");
            Console.WriteLine("     2. Start Reflecting Activity");
            Console.WriteLine("     3. Start Listing Activity");
            Console.WriteLine("     4. Start Visualization Activity");
            Console.WriteLine("     5. Quit");
            Console.Write("Select a choice from the menu: "); // Prompt user for input

            userInput = Console.ReadLine(); // Read user input
            Console.Clear(); // Clear the console screen

            switch(userInput) // Switch statement based on user input
            {
                case "1": // If user chooses 1
                    breathingActivity.RunActivity(); // Run the breathing activity
                    break;
                case "2": // If user chooses 2
                    reflectingActivity.RunActivity(); // Run the reflecting activity
                    break;
                case "3": // If user chooses 3
                    listingActivity.RunActivity(); // Run the listing activity
                    break;
                case "4": // If user chooses 4
                    visualizationActivity.RunActivity(); // Run the visualization activity
                    break;
                case "5": // If user chooses 5
                    isRunning = false; // Set isRunning to false to exit the loop
                    break;
                default: // If user inputs an invalid option
                    Console.WriteLine("Please type a number between 1 and 4."); // Display an error message
                    break;
            }
        }
    }
}
