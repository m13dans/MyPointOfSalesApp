using ErrorOr;
using MyPointOfSales.Domain.Items;

namespace MyPointOfSales.Application.Features.Items;

public interface IItemRepository
{
    public Task<List<Item>> GetItems();
    public Task<ErrorOr<Item>> GetItemById(int id);
    public Task<ErrorOr<Item>> CreateItem(Item item);
    public Task<ErrorOr<Item>> UpdateItem(Item item);
    public Task<ErrorOr<Item>> DeleteItem(int id);

}
