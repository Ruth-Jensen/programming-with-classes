public class Map
{
    private Location _courtyard;
    
    // Second Floor
    private List<Location> _secondFloor;
    private Location _library;
    private Location _arcanum;
    private Location _observatory;
    private Location _alchemyLab;
    private Location _balconyGarden;

    // Ground Floor
    private List<Location> _groundFloor;
    private Location _frontEntrance;
    private Location _servantQuarters;
    private Location _ballRoom;
    private Location _diningRoom;
    private Location _kitchen;
    private Location _westWing;
    private Location _hall;
    private Location _eastWing;
    private Location _guestRoom1;
    private Location _guestRoom2;
    private Location _guestRoom3;

    // Basement
    private List<Location> _basement;
    private Location _cellar;
    private Location _storageRoom;
    private Location _secretChamber;

    public Map() {

        Item courtyardKey = new Item("Courtyard Key", "", ItemType.key);
        Item secretChamberKey = new Item("Secret Room Key", "", ItemType.key);

        _courtyard = new Location("Courtyard", "", 1, false, false, courtyardKey);

        // Second Floor Locations
        _library = new Location("Library", "", 2);
        _arcanum = new Location("Arcanum", "", 2);
        _observatory = new Location("Observatory", "", 2);
        _alchemyLab = new Location("Alchemy Lab", "", 2);
        _balconyGarden = new Location("Balcony Garden", "", 2);

        // Ground Floor Locations

        _frontEntrance = new Location("Front Entrance", "", 1, true);
        _servantQuarters = new Location("Servant Quarters", "", 1);
        _ballRoom = new Location("Ball Room", "", 1);
        _diningRoom = new Location("Dining Room", "", 1);
        _kitchen = new Location("Kitchen", "", 1);
        _westWing = new Location("West Wing", "", 1);
        _hall = new Location("Hall", "", 1);
        _eastWing = new Location("East Wing", "", 1);
        _guestRoom1 = new Location("Guest Room 1", "", 1);
        _guestRoom2 =  new Location("Guest Room 2", "", 1);
        _guestRoom3 =  new Location("Guest Room 3", "", 1);
        
        // Basement Locations
        _cellar = new Location("Cellar", "", 0);
        _storageRoom = new Location("Storage Room", "", 0);
        _secretChamber = new Location("Secret Chamber", "", 0, false, false, secretChamberKey);
        
        // Populate Second Floor Locations
        _library.PopulateLocations(null, _observatory);
        _arcanum.PopulateLocations(null, null, _observatory, null, null, null, null, null, null, _westWing);
        _observatory.PopulateLocations(_library, _balconyGarden, _alchemyLab, _arcanum);
        _alchemyLab.PopulateLocations(null, null, null, _observatory, null, null, null, null, null, _eastWing);
        _balconyGarden.PopulateLocations(_observatory);

        // Populate Ground Floor Locations
        _courtyard.PopulateLocations(null, _diningRoom, _servantQuarters, _frontEntrance);
        _frontEntrance.PopulateLocations(null, _ballRoom, _courtyard);
        _servantQuarters.PopulateLocations(null, _kitchen, null, _courtyard, null, null, null, null, null, _cellar);
        _ballRoom.PopulateLocations(_frontEntrance, _westWing, _diningRoom, null, null, null, _hall);
        _diningRoom.PopulateLocations(_courtyard, _hall, _kitchen, _ballRoom, null, null, null, null, null, _secretChamber);
        _kitchen.PopulateLocations(_servantQuarters, _eastWing, null, _diningRoom, null, null, null, _hall);
        _westWing.PopulateLocations(_ballRoom, null, _hall, null, null, null, null, null, _arcanum);
        _hall.PopulateLocations(_diningRoom, _guestRoom2, _eastWing, _westWing, _kitchen, _ballRoom, _guestRoom3, _guestRoom1);
        _eastWing.PopulateLocations(_kitchen, null, null, _hall, null, null, null, null, _alchemyLab);
        _guestRoom1.PopulateLocations(null, null, null, null, _hall);
        _guestRoom2.PopulateLocations(_hall);
        _guestRoom3.PopulateLocations(null, null, null, null, null, _hall);

        // Populate Basement Locations
        _cellar.PopulateLocations(null, _storageRoom, null, null, null, null, null, null, _servantQuarters);
        _storageRoom.PopulateLocations(_cellar, null, null, _secretChamber);
        _secretChamber.PopulateLocations(null, null, _storageRoom, null, null, null, null, null, _diningRoom);

        _observatory.AddItems(secretChamberKey);
        _secretChamber.AddItems(courtyardKey);

        // Assign Floors
        _secondFloor = new List<Location>{_library, _arcanum, _observatory, _alchemyLab, _balconyGarden};
        _groundFloor = new List<Location>{_courtyard,_frontEntrance, _servantQuarters, _ballRoom, _diningRoom, _kitchen, _westWing, _hall, _eastWing, _guestRoom1, _guestRoom2, _guestRoom3};
        _basement = new List<Location>{_cellar, _storageRoom, _secretChamber};

    }
    public Location GetStartingLocation(){return _frontEntrance;}
    public void visitLocation(Location currentLocation)
    {
        if(currentLocation.GetFloor() == 0){
            foreach(Location location in _basement){
                if(location.GetName() == currentLocation.GetName()){
                    location.Visited = true;
                    location.Unlocked = true;}
            }
        }
        else if(currentLocation.GetFloor() == 1){
            foreach(Location location in _groundFloor){
                if(location.GetName() == currentLocation.GetName()){ 
                    location.Visited = true; 
                    location.Unlocked = true;}
            }
        }
        else if(currentLocation.GetFloor() == 2){
            foreach(Location location in _secondFloor){
                if(location.GetName() == currentLocation.GetName()){ 
                    location.Visited = true; 
                    location.Unlocked = true;}
            }
        }
    }
    public void PrintMap(Location currentLocation){
        int floor = currentLocation.GetFloor();
        if (floor == 0){
            List<string> floorMap = UpdateBasementMap();
            foreach (string line in floorMap){
                if(!string.IsNullOrWhiteSpace(line)) { Console.WriteLine(line); }
            }
        }
        else if (floor == 1){
            List<string> floorMap = UpdateGroundFloorMap();
            foreach (string line in floorMap){
                if(!string.IsNullOrWhiteSpace(line)) { Console.WriteLine(line); }  
            }
        }
        else if (floor == 2){
            List<string> floorMap = UpdateSecondFloorMap();
            foreach (string line in floorMap){
                if(!string.IsNullOrWhiteSpace(line)) { Console.WriteLine(line); }  
            }
        }
        else{
            Console.WriteLine("couldn't find floor map");
        }
    }
    // public Location ChangeLocation(Location currentlocation, string dirrection)
    // {
    //     Location newLocation;
    //     int floor;

    //     switch (dirrection){

    //         case "n":
    //         try{
    //             newLocation = currentlocation.North;
    //             floor = newLocation.GetFloor();}
    //         catch{
    //             Console.WriteLine("You can't go that way");
    //             return currentlocation;}
    //         break;

    //         case "s":
    //         try{
    //             newLocation = currentlocation.South;
    //             floor = newLocation.GetFloor();}
    //         catch{
    //             Console.WriteLine("You can't go that way");
    //             return currentlocation;}
    //         break;

    //         case "e":
    //         try{
    //             newLocation = currentlocation.East;
    //             floor = newLocation.GetFloor();}
    //         catch{
    //             Console.WriteLine("You can't go that way");
    //             return currentlocation;}
    //         break;

    //         case "w":
    //         try{
    //             newLocation = currentlocation.West;
    //             floor = newLocation.GetFloor();}
    //         catch{
    //             Console.WriteLine("You can't go that way");
    //             return currentlocation;}
    //         break;

    //         case "ne":
    //         try{
    //             newLocation = currentlocation.NorthEast;
    //             floor = newLocation.GetFloor();}
    //         catch{
    //             Console.WriteLine("You can't go that way");
    //             return currentlocation;}
    //         break;

    //         case "nw":
    //         try{
    //             newLocation = currentlocation.NorthWest;
    //             floor = newLocation.GetFloor();}
    //         catch{
    //             Console.WriteLine("You can't go that way");
    //             return currentlocation;}
    //         break;

    //         case "se":
    //         try{
    //             newLocation = currentlocation.SouthEast;
    //             floor = newLocation.GetFloor();}
    //         catch{
    //             Console.WriteLine("You can't go that way");
    //             return currentlocation;}
    //         break;

    //         case "sw":
    //         try{
    //             newLocation = currentlocation.SouthWest;
    //             floor = newLocation.GetFloor();}
    //         catch{
    //             Console.WriteLine("You can't go that way");
    //             return currentlocation;}
    //         break;

    //         case "u":
    //         try{
    //             newLocation = currentlocation.Up;
    //             floor = newLocation.GetFloor();}
    //         catch{
    //             Console.WriteLine("You can't go that way");
    //             return currentlocation;}
    //         break;

    //         case "d":
    //         try{
    //             newLocation = currentlocation.Down;
    //             floor = newLocation.GetFloor();}
    //         catch{
    //             Console.WriteLine("You can't go that way");
    //             return currentlocation;}
    //         break;

    //         case "q":
    //         return currentlocation;

    //         default:
    //         Console.WriteLine("Invalid Direction");
    //         return currentlocation;
    //     }

    //     if(floor == 0){
    //         foreach(Location location in _basement){
    //             if(newLocation.GetName() == location.GetName()){
    //                 location.Visited = true;
    //                 return location;
    //             }
    //         }
    //         Console.WriteLine("unidentifiable error");
    //         return newLocation;
    //     }
    //     else if(floor == 1){
    //         foreach(Location location in _groundFloor){

    //             if(newLocation.GetName() == location.GetName()){
    //                 location.Visited = true;
    //                 return location;
    //             }
    //         }
    //         Console.WriteLine("unidentifiable error");
    //         return newLocation;
    //     }
    //     else if(floor == 2){
    //         foreach(Location location in _secondFloor){
    //             if(newLocation.GetName() == location.GetName()){
    //                 location.Visited = true;
    //                 return location;
    //             }
    //         }
    //         Console.WriteLine("unidentifiable error");
    //         return newLocation;
    //     }
    //     else{
    //         Console.WriteLine("Invalid Floor");
    //         return newLocation;
    //     }
    // }
    public List<string> UpdateSecondFloorMap()
    {
        List<string> map = new List<string>();
        string mapLine = "";

        // Line 1
        if(_library.Visited){mapLine += "               _________________________________               ";}
        else{mapLine += "                                                               ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 2-3
        if(_library.Visited){mapLine += "               |                               |               ";}
        else{mapLine += "                                                               ";}
        map.Add(mapLine);
        map.Add(mapLine);
        mapLine = "";

        // Line 4
        if(_library.Visited){mapLine += "               |            Library            |               ";}
        else{mapLine += "                                                               ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 5
        if(_library.Visited){mapLine += "               |                               |               ";}
        else{mapLine += "                                                               ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 6
        if(_arcanum.Visited){mapLine += "_______________";}
        else{mapLine += "               ";}
        if(_library.Visited){mapLine += "|";}
        else if(_arcanum.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_arcanum.Visited || _library.Visited){mapLine += "____";}
        else{mapLine += "    ";}
        if(_arcanum.Visited || _library.Visited || _observatory.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_observatory.Visited || _library.Visited){mapLine += "__________O__________";}
        else{mapLine += "                     ";}
        if(_alchemyLab.Visited || _library.Visited || _observatory.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_alchemyLab.Visited || _library.Visited){mapLine += "____";}
        else{mapLine += "    ";}
        if(_library.Visited){mapLine += "|";}
        else if(_alchemyLab.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_alchemyLab.Visited){mapLine += "_______________";}
        else{mapLine += "               ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 7-9
        if(_arcanum.Visited){mapLine += "|                   ";}
        else{mapLine += "                    ";}
        if(_arcanum.Visited || _observatory.Visited){mapLine += "|                     ";}
        else{mapLine += "                      ";}
        if(_alchemyLab.Visited || _observatory.Visited){mapLine += "|                   ";}
        else{mapLine += "                    ";}
        if(_alchemyLab.Visited){mapLine += "|";}
        else{mapLine += " ";}
        map.Add(mapLine);
        map.Add(mapLine);
        map.Add(mapLine);
        mapLine = "";

        // Line 10
        if(_arcanum.Visited){mapLine += "|      Arcanum      ";}
        else{mapLine += "                    ";}
        if(_arcanum.Visited || _observatory.Visited){mapLine += "O     ";}
        else{mapLine += "      ";}
        if(_observatory.Visited){mapLine += "Observarory";}
        else{mapLine += "           ";}
        if(_alchemyLab.Visited || _observatory.Visited){mapLine += "     O    ";}
        else{mapLine += "          ";}
        if(_alchemyLab.Visited){mapLine += "Alchemy Lab    |";}
        else{mapLine += "                ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 11-12
        if(_arcanum.Visited){mapLine += "|                   ";}
        else{mapLine += "                    ";}
        if(_arcanum.Visited || _observatory.Visited){mapLine += "|                     ";}
        else{mapLine += "                      ";}
        if(_alchemyLab.Visited || _observatory.Visited){mapLine += "|                   ";}
        else{mapLine += "                    ";}
        if(_alchemyLab.Visited){mapLine += "|";}
        else{mapLine += " ";}
        map.Add(mapLine);
        map.Add(mapLine);
        mapLine = "";

        // Line 13
        if(_arcanum.Visited){mapLine += "|=|                 ";}
        else{mapLine += "                    ";}
        if(_arcanum.Visited || _observatory.Visited){mapLine += "|                     ";}
        else{mapLine += "                      ";}
        if(_alchemyLab.Visited || _observatory.Visited){mapLine += "|                 ";}
        else{mapLine += "                  ";}
        if(_alchemyLab.Visited){mapLine += "|=|";}
        else{mapLine += "   ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 14
        if(_arcanum.Visited){mapLine += "|=|_______";}
        else{mapLine += "          ";}
        if(_arcanum.Visited || _balconyGarden.Visited){mapLine += "__________";}
        else{mapLine += "          ";}
        if(_arcanum.Visited || _observatory.Visited){mapLine += "|";}
        else if(_balconyGarden.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_balconyGarden.Visited || _observatory.Visited){mapLine += "__________O__________";}
        else{mapLine += "                     ";}
        if(_alchemyLab.Visited || _observatory.Visited){mapLine += "|";}
        else if(_balconyGarden.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_alchemyLab.Visited || _balconyGarden.Visited){mapLine += "__________";}
        else{mapLine += "          ";}
        if(_alchemyLab.Visited){mapLine += "_______|=|";}
        else{mapLine += "          ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 15-16
        if(_balconyGarden.Visited){mapLine += "          |                                         |          ";}
        else{mapLine += "                                                               ";}
        map.Add(mapLine);
        map.Add(mapLine);
        mapLine = "";

        // Line 17
        if(_balconyGarden.Visited){mapLine += "          |              Balcony Garden             |          ";}
        else{mapLine += "                                                               ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 18
        if(_balconyGarden.Visited){mapLine += "          |_________________________________________|          ";}
        else{mapLine += "                                                               ";}
        map.Add(mapLine);
        mapLine = "";

        return map;
    }
    public List<string> UpdateGroundFloorMap()
    {
        List<string> map = new List<string>();
        string mapLine = "";

        // Line 1
        if(_frontEntrance.Visited){mapLine += "    __________________                   ";}
        else{mapLine += "                                         ";}
        if(_servantQuarters.Visited){mapLine += "__________________    ";}
        else{mapLine += "                      ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 2
        if(_frontEntrance.Visited){mapLine += "    | Front Entrance |                   ";}
        else{mapLine += "                                         ";}
        if(_servantQuarters.Visited){mapLine += "|Servant Quarters|    ";}
        else{mapLine += "                      ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 3
        if(_frontEntrance.Visited){mapLine += "    |                |                   ";}
        else{mapLine += "                                         ";}
        if(_servantQuarters.Visited){mapLine += "|                |    ";}
        else{mapLine += "                      ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 4
        if(_frontEntrance.Visited){mapLine += "    |                O                   ";}
        else{mapLine += "                                         ";}
        if(_servantQuarters.Visited){mapLine += "O                |    ";}
        else{mapLine += "                      ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 5
        if(_frontEntrance.Visited){mapLine += "    |                |                   ";}
        else{mapLine += "                                         ";}
        if(_servantQuarters.Visited){mapLine += "|              |=|    ";}
        else{mapLine += "                      ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 6
        if(_ballRoom.Visited){mapLine += "____";}
        else{mapLine += "    ";}
        if(_frontEntrance.Visited){mapLine += "|_______O________|";}
        else if(_ballRoom.Visited){mapLine += "________O_________";}
        else{mapLine += "                  ";}
        if(_ballRoom.Visited){mapLine += "___";}
        else{mapLine += "   ";}
        if(_ballRoom.Visited || _diningRoom.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_diningRoom.Visited){mapLine += "_____O_____";}
        else{mapLine += "           ";}
        if(_kitchen.Visited || _diningRoom.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_kitchen.Visited){mapLine += "___";}
        else{mapLine += "   ";}
        if(_servantQuarters.Visited){mapLine += "|________O_____|=|";}
        else if(_kitchen.Visited){mapLine += "________O_________";}
        else{mapLine += "                  ";}
        if(_kitchen.Visited){mapLine += "____";}
        else{mapLine += "    ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 7-8
        if(_ballRoom.Visited){mapLine += "|                        ";}
        else{mapLine += "                         ";}
        if(_ballRoom.Visited || _diningRoom.Visited){mapLine += "|         ";}
        else{mapLine += "          ";}
        if(_diningRoom.Visited){mapLine += "|=";}
        else{mapLine += "  ";}
        if(_kitchen.Visited || _diningRoom.Visited){mapLine += "|                        ";}
        else{mapLine += "                         ";}
        if(_kitchen.Visited){mapLine += "|";}
        else{mapLine += " ";}
        map.Add(mapLine);
        map.Add(mapLine);
        mapLine = "";

        // Line 9
        if(_ballRoom.Visited){mapLine += "|       Ball Room        ";}
        else{mapLine += "                         ";}
        if(_ballRoom.Visited || _diningRoom.Visited){mapLine += "O           ";}
        else{mapLine += "            ";}
        if(_kitchen.Visited || _diningRoom.Visited){mapLine += "O         ";}
        else{mapLine += "          ";}
        if(_kitchen.Visited){mapLine += "Kitchen        |";}
        else{mapLine += "                ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 10
        if(_ballRoom.Visited){mapLine += "|                        ";}
        else{mapLine += "                         ";}
        if(_ballRoom.Visited || _diningRoom.Visited){mapLine += "|  ";}
        else{mapLine += "   ";}
        if(_diningRoom.Visited){mapLine += "Dining";}
        else{mapLine += "      ";}
        if(_kitchen.Visited || _diningRoom.Visited){mapLine += "   |                        ";}
        else{mapLine += "                            ";}
        if(_kitchen.Visited){mapLine += "|";}
        else{mapLine += " ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 11
        if(_ballRoom.Visited){mapLine += "|";}
        else if(_westWing.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_ballRoom.Visited || _westWing.Visited){mapLine += "_________O_________";}
        else{mapLine += "                   ";}
        if(_ballRoom.Visited || _westWing.Visited || _hall.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_ballRoom.Visited || _hall.Visited){mapLine += "_O__";}
        else{mapLine += "    ";}
        if(_diningRoom.Visited || _ballRoom.Visited){mapLine += "|";}
        else if(_hall.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_diningRoom.Visited){mapLine += "     Room  ";}
        else{mapLine += "           ";}
        if(_diningRoom.Visited || _kitchen.Visited){mapLine += "|";}
        else if(_hall.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_kitchen.Visited || _hall.Visited){mapLine += "_O__";}
        else{mapLine += "    ";}
        if(_kitchen.Visited || _eastWing.Visited || _hall.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_kitchen.Visited || _eastWing.Visited){mapLine += "_________O_________";}
        else{mapLine += "                   ";}
        if(_kitchen.Visited){mapLine += "|";}
        else if(_eastWing.Visited){mapLine += "_";}
        else{mapLine += " ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 12-14
        if(_westWing.Visited){mapLine += "|                   ";}
        else{mapLine += "                    ";}
        if(_westWing.Visited || _hall.Visited){mapLine += "|    ";}
        else{mapLine += "     ";}
        if(_diningRoom.Visited || _hall.Visited){mapLine += "|           |    ";}
        else{mapLine += "                 ";}
        if(_eastWing.Visited || _hall.Visited){mapLine += "|                   ";}
        else{mapLine += "                    ";}
        if(_eastWing.Visited){mapLine += "|";}
        else{mapLine += " ";}
        map.Add(mapLine);
        map.Add(mapLine);
        map.Add(mapLine);
        mapLine = "";

        // Line 15
        if(_westWing.Visited){mapLine += "|     West Wing     ";}
        else{mapLine += "                    ";}
        if(_westWing.Visited || _hall.Visited){mapLine += "O    ";}
        else{mapLine += "     ";}
        if(_diningRoom.Visited || _hall.Visited){mapLine += "|           |";}
        else{mapLine += "             ";}
        if(_eastWing.Visited || _hall.Visited){mapLine += "    O     ";}
        else{mapLine += "          ";}
        if(_eastWing.Visited){mapLine += "East Wing     |";}
        else{mapLine += "               ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 16
        if(_westWing.Visited){mapLine += "|                   ";}
        else{mapLine += "                    ";}
        if(_westWing.Visited || _hall.Visited){mapLine += "|    ";}
        else{mapLine += "     ";}
        if(_diningRoom.Visited || _hall.Visited){mapLine += "|           |    ";}
        else{mapLine += "                 ";}
        if(_eastWing.Visited || _hall.Visited){mapLine += "|                   ";}
        else{mapLine += "                    ";}
        if(_eastWing.Visited){mapLine += "|";}
        else{mapLine += " ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 17
        if(_westWing.Visited){mapLine += "|                   ";}
        else{mapLine += "                    ";}
        if(_westWing.Visited || _hall.Visited){mapLine += "|    ";}
        else{mapLine += "     ";}
        if(_diningRoom.Visited || _hall.Visited){mapLine += "|_____O_____|    ";}
        else{mapLine += "                 ";}
        if(_eastWing.Visited || _hall.Visited){mapLine += "|                   ";}
        else{mapLine += "                    ";}
        if(_eastWing.Visited){mapLine += "|";}
        else{mapLine += " ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 18
        if(_westWing.Visited){mapLine += "|=|                 ";}
        else{mapLine += "                    ";}
        if(_westWing.Visited || _hall.Visited){mapLine += "|         ";}
        else{mapLine += "          ";}
        if(_hall.Visited){mapLine += "Hall        ";}
        else{mapLine += "            ";}
        if(_eastWing.Visited || _hall.Visited){mapLine += "|                 ";}
        else{mapLine += "                  ";}
        if(_eastWing.Visited){mapLine += "|=|";}
        else{mapLine += "   ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 19
        if(_westWing.Visited){mapLine += "|=|_______";}
        else{mapLine += "          ";}
        if(_westWing.Visited || _guestRoom1.Visited){mapLine += "__________";}
        else{mapLine += "          ";}
        if(_westWing.Visited || _hall.Visited){mapLine += "|";}
        else if(_guestRoom1.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_guestRoom1.Visited || _hall.Visited){mapLine += "_O_";}
        else{mapLine += "   ";}
        if(_hall.Visited || _guestRoom1.Visited || _guestRoom2.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_guestRoom2.Visited || _hall.Visited){mapLine += "______O______";}
        else{mapLine += "             ";}
        if(_hall.Visited || _guestRoom3.Visited || _guestRoom2.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_guestRoom3.Visited || _hall.Visited){mapLine += "_O_";}
        else{mapLine += "   ";}
        if(_eastWing.Visited || _hall.Visited){mapLine += "|";}
        else if(_guestRoom3.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_eastWing.Visited || _guestRoom3.Visited){mapLine += "__________";}
        else{mapLine += "          ";}
        if(_eastWing.Visited){mapLine += "_______|=|";}
        else{mapLine += "          ";}
        map.Add(mapLine);
        mapLine = "";
        
        // Line 20
        if(_guestRoom1.Visited){mapLine += "          |             ";}
        else{mapLine += "                        ";}
        if(_guestRoom1.Visited || _guestRoom2.Visited){mapLine += "|             ";}
        else{mapLine += "              ";}
        if(_guestRoom2.Visited || _guestRoom3.Visited){mapLine += "|             ";}
        else{mapLine += "              ";}
        if(_guestRoom3.Visited){mapLine += "|          ";}
        else{mapLine += "           ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 21
        if(_guestRoom1.Visited){mapLine += "          |    Guest    ";}
        else{mapLine += "                        ";}
        if(_guestRoom1.Visited || _guestRoom2.Visited){mapLine += "|    ";}
        else{mapLine += "     ";}
        if(_guestRoom2.Visited){mapLine += "Guest    ";}
        else{mapLine += "         ";}
        if(_guestRoom2.Visited || _guestRoom3.Visited){mapLine += "|    ";}
        else{mapLine += "     ";}
        if(_guestRoom3.Visited){mapLine += "Guest    |          ";}
        else{mapLine += "                    ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 22
        if(_guestRoom1.Visited){mapLine += "          |    Room 1   ";}
        else{mapLine += "                        ";}
        if(_guestRoom1.Visited || _guestRoom2.Visited){mapLine += "|    ";}
        else{mapLine += "     ";}
        if(_guestRoom2.Visited){mapLine += "Room 2   ";}
        else{mapLine += "         ";}
        if(_guestRoom2.Visited || _guestRoom3.Visited){mapLine += "|    ";}
        else{mapLine += "     ";}
        if(_guestRoom3.Visited){mapLine += "Room 3   |          ";}
        else{mapLine += "                    ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 23
        if(_guestRoom1.Visited){mapLine += "          |_____________";}
        else{mapLine += "                        ";}
        if(_guestRoom1.Visited || _guestRoom2.Visited){mapLine += "|";}
        else{mapLine += " ";}
        if(_guestRoom2.Visited){mapLine += "_____________";}
        else{mapLine += "             ";}
        if(_guestRoom2.Visited || _guestRoom3.Visited){mapLine += "|";}
        else{mapLine += " ";}
        if(_guestRoom3.Visited){mapLine += "_____________|          ";}
        else{mapLine += "                        ";}
        map.Add(mapLine);
        mapLine = "";

        // Complete map
        return map;
    }
    public List<string> UpdateBasementMap()
    {
        List<string> map = new List<string>();
        string mapLine = "";

        // Line 1
        if(_cellar.Visited){mapLine += "                __________________    ";}
        else{mapLine += "                                      ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 2
        if(_cellar.Visited){mapLine += "                |     Cellar     |    ";}
        else{mapLine += "                                      ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 3-4
        if(_cellar.Visited){mapLine += "                |                |    ";}
        else{mapLine += "                                      ";}
        map.Add(mapLine);
        map.Add(mapLine);
        mapLine = "";

        // Line 5
        if(_cellar.Visited){mapLine += "                |              |=|    ";}
        else{mapLine += "                                      ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 6
        if(_secretChamber.Visited){mapLine += "____________";}
        else{mapLine += "            ";}
        if(_secretChamber.Visited || _storageRoom.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_storageRoom.Visited){mapLine += "___";}
        else{mapLine += "   ";}
        if(_cellar.Visited){mapLine += "|";}
        else if(_storageRoom.Visited){mapLine += "_";}
        else{mapLine += " ";}
        if(_storageRoom.Visited || _cellar.Visited){mapLine += "________O_____";}
        else{mapLine += "              ";}
        if(_cellar.Visited){mapLine += "|=|";}
        else if(_storageRoom.Visited){mapLine += "___";}
        else{mapLine += "   ";}
        if(_storageRoom.Visited){mapLine += "____";}
        else{mapLine += "    ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 7-8
        if(_secretChamber.Visited){mapLine += "|         |=";}
        else{mapLine += "            ";}
        if(_secretChamber.Visited || _storageRoom.Visited){mapLine += "|";}
        else{mapLine += " ";}
        if(_storageRoom.Visited){mapLine += "                        |";}
        else{mapLine += "                         ";}
        map.Add(mapLine);
        map.Add(mapLine);
        mapLine = "";

        // Line 9
        if(_secretChamber.Visited){mapLine += "|           ";}
        else{mapLine += "            ";}
        if(_secretChamber.Visited || _storageRoom.Visited){mapLine += "O";}
        else{mapLine += " ";}
        if(_storageRoom.Visited){mapLine += "       Storage          |";}
        else{mapLine += "                         ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 10
        if(_secretChamber.Visited){mapLine += "| Secret    ";}
        else{mapLine += "            ";}
        if(_secretChamber.Visited || _storageRoom.Visited){mapLine += "|";}
        else{mapLine += " ";}
        if(_storageRoom.Visited){mapLine += "            Room        |";}
        else{mapLine += "                         ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 11
        if(_secretChamber.Visited){mapLine += "|   Chamber ";}
        else{mapLine += "            ";}
        if(_secretChamber.Visited || _storageRoom.Visited){mapLine += "|";}
        else{mapLine += " ";}
        if(_storageRoom.Visited){mapLine += "________________________|";}
        else{mapLine += "                         ";}
        map.Add(mapLine);
        mapLine = "";

        // Line 12-16
        if(_secretChamber.Visited){mapLine += "|           |                         ";}
        else{mapLine += "                                      ";}
        map.Add(mapLine);
        map.Add(mapLine);
        map.Add(mapLine);
        map.Add(mapLine);
        map.Add(mapLine);
        mapLine = "";

        // Line 17
        if(_secretChamber.Visited){mapLine += "|___________|                         ";}
        else{mapLine += "                                      ";}
        map.Add(mapLine);
        mapLine = "";

        return map;
    }
}



/*
"               _________________________________               "1
"               |                               |               "2
"               |                               |               "3
"               |            Library            |               "4
"               |                               |               "5
"_______________|_______________O_______________|_______________"6
"|                   |                     |                   |"7
"|                   |                     |                   |"8
"|                   |                     |                   |"9
"|      Arcanum      O     Observarory     O    Alchemy Lab    |"10
"|                   |                     |                   |"11
"|                   |                     |                   |"12
"|=|                 |                     |                 |=|"13
"|=|_________________|__________O__________|_________________|=|"14
"          |                                         |          "15
"          |                                         |          "16
"          |              Balcony Garden             |          "17
"          |_________________________________________|          "18

"    __________________                   __________________    "1
"    | Front Entrance |                   |Servant Quarters|    "2
"    |                |                   |                |    "3
"    |                O                   O                |    "4
"    |                |                   |              |=|    "5
"____|_______O________|_________O_________|________O_____|=|____"6
"|                        |         |=|                        |"7
"|                        |         |=|                        |"8
"|       Ball Room        O           O         Kitchen        |"9
"|                        |  Dining   |                        |"10
"|_________O___________O__|     Room  |__O___________O_________|"11
"|                   |    |           |    |                   |"12
"|                   |    |           |    |                   |"13
"|                   |    |           |    |                   |"14
"|     West Wing     O    |           |    O     East Wing     |"15
"|                   |    |           |    |                   |"16
"|                   |    |_____O_____|    |                   |"17
"|=|                 |         Hall        |                 |=|"18
"|=|_________________|_O________O________O_|_________________|=|"19
"          |             |             |             |          "20
"          |    Guest    |    Guest    |    Guest    |          "21
"          |    Room 1   |    Room 2   |    Room 3   |          "22
"          |_____________|_____________|_____________|          "23

"                __________________    "1
"                |     Cellar     |    "2
"                |                |    "3
"                |                |    "4
"                |              |=|    "5
"________________|________O_____|=|____"6
"|         |=|                        |"7
"|         |=|                        |"8
"|           O       Storage          |"9
"| Secret    |            Room        |"10
"|   Chamber |________________________|"11
"|           |                         "12
"|           |                         "13
"|           |                         "14
"|           |                         "15
"|           |                         "16
"|___________|                         "17
*/