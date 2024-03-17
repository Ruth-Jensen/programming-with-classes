public class Menu
{
    public string DisplayMainMenu(InfoTracker infoTracker, bool isInvalidInput)
    {
        if(isInvalidInput)
        {
            Console.WriteLine("Invalid input. Please type a number between 1 and 6.");
        }
        else { Console.WriteLine("");}
        Console.WriteLine($"You have {infoTracker.GetTotalPoints()} Points");
        Console.WriteLine("");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("     1. Create New Goal");
        Console.WriteLine("     2. List Goals");
        Console.WriteLine("     3. Save Goals");
        Console.WriteLine("     4. Load Goals");
        Console.WriteLine("     5. Record Event");
        Console.WriteLine("     6. Quit");
        Console.Write("Select a choice from the menu: ");
        return Console.ReadLine(); 
    }

    public string DisplayGoalMenu(InfoTracker infoTracker, bool isInvalidInput)
    {
        if(isInvalidInput)
        {
            Console.WriteLine("Invalid input. Please type a number between 1 and 3.");
        }
        else { Console.WriteLine(""); }
        Console.WriteLine($"You have {infoTracker.GetTotalPoints()} Points");
        Console.WriteLine("");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("     1. Simple Goal");
        Console.WriteLine("     2. Eternal Goal");
        Console.WriteLine("     3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        return Console.ReadLine();
    }

    public void ListGoalsMenu(InfoTracker infoTracker)
    {
        List<Goal> goals = infoTracker.GetGoals();
        foreach (Goal goal in goals) { goal.PrintGoal(); }
        
    }

    public void RecordEventMenu(InfoTracker infoTracker)
    {
        List<Goal> goals = infoTracker.GetGoals();
        if (goals.Count > 0)
        {
            Console.WriteLine("The goals are:");
            int x = 0;
            foreach (Goal goal in goals)
            {
                x++;
                Console.WriteLine($"{x}. {goal.GetName()}");
            }
            Console.Write("Which goal would you like to accomplish? ");
            int Index = int.Parse(Console.ReadLine()) - 1;
            infoTracker.RecordEvent(Index);
            Console.WriteLine($"Congratulations! You have earned {goals[Index].GetBasePoints()} points!");
        }
        else
        {
            Console.WriteLine("There are no goals to record an event for.");
        }
    }
}