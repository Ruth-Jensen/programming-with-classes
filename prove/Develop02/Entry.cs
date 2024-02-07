public class Entry
{
    public string _prompt = "";
    public string _response = "";
    public DateTime _date;
    public List<(DateTime, string, string)> _entryList = new List<(DateTime, string, string)>();

    public (DateTime, string, string) addEntry (string prompt)
    {
        _date = DateTime.Now;
        _prompt = prompt;

        Console.WriteLine(_prompt);
        _response = Console.ReadLine();

        _entryList.Add((_date, _prompt, _response));

        return(_date, _prompt, _response);
    }

    public void displayEntries ()
    {
        foreach((DateTime singleDate, string singlePrompt, string singleResponse) in _entryList)
                    {
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine($"Date: {singleDate.ToString("MM/dd/yyyy")}");
                        Console.WriteLine($"    {singlePrompt}");
                        Console.WriteLine($"    {singleResponse}");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine();
                    }
    }
}