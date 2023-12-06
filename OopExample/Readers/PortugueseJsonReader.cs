using System.Globalization;
using Newtonsoft.Json;
using OopExample.Models;

namespace OopExample.Readers;

public class PortugueseJsonReader : JsonReader
{
    public override void PrintSummary()
    {
        if (transactions == null)
        {
            throw new NullReferenceException("Não é possível imprimir o resumo antes de ler um arquivo");
        }

        var balances = new Dictionary<string, decimal>();
        foreach (var transaction in transactions)
        {
            // Check for any null strings
            if (transaction.From == null || transaction.To == null || transaction.Narrative == null)
            {
                throw new NullReferenceException("Tentativa de ler a transação que contém strings nulas");
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
            var balanceString = balance.ToString("F2", CultureInfo.CreateSpecificCulture("pt-BR"));
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            if (balance >= 0) {
                Console.WriteLine($"{account} tem R$ {balanceString}, valor positivo");
            }
            else
            {
                Console.WriteLine($"{account} tem R$ {balanceString}, valor negativo (em dívida!)");
            }
        }
    }
}
