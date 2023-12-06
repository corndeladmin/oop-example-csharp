using OopExample.Models;

namespace OopExample.Readers.FileReaders;

public interface ICanReadFile
{
    public List<Transaction> ReadFile(string path);
}
