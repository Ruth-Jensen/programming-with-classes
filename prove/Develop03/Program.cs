using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();
        Word word1 = new Word();
        List<string> verse = scripture.FindScripture("1nephi","1","06");
        try{
            while (true){
                Console.Clear();
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