public enum EventType
{
    move,
    unlock,
    look,
    quit,
    invalid
}
public class Player : Person
{
    private List<Item> _inventory = new List<Item>();
    private int _level = 1;
    private int _xpToNextLevel = 100;
    public int CurrentXP { get; set; }

    public Player(string name, string description) : base(name, description) { }

    public (string,object) ActivateEvent(string userInput, Location currentLocation, Map masionMap) {
        Move move = new Move();
        Unlock unlock = new Unlock();

        if (userInput == "ul"){
            List<Location> aroundYou = new List<Location> {
                currentLocation.North,
                currentLocation.South,
                currentLocation.East,
                currentLocation.West,
                currentLocation.NorthEast,
                currentLocation.NorthWest,
                currentLocation.SouthEast,
                currentLocation.SouthWest,
                currentLocation.Up,
                currentLocation.Down
            };
            bool lockedDoor = false;
            foreach (Location location in aroundYou){
                if (location != null && location.GetKey() != null){
                    Item locationKey = unlock.ExecuteEvent(masionMap, location, _inventory);
                    if (locationKey != null){
                        _inventory.Remove(locationKey);
                        return ("true", "unlock");
                    }
                    else { lockedDoor = true; }
                }
            }
            if(lockedDoor) return ("false", "unlock");
            else return ("none", "unlock");

        }
        else if (userInput == "n" || userInput == "s" || userInput == "e" || userInput == "w" || userInput == "ne" || userInput == "nw" || userInput == "se" || userInput == "sw" || userInput == "u" || userInput == "d"){
            var output = move.ExecuteEvent(currentLocation, userInput);
            Location newLocation = output.Item1;
            char didMove = output.Item2;
            if(didMove == 't'){
                return ("true", newLocation);
            }
            else if(didMove == 'l'){
                return ("locked", currentLocation);
            }
            else { return ("false", currentLocation); }
        }
        else if (userInput == "l"){
            PickUpItem(currentLocation);
            return ("true", "look");
        }
        else if (userInput == "q"){
            return ("true", "quit");
        }
        else { return ("false", "invalid"); }
    }

    public List<Item> GetInventory() { return _inventory; }
    public void PickUpItem(Location location) {
        int index = 0;
        List<(string,Item)> items = new List<(string,Item)>();
        foreach (Item item in location.GetItems()) {
            index++;
            items.Add((index.ToString(), item));
        }
        string userInput;

        if (items.Count > 0) {
            bool didntPickUp = true;
            Console.WriteLine();
            while (didntPickUp) {
                Console.WriteLine("You looked around the " + location.GetName() + " and you see: ");
                foreach (var itemPair in items) {
                    Console.WriteLine($"    {itemPair.Item1}. {itemPair.Item2.GetName()}");
                }
                Console.WriteLine();
                Console.WriteLine("Type N for nothing if you don't want to pick up anything.");
                Console.Write("what would you like to pick up? ");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "n") { break; }
                foreach (var itemPair in items) {
                    if(userInput == itemPair.Item1) {
                        _inventory.Add(itemPair.Item2);
                        Console.WriteLine("You picked up the " + itemPair.Item2.GetName());
                        didntPickUp = false;
                    }
                }
                Console.Clear();
                if(didntPickUp) { Console.WriteLine("that input was not valid. please type a number between 1 and " + items.Count()); }
                else { Console.WriteLine(); }
            }
        }
        else {
            Console.WriteLine("You looked around the " + location.GetName() + " but you see nothing special.");
        }
    }
    public void UseItem(Item item) { _inventory.Remove(item); }

    public int GetLevel() { return _level; }
    public void LevelUp()
    {
        if (CurrentXP >= _xpToNextLevel)
        {
            _level++;
            CurrentXP -= _xpToNextLevel;
        }
    }

    public override void Talk() { }
    public override void TakeDamage(int damage) { }
}