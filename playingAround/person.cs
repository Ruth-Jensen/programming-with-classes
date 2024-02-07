public class Person
{
    private string _title;
    private string _firstName;
    private string _lastName;

    public Person()
    {
    }
    public Person(string firstName)
    {
        _firstName = firstName;
    }
    public Person(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }
    public Person(string firstName, string lastName, string title)
    {
        _title = title;
        _firstName = firstName;
        _lastName = lastName;
    }

    public string GetFirstName() {return _firstName;}
    public void SetFirstName (string firstName) {_firstName = firstName;}

    public string GetInformalSignature()
    {
        return "Thanks, " + _firstName;
    }

    public string GetFormalSignature()
    {
        return "Sincerely, " + GetFullName();
    }

    private string GetFullName()
    {
        return _title + " " + _firstName + " " + _lastName;
    }
}