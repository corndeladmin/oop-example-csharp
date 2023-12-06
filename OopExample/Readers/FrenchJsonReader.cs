using System.Globalization;
using Newtonsoft.Json;
using OopExample.Models;

namespace OopExample.Readers;

public class FrenchJsonReader : JsonReader
{
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
