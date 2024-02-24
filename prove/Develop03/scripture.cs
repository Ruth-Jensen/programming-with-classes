public class Scripture{
    List<Reference> referenceList = new List<Reference>
        {
            new Reference { Book = "1nephi", Chapter = "01", Verse = 20 },
            new Reference { Book = "1nephi", Chapter = "02", Verse = 24 },
            new Reference { Book = "1nephi", Chapter = "03", Verse = 31 },
            new Reference { Book = "1nephi", Chapter = "04", Verse = 38 },
            new Reference { Book = "1nephi", Chapter = "05", Verse = 22 },
            new Reference { Book = "1nephi", Chapter = "06", Verse = 6 },
            new Reference { Book = "1nephi", Chapter = "07", Verse = 22 },
            new Reference { Book = "1nephi", Chapter = "08", Verse = 38 },
            new Reference { Book = "1nephi", Chapter = "09", Verse = 6 },
            new Reference { Book = "1nephi", Chapter = "10", Verse = 22 },
        };

    public List<string> FindScripture(string book, string chapter, string verse)
    {
        try{
            Console.WriteLine($"{book}{chapter}.txt");
            StreamReader reader = new StreamReader($"{book}{chapter}.txt");
            while(!reader.EndOfStream){

                List<string> words = new List<string>();
                string currentVerse = reader.ReadLine();

                if (currentVerse.StartsWith(verse))
                {
                    string word = "";
                    foreach (char character in currentVerse)
                    {
                        if (character == ' '){
                            words.Add(word);
                            word = "";
                        }
                        else{
                            word += character;
                        }
                    }
                    return words;
                }
            }
            Console.WriteLine("verse doesn't exist");
            return null;
        }
        catch{
            Console.WriteLine("file doesn't exist");
            return null;
        }
    }
}