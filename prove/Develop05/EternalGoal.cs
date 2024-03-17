public class EternalGoal : Goal
{
    private int _timesCompleted = 0;

    public override void PrintGoal() { Console.WriteLine($"[ ] {_name} ({_description})"); }

    public override void UpdateGoal() { _timesCompleted++; }

    public override int GetPoints() { return _basePoints * _timesCompleted; }

    public void SetInfo(string name, string description, int basePoints, int timesCompleted)
    {
        SetParentInfo(name, description, basePoints);
        _timesCompleted = timesCompleted;
    }

    public override string FileText() { return $"EternalGoal*{_name},{_description},{_basePoints},{_timesCompleted}"; }
}