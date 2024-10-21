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
    public async Task<List<Transaction>> GetTransaction(QueryOption query)
    {
        var result = await repository.GetTransaction(query);
        return result;
    }
    public async Task<ErrorOr<Transaction>> PostTransaction(PostTransactionCommand command)
    {
        var result = await repository.PostTransaction(command);
        return result;
    }
}
