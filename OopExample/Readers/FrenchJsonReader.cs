using Newtonsoft.Json;
using OopExample.Models;

namespace OopExample.Readers;

public class FrenchJsonReader : FrenchReader
{
    public override void ReadFile(string path)
    {
        using (var sr = new StreamReader(path))
        {
            var file = sr.ReadToEnd();
            var jsonTransactions = JsonConvert.DeserializeObject<List<JsonTransaction>>(file);
            if (jsonTransactions == null)
            {
                throw new FormatException("Impossible d'analyser le fichier au format JSON");
            }
            transactions = jsonTransactions.Select(t => t.ToTransaction()).ToList();
        }
    }
}
