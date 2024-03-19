using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();
        Word word1 = new Word();
        bool gotVerse = false;
        string userInput = "";
        
        Console.Clear();
        while (gotVerse == false) {
            Console.WriteLine("Welcome to the Scripture Memorizer.");
            Console.WriteLine("What verse in 1 Nephi chapter 1 do you want to memorize? ");
            userInput = Console.ReadLine();
            try {
                int verseNumber = int.Parse(userInput);
                if (verseNumber < 1 || verseNumber > 20) {throw new Exception();}
                if (userInput.Length < 2) {userInput = "0" + userInput;}
                gotVerse = true;
            }
            catch {
                Console.Clear();
                Console.WriteLine("Error: Please enter a number between 1 and 20.");
            }
        }

        List<string> verse = scripture.FindScripture("1nephi","1", userInput);
        try{
            while (true){
                Console.Clear();
                Console.WriteLine("Press q to quit");
                Console.WriteLine();
                Console.Write("1 Nephi 1:");
                foreach (string word in verse){
                    Console.Write(word);
                    Console.Write(" ");
                }
                string input = Console.ReadLine();
                if (input == "q"){
                    break;
                }
                word1.ReplaceWord(verse);
            }
        }
        catch{
            Console.WriteLine("Error");
        }
    }
}