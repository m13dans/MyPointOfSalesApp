using MyPointOfSales.Domain.Stocks;

namespace MyPointOfSales.Application.Features.Stocks;

public class StockService(IStockRepository stockRepository)
{
    public async Task<List<Stock>> GetStocks()
    {
        return await stockRepository.GetStock();
    }
}
