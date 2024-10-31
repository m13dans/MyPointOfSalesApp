using ErrorOr;
using Microsoft.EntityFrameworkCore;
using MyPointOfSales.Application.Features.Items;
using MyPointOfSales.Domain.Items;
using MyPointOfSales.Infrastructure.DataContext;

namespace MyPointOfSales.Infrastructure.Features.Items;

public class ItemRepository(AppDbContext dbContext) : IItemRepository
{

    public async Task<List<Item>> GetItems()
    {
        var result = await dbContext.Items.ToListAsync();
        return result;
    }
    public async Task<ErrorOr<Item>> CreateItem(Item item)
    {
        await dbContext.Items.AddAsync(item);

        var rowAffected = await dbContext.SaveChangesAsync();

        if (rowAffected <= 0)
            return Error.Validation("Item.Validation", "Tidak dapat menambahkan item");

        return item;
    }

    public async Task<ErrorOr<Item>> UpdateItem(Item item)
    {
        var result = dbContext.Items.Update(item);
        await dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<ErrorOr<Item>> DeleteItem(int id)
    {
        var item = await dbContext.Items.SingleOrDefaultAsync(x => x.Id == id);

        if (item is null)
            return Error.NotFound("Item.NotFound", $"Item dengan id {id} tidak dapat ditemukan.");

        var result = dbContext.Items.Remove(item);

        await dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<ErrorOr<Item>> GetItemById(int id)
    {
        var result = await dbContext.Items.SingleOrDefaultAsync(x => x.Id == id);
        if (result is null)
            return Error.NotFound("Item.NotFound", $"Item dengan id {id} tidak dapat ditemukan.");

        return result;
    }
}
