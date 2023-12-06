using OopExample.Readers.FileReaders;
using OopExample.Readers.SummaryPrinters;

namespace OopExample.Readers;

public class PortugueseCsvReader : Reader
{
    public PortugueseCsvReader() : base(new CsvReader(), new PortugueseSummariser()) { }
}
