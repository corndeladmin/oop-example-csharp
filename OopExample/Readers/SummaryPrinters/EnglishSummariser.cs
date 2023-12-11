using OopExample.Models;

namespace OopExample.Readers.SummaryPrinters;

public class EnglishSummariser : ICanPrintSummary
{
    public void PrintSummary(List<Transaction> transactions)
    {
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
