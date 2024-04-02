using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Entry entry = new Entry();
        File file = new File();
        string userChoice = "";

        while(userChoice != "5")
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Wecome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices.");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.Write("What would you like to do? ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    entry.addEntry(prompt);
                    break;
                case "2":
                    file.DisplayLoadedFiles();
                    entry.displayEntries();
                    break;
                case "3":
                    file.Load();
                    break;
                case "4":
                    file.Save(entry._entryList);
                    entry._entryList = new List<(DateTime, string, string)>();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("please enter a number between 1 and 5");
                    break;
            }
        }
    }
}