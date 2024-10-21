using ErrorOr;
using MyPointOfSales.Application.Features.Reports;
using MyPointOfSales.Domain.Transactions;

namespace MyPointOfSales.Application.Features.Transactions;

public interface ITransactionRepository
{
    public Task<List<Transaction>> GetTransaction();
    public Task<List<Transaction>> GetTransaction(QueryOption query);
    public Task<ErrorOr<Transaction>> PostTransaction(PostTransactionCommand command);
}
