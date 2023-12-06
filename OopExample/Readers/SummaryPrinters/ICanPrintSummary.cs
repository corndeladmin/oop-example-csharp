using OopExample.Models;

namespace OopExample.Readers.SummaryPrinters;

public interface ICanPrintSummary
{
    public void PrintSummary(List<Transaction> transactions);
}
