public class File
{
    public List<(DateTime, string, string)> _entries = new List<(DateTime, string, string)>();

    public void Save (List<(DateTime date, string prompt, string response)> entries)
    {
        using (StreamWriter writer = new StreamWriter("Journal.txt", true))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"Date: {entry.date}");
                writer.WriteLine($"    Prompt: {entry.prompt}");
                writer.WriteLine($"    Response: {entry.response}");
                writer.WriteLine();
            }
        }
        Console.WriteLine("Saved Successfully.");
        Load();
    }
    public List<(DateTime date, string prompt, string response)> Load()
    {
        _entries = new List<(DateTime, string, string)>();
        try
        {
            using (StreamReader reader = new StreamReader("Journal.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string dateLine = reader.ReadLine();
                    string promptLine = reader.ReadLine();
                    string responseLine = reader.ReadLine();
                    reader.ReadLine();

                    DateTime date;
                    if (DateTime.TryParse(dateLine.Substring("Date: ".Length), out date))
                    {
                        _entries.Add((date, promptLine.Trim(), responseLine.Trim()));
                    }
                    else
                    {
                        Console.WriteLine($"Error turning string into datetime in line: {dateLine}");
                    }
                }
            }
            Console.WriteLine("Successfully loaded data from file.");
        }
        catch (Exception)
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Error one of the following must be true:");
            Console.WriteLine("     Journal.txt doesn't exist");
            Console.WriteLine("     Journal.txt isn't where the program knows to find it");
            Console.WriteLine("     Journal.txt is blank. It has nothing writen on it");
            Console.WriteLine("     one of the dates in Journal.txt was mistyped or put on the wrong line");
            Console.WriteLine("     be careful of extra blank lines");
        }

        return _entries;
    }
    public void DisplayLoadedFiles()
    {
        try
        {
            foreach((DateTime singleDate, string singlePrompt, string singleResponse) in _entries)
            {
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine($"Date: {singleDate.ToString("MM/dd/yyyy")}");
                Console.WriteLine($"    Prompt: {singlePrompt}");
                Console.WriteLine($"    Response: {singleResponse}");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine();
            }

        }
        catch(Exception){Console.WriteLine("nothing");}
    }
}