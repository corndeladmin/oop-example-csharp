namespace OopExample.Models;

public class Transaction
{
    public DateOnly Date { get; init; }
    public string? From { get; init; }
    public string? To { get; init; }
    public string? Narrative { get; init; }
    public decimal Amount { get; init; }
}
