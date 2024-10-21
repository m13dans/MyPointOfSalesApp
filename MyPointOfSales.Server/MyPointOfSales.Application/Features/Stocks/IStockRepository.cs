using MyPointOfSales.Domain.Stocks;

namespace MyPointOfSales.Application.Features.Stocks;

public interface IStockRepository
{
    public Task<List<Stock>> GetStock();
}