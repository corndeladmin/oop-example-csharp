using OopExample.Readers;

namespace OopExample;

class Program
{
    static void Main(string[] args)
    {
        var path = args[0];

        var reader = new EnglishCsvReader();
        reader.ReadFile(path);
        reader.PrintSummary();
    }
}
