using OopExample.Models;

namespace OopExample.Readers.FileReaders;

public class CsvReader
{
    public List<Transaction> ReadFile(string path)
    {
        var transactions = new List<Transaction>();

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
                    Console.WriteLine($"Error parsing line {lineNumber}: cannot parse {cols[0]} as DateOnly");
                    throw ex;
                }

                try
                {
                    amount = decimal.Parse(cols[4]);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error parsing line {lineNumber}: cannot parse {cols[4]} as a decimal");
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

        return transactions;
    }
}
