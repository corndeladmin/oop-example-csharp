using OopExample.Readers.FileReaders;
using OopExample.Readers.SummaryPrinters;

namespace OopExample.Readers;

public class EnglishCsvReader : Reader
{
    public EnglishCsvReader() : base(new CsvReader(), new EnglishSummariser()) { }
}
