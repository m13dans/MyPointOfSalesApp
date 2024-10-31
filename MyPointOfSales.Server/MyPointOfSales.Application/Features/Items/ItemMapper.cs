using MyPointOfSales.Domain.Items;

namespace MyPointOfSales.Application.Features.Items;

public static class ItemMapper
{
    public static Item ToEntity(this CreateItemRequest request, string imageUrl) =>
    new Item
    {
        NamaBarang = request.NamaBarang,
        Harga = request.Harga,
        StokAwal = request.StokAwal,
        Kategori = request.Kategori,
        UrlGambar = imageUrl
    };

    public static Item ToEntity(this UpdateItemRequest request, Item item)
    {
        item.Id = request.Id;
        item.NamaBarang = request.NamaBarang;
        item.Harga = request.Harga;
        item.StokAwal = request.StokAwal;
        item.Kategori = request.Kategori;

        return item;
    }
}