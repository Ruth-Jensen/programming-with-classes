public abstract class Person
{
    private string _name;
    private string _description;
    private int _baseHealth;
    private int _currentHealth;

    public Person(string name, string description, int baseHealth = 100, int currentHealth = 100)
    {
        _name = name;
        _description = description;
        _baseHealth = baseHealth;
        _currentHealth = currentHealth;
    }

    public string GetName() {return _name;}
    public string GetDescription() {return _description;}
    public int GetBaseHealth() {return _baseHealth;}
    public int GetCurrentHealth() {return _currentHealth;}
    public void Heal(int healAmount) {_currentHealth += healAmount;}

    public abstract void TakeDamage(int damage);
    public abstract void Talk();

    protected void SetBaseHealth(int baseHealth) {_baseHealth = baseHealth;}
    protected void SetCurrentHealth(int currentHealth) {_currentHealth = currentHealth;}
}