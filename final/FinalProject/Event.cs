public class Event
{
    private string _name;
    public string Description {get; set;}
    public Event(string name) {_name = name;}
    public string GetName() {return _name;}
}