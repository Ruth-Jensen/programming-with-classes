using System;

class Program
{
    static void Main(string[] args)
    {
        bool keepPlaying = true;
        while (keepPlaying)
        {
            Random randomGenerator = new Random();
            string userInput = "";
            int magicNumber = randomGenerator.Next(1, 100);
            int guess = 0;
            int guessNum = 0;

            while (guess != magicNumber)
            {
                guessNum += 1;
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessNum} trys.");
                }
            }

            while (true)
            {
                Console.Write("Would you like to play again? ");
                userInput = Console.ReadLine().ToUpper();

                if (userInput == "YES")
                {
                    break;
                }
                else if (userInput == "NO")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter YES or NO.");
                }
            }
            if (userInput == "NO")
            {
                keepPlaying = false;
            }
        }
    }
}