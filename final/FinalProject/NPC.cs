public class NPC : Person
{
    /* NPC-Specific Traits:
    Attributes: Dialogue, Quests, Faction, Relationships, TradeInventory
    Methods: InitiateDialogue(), GiveQuest(), Trade() */
    private Tuple<Event, string> _questDialogue;
    private Tuple<Event, Item> _questItem;
    public NPC(string name, string description, int health = 100) : base(name, description, health) { }
    public override void TakeDamage(int damage) { }
    public override void Talk() { }
}



/* Enemy-Specific Traits:
    Attributes: Behavior, Location, Weaknesses, LootTable
    Methods: ObstructPath(), TriggerPuzzle(), DropClue() */