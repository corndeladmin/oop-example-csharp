namespace OopExample.Readers;

public abstract class EnglishReader : Reader
{
    public override void PrintSummary()
    {
        if (transactions == null)
        {
            throw new NullReferenceException("Cannot print summary before reading a file");
        }

        var balances = new Dictionary<string, decimal>();
        foreach (var transaction in transactions)
        {
            // Check for any null strings
            if (transaction.From == null || transaction.To == null || transaction.Narrative == null)
            {
                throw new NullReferenceException("Attempted to read transaction which contains null strings");
            }

            // If we haven't seen either of the involved people yet, add them to the dictionary
            if (!balances.ContainsKey(transaction.From))
            {
                balances[transaction.From] = 0;
            }
            if (!balances.ContainsKey(transaction.To))
            {
                balances[transaction.To] = 0;
            }

            // Modify balances
            balances[transaction.From] -= transaction.Amount;
            balances[transaction.To] += transaction.Amount;
        }

        foreach (var account in balances.Keys)
        {
            var balance = balances[account];
            if (balance >= 0) {
                Console.WriteLine($"{account} has £{balance:f2}, a positive amount");
            }
            else
            {
                Console.WriteLine($"{account} has -£{-balance:f2}, a negative amount (in debt!)");
            }
        }
    }
}
