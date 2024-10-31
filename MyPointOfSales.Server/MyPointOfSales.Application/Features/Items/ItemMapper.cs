using MyPointOfSales.Domain.Items;

namespace MyPointOfSales.Application.Features.Items;

public static class ItemMapper
{
    public static Item ToEntity(this CreateItemRequest request, string? imageUrl = null) =>
    new Item
    {
        NamaBarang = request.NamaBarang,
        Harga = request.Harga,
        StokAwal = request.StokAwal,
        Kategori = request.Kategori,
        UrlGambar = imageUrl
    };

    public static Item ToEntity(this UpdateItemRequest request, string? imageUrl = null) =>
    new Item
    {
        NamaBarang = request.NamaBarang,
        Harga = request.Harga,
        StokAwal = request.StokAwal,
        Kategori = request.Kategori,
        UrlGambar = imageUrl
    };
}