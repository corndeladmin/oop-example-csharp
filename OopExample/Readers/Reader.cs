using OopExample.Models;
using OopExample.Readers.FileReaders;
using OopExample.Readers.SummaryPrinters;

namespace OopExample.Readers;

public class Reader
{
    private ICanReadFile fileReader;
    private ICanPrintSummary summaryPrinter;
    private List<Transaction>? transactions;

    public Reader(ICanReadFile fileReader, ICanPrintSummary summaryPrinter)
    {
        this.fileReader = fileReader;
        this.summaryPrinter = summaryPrinter;
    }

    public void ReadFile(string path)
    {
        transactions = fileReader.ReadFile(path);
    }

    public void PrintSummary()
    {
        if (transactions == null)
        {
            throw new ArgumentNullException("Cannot print summary before reading a file");
        }

        summaryPrinter.PrintSummary(transactions);
    }
}
