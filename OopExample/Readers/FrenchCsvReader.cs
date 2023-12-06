using System.Globalization;
using OopExample.Models;

namespace OopExample.Readers;

public class FrenchCsvReader : Reader
{
    private List<Transaction>? transactions;

    public override void ReadFile(string path)
    {
        transactions = new List<Transaction>();

        using (var sr = new StreamReader(path))
        {
            // First line is headers, which we don't need
            sr.ReadLine();

            int lineNumber = 2;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine()!;
                string[] cols = line.Split(",");

                DateOnly date;
                decimal amount;

                try
                {
                    date = DateOnly.Parse(cols[0]);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Erreur lors de l'analyse de la ligne {lineNumber}: impossible d'analyser {cols[0]} comme DateOnly");
                    throw ex;
                }

                try
                {
                    amount = decimal.Parse(cols[4]);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Erreur lors de l'analyse de la ligne {lineNumber}: impossible d'analyser {cols[4]} sous forme décimale");
                    throw ex;
                }

                Transaction transaction = new Transaction
                {
                    Date = date,
                    From = cols[1],
                    To = cols[2],
                    Narrative = cols[3],
                    Amount = amount
                };

                transactions.Add(transaction);
                lineNumber++;
            }
        }
    }

    public override void PrintSummary()
    {
        if (transactions == null)
        {
            throw new NullReferenceException("Impossible d'imprimer le résumé avant de lire un fichier");
        }

        var balances = new Dictionary<string, decimal>();
        foreach (var transaction in transactions)
        {
            // Check for any null strings
            if (transaction.From == null || transaction.To == null || transaction.Narrative == null)
            {
                throw new NullReferenceException("Tentative de lecture d'une transaction contenant des chaînes nulles");
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
            var balanceString = balance.ToString("F2", CultureInfo.CreateSpecificCulture("fr-FR"));
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            if (balance >= 0) {
                Console.WriteLine($"{account} a {balanceString} €, un montant positif");
            }
            else
            {
                Console.WriteLine($"{account} a {balanceString} €, un montant négatif (endetté !)");
            }
        }
    }
}
