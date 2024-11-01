using ErrorOr;
using MyPointOfSales.Application.Features.Reports;
using MyPointOfSales.Domain.Transactions;

namespace MyPointOfSales.Application.Features.Transactions;

public class TransactionService(ITransactionRepository repository)
{
    public async Task<List<Transaction>> GetTransaction()
    {
        var result = await repository.GetTransaction();
        return result;
    }
    public async Task<ErrorOr<Transaction>> PostTransaction(PostTransactionRequest request)
    {
        var result = await repository.PostTransaction(request);
        return result;
    }
}
