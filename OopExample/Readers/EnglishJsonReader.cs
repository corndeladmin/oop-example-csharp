using OopExample.Readers.FileReaders;
using OopExample.Readers.SummaryPrinters;

namespace OopExample.Readers;

public class EnglishJsonReader : Reader
{
    public EnglishJsonReader() : base(new JsonReader(), new EnglishSummariser()) { }
}
