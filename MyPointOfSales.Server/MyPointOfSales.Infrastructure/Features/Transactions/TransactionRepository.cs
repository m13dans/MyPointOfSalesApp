using ErrorOr;
using Microsoft.EntityFrameworkCore;
using MyPointOfSales.Application.Features.Reports;
using MyPointOfSales.Application.Features.Transactions;
using MyPointOfSales.Domain.Transactions;
using MyPointOfSales.Infrastructure.DataContext;

namespace MyPointOfSales.Infrastructure.Features.Transactions;

public class TransactionRepository(AppDbContext dbContext) : ITransactionRepository
{
    public async Task<List<Transaction>> GetTransaction()
    {
        var result = await dbContext.Transactions
            .AsNoTracking()
            .ToListAsync();

        return result;
    }

    public async Task<ErrorOr<Transaction>> PostTransaction(PostTransactionRequest request)
    {
        var item = await dbContext.Items.SingleOrDefaultAsync(x => x.Id == request.ItemId);
        if (item is null)
            return Error.NotFound(
                "Item.NotFound",
                $"Item dengan id {request.ItemId} tidak dapat ditemukan.");

        if (item.StokAwal < request.JumlahItem)
            return Error.Validation(
                code: "Transaction.Validation",
                description: "Jumlah item yang akan dijual lebih dari stok");

        item.StokAwal -= request.JumlahItem;
        Transaction transaction = new()
        {
            ItemId = request.ItemId,
            JumlahItemDiJual = request.JumlahItem,
            SisaItem = item.StokAwal,
            Kategori = item.Kategori,
            Harga = item.Harga,
            TotalHarga = item.Harga * request.JumlahItem,
            TanggalTransaksi = DateOnly.FromDateTime(DateTime.Now)
        };
        await dbContext.Transactions.AddAsync(transaction);

        dbContext.Items.Update(item);

        await dbContext.SaveChangesAsync();
        return transaction;
    }
}

public static class ProductListDtoSort
{
    public static IQueryable<Transaction> OrderTransactionBy(
        this IQueryable<Transaction> transactions,
        QueryOption query) =>

        query.OrderOption switch
        {
            OrderOption.TanggalTransaksi => transactions.OrderByDescending(x => x.TanggalTransaksi),
            OrderOption.TotalTransaksi => transactions.OrderByDescending(x => x.TotalHarga),
            _ => transactions.OrderByDescending(x => x.Id)
        };
}
