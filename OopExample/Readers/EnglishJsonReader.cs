using Newtonsoft.Json;
using OopExample.Models;

namespace OopExample.Readers;

public class EnglishJsonReader : Reader
{
    private List<Transaction>? transactions;

    public override void ReadFile(string path)
    {
        using (var sr = new StreamReader(path))
        {
            var file = sr.ReadToEnd();
            var jsonTransactions = JsonConvert.DeserializeObject<List<JsonTransaction>>(file);
            if (jsonTransactions == null)
            {
                throw new FormatException("Unable to parse file as JSON");
            }
            transactions = jsonTransactions.Select(t => t.ToTransaction()).ToList();
        }
    }

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
