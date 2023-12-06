using OopExample.Readers.FileReaders;
using OopExample.Readers.SummaryPrinters;

namespace OopExample.Readers;

public class FrenchJsonReader : Reader
{
    public FrenchJsonReader() : base(new JsonReader(), new FrenchSummariser()) { }
}
