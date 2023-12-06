using OopExample.Readers;
using OopExample.Readers.FileReaders;
using OopExample.Readers.SummaryPrinters;

namespace OopExample;

class Program
{
    static void Main(string[] args)
    {
        var path = args[0];

        var readers = new List<Reader>
        {
            new Reader(new CsvReader(), new EnglishSummariser()),
            new Reader(new CsvReader(), new FrenchSummariser()),
            new Reader(new CsvReader(), new PortugueseSummariser()),
            new Reader(new JsonReader(), new EnglishSummariser()),
            new Reader(new JsonReader(), new FrenchSummariser()),
            new Reader(new JsonReader(), new PortugueseSummariser()),
        };

        foreach (var reader in readers)
        {
            try
            {
                reader.ReadFile(path);
            }
            catch
            {
                Console.WriteLine("Wrong format");
                continue;
            }

            reader.PrintSummary();
        }
    }
}
