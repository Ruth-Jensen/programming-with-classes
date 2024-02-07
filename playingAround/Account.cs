public class Account
{
    private List<int> _transactions = new List<int>();

    public void Deposit(int amount)
    {
        _transactions.Add(amount);
    }
}