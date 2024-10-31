using ErrorOr;
using Microsoft.AspNetCore.Http;
using MyPointOfSales.Domain.Items;

namespace MyPointOfSales.Application.Features.Items;
public class ItemServices(IItemRepository repo)
{
    public async Task<List<Item>> GetItems()
    {
        var items = await repo.GetItems();
        return items;
    }
    public async Task<ErrorOr<Item>> GetItemById(int id)
    {
        var item = await repo.GetItemById(id);
        return item;
    }

    public async Task<ErrorOr<Item>> CreateItem(IImageService imageService,
        CreateItemRequest request)
    {
        var imageUrl = await imageService.SaveImage(request.Gambar);

        Item item = request.ToEntity(imageUrl);

        var result = await repo.CreateItem(item);
        return result;
    }

    public async Task<ErrorOr<Item>> UpdateItem(UpdateItemRequest request, IImageService imageService)
    {
        var item = await repo.GetItemById(request.Id);

        if (item.IsError)
            return Error.NotFound("Item.NotFound", $"Item with id {request.Id} cannot be found");

        Item itemEntity = request.ToEntity(item.Value);

        if (request.Gambar is not null)
        {
            var updateImageUrl = await imageService.UpdateImage(itemEntity.UrlGambar, request.Gambar);
            itemEntity.UrlGambar = updateImageUrl;
        }

        var updateResult = await repo.UpdateItem(itemEntity);
        return updateResult;

    }

    public async Task<ErrorOr<Item>> DeleteItem(int id)
    {
        var result = await repo.DeleteItem(id);
        return result;
    }

}
