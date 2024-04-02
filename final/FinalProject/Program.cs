using System;

class Program
{
    static void Main(string[] args)
    {
        Map map = new Map();

        Location previousLocation = map.GetStartingLocation();
        Location currentLocation = map.GetStartingLocation();
        Player player = new Player("player", "a player");

        bool isrunning = true;

        Console.Clear();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;

        while (isrunning){

            map.PrintMap(currentLocation);

            Console.WriteLine("Actions:");
            Console.WriteLine(" Use these to move:");
            Console.WriteLine("     n = north, s = south, e = east, w = west");
            Console.WriteLine("     ne = north-east, nw = north-west, se = south-east, sw = south-west");
            Console.WriteLine("     u = up, d = down");
            Console.WriteLine(" Other Actions: ul = unlock, l = look, q = quit");
            Console.WriteLine();

            Console.WriteLine("You are currently in the " + currentLocation.GetName());
            // Console.WriteLine(currentLocation.GetDescription());
            Console.Write("What would you like to do? ");
            string userInput = Console.ReadLine().ToLower();

            Console.Clear();

            var output = player.ActivateEvent(userInput, currentLocation, map);
            string successful = output.Item1;
            string eventType;

            try{
                currentLocation = (Location)output.Item2;
                if (successful == "false") {
                    Console.WriteLine("You can't go that way");
                    // Warning.FlashColor(3, "red");
                }
                else if (successful == "locked") { Console.WriteLine("The door is locked"); }
                else {Console.WriteLine();}
            }
            catch{
                eventType = output.Item2.ToString();
                if (eventType == "unlock") {
                    if(successful == "true") { Console.WriteLine("You unlocked the door"); }
                    else if (successful == "false") { Console.WriteLine("You don't have the key"); }
                    else { Console.WriteLine("there is nothing to unlock"); }
                }
                else if (eventType == "quit") {
                    isrunning = false;
                }
                else if (eventType == "look") {
                    // Console.Clear();
                    // Console.WriteLine();
                }
                else if (eventType == "invalid") { Console.WriteLine("That input is not valid"); }
            }

            if (currentLocation.GetName() == "Courtyard") {
                Console.WriteLine("Congrats! You escaped the mansion!");
                isrunning = false;
            }
            map.visitLocation(currentLocation);
        }
    }
        // List<string> compass = new List<string>
        // {
        //     "_______________________________________",
        //     "|  Move around with:    North: N      |",
        //     "|                       South: S      |",
        //     "|   nw  N  ne      U    East: E       |",
        //     "|     \\ | /       /|\\   West: W       |",
        //     "|      \\|/         |    NorthEast: NE |",
        //     "| W-----|-----E    |    NorthWest: NW |",
        //     "|      /|\\         |    SouthEast: SE |",
        //     "|     / | \\       \\|/   SouthWest: SW |",
        //     "|   sw  S  se      D    Up: U         |",
        //     "|_______________________Down:_D_______|",
        // };

        // List<string> menu = new List<string>
        // {
        //     "   Please choose an action:",
        //     "   Move: N, S, E, W, NE, NW, SE, SW, U, D",
        //     "   View Inventory: I",
        //     "   Look Around: L",
        //     "   View Map: M",
        //     "   Pick Up Item: P",
        //     "   Use Item: R",
        //     "   Talk to NPC: T",
        // };
}
