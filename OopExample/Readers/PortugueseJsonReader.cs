using OopExample.Readers.FileReaders;
using OopExample.Readers.SummaryPrinters;

namespace OopExample.Readers;

public class PortugueseJsonReader : Reader
{
    public PortugueseJsonReader() : base(new JsonReader(), new PortugueseSummariser()) { }
}
