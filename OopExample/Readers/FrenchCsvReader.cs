using OopExample.Readers.FileReaders;
using OopExample.Readers.SummaryPrinters;

namespace OopExample.Readers;

public class FrenchCsvReader : Reader
{
    public FrenchCsvReader() : base(new CsvReader(), new FrenchSummariser()) { }
}
