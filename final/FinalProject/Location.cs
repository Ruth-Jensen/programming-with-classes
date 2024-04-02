public class Location
{
    private string _name;
    private string _description;
    private int _floor;
    private List<Item> _items = new List<Item>();
    private Item _key;
    public bool Visited { get; set; }
    public bool Unlocked { get; set; }
    public Location North { get; set; }
    public Location South { get; set; }
    public Location East { get; set; }
    public Location West { get; set; }
    public Location NorthEast { get; set; }
    public Location NorthWest { get; set; }
    public Location SouthEast { get; set; }
    public Location SouthWest { get; set; }
    public Location Up { get; set; }
    public Location Down { get; set; }

    public Location(string name, string description, int floor, bool visited = false, bool unlocked = true, Item key = null)
    {
        _name = name;
        _description = description;
        _floor = floor;
        Visited = visited;
        Unlocked = unlocked;
        _key = key;
    }
    public Item GetKey() {return _key;}
    public int GetFloor() {return _floor;}
    public string GetName() {return _name;}
    public string GetDescription() {return _description;}
    
    public void PopulateLocations(Location north = null, Location south = null, Location east = null, Location west = null, Location northeast = null, Location northwest = null, Location southeast = null, Location southwest = null, Location up = null, Location down = null)
    {
        North = north;
        South = south;
        East = east;
        West = west;
        NorthEast = northeast;
        NorthWest = northwest;
        SouthEast = southeast;
        SouthWest = southwest;
        Up = up;
        Down = down;

    }
    public void AddItems(Item item) { _items.Add(item); }
    public List<Item> GetItems() { return _items; }
    public void RemoveItems(Item item) { _items.Remove(item); }
}