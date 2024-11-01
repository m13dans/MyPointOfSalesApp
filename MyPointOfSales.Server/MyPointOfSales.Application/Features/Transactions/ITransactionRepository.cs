using ErrorOr;
using MyPointOfSales.Application.Features.Reports;
using MyPointOfSales.Domain.Transactions;

namespace MyPointOfSales.Application.Features.Transactions;

public interface ITransactionRepository
{
    public Task<List<Transaction>> GetTransaction();
    public Task<ErrorOr<Transaction>> PostTransaction(PostTransactionRequest command);
}
