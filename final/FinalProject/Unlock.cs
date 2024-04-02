public class Unlock : Event
{
    public Unlock() : base("unlock") {}
    public Item ExecuteEvent(Map masionMap, Location location, List<Item> inventory)
    {   
        Item key = location.GetKey();
        foreach (Item item in inventory)
        {
            if (key.GetName() == item.GetName())
            {
                masionMap.visitLocation(location);
                return item;
            }
        }
        return null;
    }
}