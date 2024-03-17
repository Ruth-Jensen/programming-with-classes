public class InfoTracker
{
    private List<Goal> _AllGoals = new List<Goal>();
    private List<Goal> _savedGoals = new List<Goal>();
    private List<Goal> _unsavedGoals = new List<Goal>();

    public InfoTracker() { }

    public void UpdateAllGoals()
    {
        _AllGoals = new List<Goal>();
        foreach (Goal goal in _savedGoals) { _AllGoals.Add(goal); }
        foreach (Goal goal in _unsavedGoals) { _AllGoals.Add(goal); }
    }
    public int GetTotalPoints()
    {
        UpdateAllGoals();
        int _totalPoints = 0;
        foreach (Goal goal in _AllGoals) { _totalPoints += goal.GetPoints(); }
        return _totalPoints;
    }
    public void AddGoal(Goal goal)
    {
        _unsavedGoals.Add(goal);
        UpdateAllGoals();
    }
    public List<Goal> GetGoals()
    {
        UpdateAllGoals();
        return _AllGoals;
    }
    public void RecordEvent(int Index)
    {
        UpdateAllGoals();
        Goal UndatedGoal = _AllGoals[Index];
        UndatedGoal.UpdateGoal();
    }
    public void SaveGoals(string filePath)
    {
        if(_savedGoals.Count == 0) { LoadGoals(filePath); }
        foreach (Goal goal in _unsavedGoals) { _savedGoals.Add(goal); }
        _unsavedGoals = new List<Goal>();
        UpdateAllGoals();
        using (StreamWriter streamWriter = new StreamWriter(filePath, false))
        {
            foreach (Goal goal in _AllGoals)
            {
                streamWriter.WriteLine(goal.FileText());
            }
        }
    }
    public void LoadGoals(string filePath)
    {
        List<Goal> loadedGoals = new List<Goal>();

        if (File.Exists(filePath))
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] parts = line.Split('*');
                    if (parts.Length > 1)
                    {
                        string goalType = parts[0];
                        string[] goalInfo = parts[1].Split(',');
                        if (goalType == "SimpleGoal")
                        {
                            SimpleGoal simpleGoal = new SimpleGoal();
                            simpleGoal.SetInfo(goalInfo[0], goalInfo[1], int.Parse(goalInfo[2]), bool.Parse(goalInfo[3]));
                            loadedGoals.Add(simpleGoal);
                        }
                        else if (goalType == "EternalGoal")
                        {
                            EternalGoal eternalGoal = new EternalGoal();
                            eternalGoal.SetInfo(goalInfo[0], goalInfo[1], int.Parse(goalInfo[2]), int.Parse(goalInfo[3]));
                            loadedGoals.Add(eternalGoal);
                        }
                        else if (goalType == "ChecklistGoal")
                        {
                            ChecklistGoal checklistGoal = new ChecklistGoal();
                            checklistGoal.SetInfo(goalInfo[0], goalInfo[1], int.Parse(goalInfo[2]), int.Parse(goalInfo[3]), int.Parse(goalInfo[4]), int.Parse(goalInfo[5]));
                            loadedGoals.Add(checklistGoal);
                        }
                        else
                        {
                            Console.WriteLine("Not a valid goal.");
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
        _savedGoals = loadedGoals;
        UpdateAllGoals();
    }
}