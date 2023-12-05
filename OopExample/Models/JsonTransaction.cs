namespace OopExample.Models;

public class JsonTransaction
{
    public DateTime Date { get; init; }
    public string? FromAccount { get; init; }
    public string? ToAccount { get; init; }
    public string? Narrative { get; init; }
    public decimal Amount { get; init; }

    public Transaction ToTransaction()
    {
        return new Transaction
        {
            Date = DateOnly.FromDateTime(Date),
            From = FromAccount,
            To = ToAccount,
            Narrative = Narrative,
            Amount = Amount,
        };
    }
}
