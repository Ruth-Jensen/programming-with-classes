public class SimpleGoal : Goal
{
    private bool _completed = false;

    public override void PrintGoal()
    {
        if (_completed) { Console.WriteLine($"[X] {_name} ({_description})"); }
        else { Console.WriteLine($"[ ] {_name} ({_description})"); }
    }

    public override void UpdateGoal() { _completed = true; }

    public override int GetPoints()
    {
        if (_completed) { return _basePoints; }
        else { return 0; }
    }

    public void SetInfo(string name, string description, int basePoints, bool completed)
    {
        SetParentInfo(name, description, basePoints);
        _completed = completed;
    }

    public override string FileText()
    {
        return $"SimpleGoal*{_name},{_description},{_basePoints},{_completed}";
    }
}