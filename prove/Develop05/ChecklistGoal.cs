public class ChecklistGoal : Goal
{
    private int _timesUntilBonus;
    private int _bonusPoints;
    private int _completed = 0;

    public override int GetBasePoints()
    {
        if (_completed >= _timesUntilBonus) { return _basePoints + _bonusPoints; }
        else { return _basePoints; }
    }

    public override void GetUserInfo()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        _basePoints = int.Parse(Console.ReadLine());
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _timesUntilBonus = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        _bonusPoints = int.Parse(Console.ReadLine());
        Console.WriteLine("--------------------------------------");
        Thread.Sleep(1000);
    }

    public override void PrintGoal()
    {
        if (_completed >= _timesUntilBonus) { Console.WriteLine($"[X] {_name} ({_description}) -- currently completed {_completed}/{_timesUntilBonus}"); }
        else { Console.WriteLine($"[ ] {_name} ({_description}) -- currently completed {_completed}/{_timesUntilBonus}"); }
    }

    public override void UpdateGoal() { _completed++; }

    public override int GetPoints()
    {
        if (_completed >= _timesUntilBonus) { return _basePoints * _completed + _bonusPoints; }
        else { return _basePoints * _completed; }
    }

    public void SetInfo(string name, string description, int basePoints, int bonusPoints, int timesUntilBonus, int completed)
    {
        SetParentInfo(name, description, basePoints);
        _bonusPoints = bonusPoints;
        _timesUntilBonus = timesUntilBonus;
        _completed = completed;
    }

    public override string FileText() { return $"ChecklistGoal*{_name},{_description},{_basePoints},{_bonusPoints},{_timesUntilBonus},{_completed}"; }
}