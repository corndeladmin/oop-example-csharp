using OopExample.Models;

namespace OopExample.Readers;

public abstract class Reader
{
    protected List<Transaction>? transactions;

    public abstract void ReadFile(string path);

    public abstract void PrintSummary();
}
