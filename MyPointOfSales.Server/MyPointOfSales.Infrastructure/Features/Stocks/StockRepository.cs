using Microsoft.EntityFrameworkCore;
using MyPointOfSales.Application.Features.Stocks;
using MyPointOfSales.Domain.Stocks;
using MyPointOfSales.Infrastructure.DataContext;

namespace MyPointOfSales.Infrastructure.Features.Stocks;

public class StockRepository(AppDbContext dbContext) : IStockRepository
{
    public async Task<List<Stock>> GetStock()
    {
        var item = dbContext.Items.Select(x => new Stock()
        {
            NamaBarang = x.NamaBarang,
            Harga = x.Harga,
            JumlahStokSaatIni = x.StokAwal,
            Kategori = x.Kategori
        });

        return await item.ToListAsync();
    }
}
