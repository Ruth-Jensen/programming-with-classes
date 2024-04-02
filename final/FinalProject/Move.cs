public class Move : Event
{
    public Move() : base("move") {}
    public (Location, char) ExecuteEvent(Location currentlocation, string dirrection)
    {
        switch (dirrection){
            case "n":
                if (currentlocation.North == null) { return (currentlocation, 'f'); }
                else if (currentlocation.North.Unlocked == false) { return (currentlocation, 'l'); }
                else { return (currentlocation.North, 't'); }

            case "s":
                if (currentlocation.South == null) { return (currentlocation, 'f'); }
                else if (currentlocation.South.Unlocked == false) { return (currentlocation, 'l'); }
                else { return (currentlocation.South, 't'); }

            case "e":
                if (currentlocation.East == null) { return (currentlocation, 'f'); }
                else if (currentlocation.East.Unlocked == false) { return (currentlocation, 'l'); }
                else { return (currentlocation.East, 't'); }

            case "w":
                if (currentlocation.West == null) { return (currentlocation, 'f'); }
                else if (currentlocation.West.Unlocked == false) { return (currentlocation, 'l'); }
                else { return (currentlocation.West, 't'); }

            case "ne":
                if (currentlocation.NorthEast == null) { return (currentlocation, 'f'); }
                else if (currentlocation.NorthEast.Unlocked == false) { return (currentlocation, 'l'); }
                else { return (currentlocation.NorthEast, 't'); }

            case "nw":
                if (currentlocation.NorthWest == null) { return (currentlocation, 'f'); }
                else if (currentlocation.NorthWest.Unlocked == false) { return (currentlocation, 'l'); }
                else { return (currentlocation.NorthWest, 't'); }

            case "se":
                if (currentlocation.SouthEast == null) { return (currentlocation, 'f'); }
                else if (currentlocation.SouthEast.Unlocked == false) { return (currentlocation, 'l'); }
                else { return (currentlocation.SouthEast, 't'); }

            case "sw":
                if (currentlocation.SouthWest == null) { return (currentlocation, 'f'); }
                else if (currentlocation.SouthWest.Unlocked == false) { return (currentlocation, 'l'); }
                else { return (currentlocation.SouthWest, 't'); }

            case "u":
                if (currentlocation.Up == null) { return (currentlocation, 'f'); }
                else if (currentlocation.Up.Unlocked == false) { return (currentlocation, 'l'); }
                else { return (currentlocation.Up, 't'); }

            case "d":
                if (currentlocation.Down == null) { return (currentlocation, 'f'); }
                else if (currentlocation.Down.Unlocked == false) { return (currentlocation, 'l'); }
                else { return (currentlocation.Down, 't'); }

            default:
                return (currentlocation, 'f');
        }
    }
}