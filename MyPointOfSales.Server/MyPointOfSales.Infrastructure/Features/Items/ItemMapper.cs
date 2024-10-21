using MyPointOfSales.Application.Features.Items;
using MyPointOfSales.Domain.Items;

namespace MyPointOfSales.Infrastructure.Features.Items;

public class ItemMapper
{
    public static Item Map(ItemDTO itemDTO) =>
        new()
        {
            NamaBarang = itemDTO.NamaBarang,
            Harga = itemDTO.Harga,
            StokAwal = itemDTO.StokAwal,
            Kategori = itemDTO.Kategori,
            UrlGambar = itemDTO.HostUrlGambar
        };
}