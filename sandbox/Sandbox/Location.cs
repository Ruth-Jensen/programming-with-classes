public class Location
{
    public string _name = "";
    public string _discription = "";
    public Location _northOfHere;
    public Location _southOfHere;
    public Location _eastOfHere;
    public Location _westOfHere;
    public Location _above;
    public Location _below;
    
    public Location()
    {

    }

    public Location changeLocations(Location currentLocation, string direction)
    {
        if (direction == "up")
        {
            if (currentLocation._above != null) {currentLocation = currentLocation._above;}
            else {Console.WriteLine("There is nothing above of here");}
        }
        else if (direction == "down")
        {
            if (currentLocation._below != null) {currentLocation = currentLocation._below;}
            else {Console.WriteLine("There is nothing below of here");}
        }
        else if (direction == "north")
        {
            if (currentLocation._northOfHere != null) {currentLocation = currentLocation._northOfHere;}
            else {Console.WriteLine("There is nothing north of here");}
        }
        else if (direction == "south")
        {
            if (currentLocation._southOfHere != null) {currentLocation = currentLocation._southOfHere;}
            else {Console.WriteLine("There is nothing south of here");}
        }
        else if (direction == "west")
        {
            if (currentLocation._westOfHere != null) {currentLocation = currentLocation._westOfHere;}
            else {Console.WriteLine("There is nothing west of here");}
        }
        else if (direction == "east")
        {
            if (currentLocation._eastOfHere != null) {currentLocation = currentLocation._eastOfHere;}
            else {Console.WriteLine("There is nothing east of here");}
        }
        else{Console.WriteLine("Error");}

        return currentLocation;
    }
}