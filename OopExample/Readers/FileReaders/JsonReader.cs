using Newtonsoft.Json;
using OopExample.Models;

namespace OopExample.Readers.FileReaders;

public class JsonReader : ICanReadFile
{
    public List<Transaction> ReadFile(string path)
    {
        using (var sr = new StreamReader(path))
        {
            var file = sr.ReadToEnd();
            var jsonTransactions = JsonConvert.DeserializeObject<List<JsonTransaction>>(file);
            if (jsonTransactions == null)
            {
                throw new FormatException("Unable to parse file as JSON");
            }
            var transactions = jsonTransactions.Select(t => t.ToTransaction()).ToList();
            return transactions;
        }
    }
}
