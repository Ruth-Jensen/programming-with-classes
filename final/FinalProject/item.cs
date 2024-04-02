public enum ItemType
{
    armor,
    weapon,
    key,
    consumable,
    questItem,
    other
}

public class Item
{
    private string _name;
    private string _description;
    private ItemType _type;
    private bool _equipped = false;
    public Item(string name, string description, ItemType type){
        _name = name;
        _description = description;
        _type = type;
    }
    public string GetName() {return _name;}
}