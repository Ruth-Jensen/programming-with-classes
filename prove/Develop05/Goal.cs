public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _basePoints;
    
    public Goal() { }
    public string GetName() {return _name;}
    public void SetParentInfo(string name, string description, int basePoints)
    {
        _name = name;
        _description = description;
        _basePoints = basePoints;
    }

    public virtual int GetBasePoints() {return _basePoints;}
    public virtual void GetUserInfo()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        _basePoints = int.Parse(Console.ReadLine());
        Console.WriteLine("--------------------------------------");
        Thread.Sleep(1000);
    }
  
    public abstract void PrintGoal ();
    public abstract void UpdateGoal (); 
    public abstract int GetPoints();
    public abstract string FileText ();

}