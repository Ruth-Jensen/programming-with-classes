using System;

class Program
// dotnet new console -o name
// cd name
// code .
{
    static void Main(string[] args)
    {
        Location mainRoom = new Location();
        Location northRoom = new Location();
        Location southRoom = new Location();
        Location eastRoom = new Location();
        Location westRoom = new Location();
        Location attic = new Location();
        Location basment = new Location();

        Location currentRoom = mainRoom;

        mainRoom._above = attic;
        mainRoom._below = basment;
        mainRoom._northOfHere = northRoom;
        mainRoom._southOfHere = southRoom;
        mainRoom._eastOfHere = eastRoom;
        mainRoom._westOfHere = westRoom;

        attic._below = mainRoom;
        basment._above = mainRoom;
        northRoom._southOfHere = mainRoom;
        southRoom._northOfHere = mainRoom;
        eastRoom._westOfHere = mainRoom;
        westRoom._eastOfHere = mainRoom;

        
    }
}