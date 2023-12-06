using OopExample.Readers;

namespace OopExample;

class Program
{
    static void Main(string[] args)
    {
        var path = args[0];

        var readers = new List<Reader>
        {
            new EnglishCsvReader(),
            new EnglishJsonReader(),
            new FrenchCsvReader(),
            new FrenchJsonReader(),
            new PortugueseCsvReader(),
            new PortugueseJsonReader(),
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
