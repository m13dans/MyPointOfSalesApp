using ErrorOr;
using Microsoft.AspNetCore.Http;
using MyPointOfSales.Domain.Items;

namespace MyPointOfSales.Application.Features.Items;
public class ItemServices(IItemRepository repo)
{
    public async Task<List<Item>> GetItems()
    {
        List<Item> items = await repo.GetItems();
        return items;
    }
    public async Task<ErrorOr<Item>> GetItemById(int id)
    {
        ErrorOr<Item> item = await repo.GetItemById(id);
        return item;
    }

    public async Task<ErrorOr<Item>> CreateItem(IImageService imageService,
        CreateItemRequest request)
    {
        string imageUrl = await imageService.SaveImage(request.Gambar);

        Item item = request.ToEntity(imageUrl);

        ErrorOr<Item> result = await repo.CreateItem(item);
        return result;
    }

    public async Task<ErrorOr<Item>> UpdateItem(UpdateItemRequest request, IImageService imageService)
    {
        ErrorOr<Item> item = await repo.GetItemById(request.Id);

        if (item.IsError)
            return item;

        Item itemEntity = request.ToEntity(item.Value);

        if (request.Gambar is not null)
        {
            string updateImageUrl = await imageService.UpdateImage(itemEntity.UrlGambar, request.Gambar);
            itemEntity.UrlGambar = updateImageUrl;
        }

        ErrorOr<Item> updateResult = await repo.UpdateItem(itemEntity);
        return updateResult;
    }

    public async Task<ErrorOr<Item>> DeleteItem(int id)
    {
        ErrorOr<Item> result = await repo.DeleteItem(id);
        return result;
    }

}
