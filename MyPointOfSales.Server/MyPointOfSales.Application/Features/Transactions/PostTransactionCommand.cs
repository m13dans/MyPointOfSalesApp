namespace MyPointOfSales.Application.Features.Transactions;

public class PostTransactionRequest
{
    public required int ItemId { get; set; }
    public required int JumlahItem { get; set; }
}