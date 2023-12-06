namespace OopExample.Readers;

public abstract class Reader
{
    public abstract void ReadFile(string path);

    public abstract void PrintSummary();
}
