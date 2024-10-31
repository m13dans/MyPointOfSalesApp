using Microsoft.AspNetCore.Http;

namespace MyPointOfSales.Application.Features.Items;

public record CreateItemRequest
{
    public required string NamaBarang { get; set; }
    public required decimal Harga { get; set; }
    public required int StokAwal { get; set; }

    public required string Kategori { get; set; }
    public required IFormFile Gambar { get; set; }
}



public record CreateItemResponse
{
    public int Id { get; set; }
    public required string NamaBarang { get; set; }
    public string? UrlGambar { get; set; }
}


public record ItemDTO
{
    public required string NamaBarang { get; set; }
    public required decimal Harga { get; set; }
    public required int StokAwal { get; set; }
    public required string Kategori { get; set; }
    public byte[]? Gambar { get; set; }
    public string? AbsoluteUrlGambar { get; set; }
    public string? HostUrlGambar { get; set; }
}

public record UpdateItemRequest
{
    public int Id { get; set; }
    public required string NamaBarang { get; set; }
    public required decimal Harga { get; set; }
    public required int StokAwal { get; set; }

    public required string Kategori { get; set; }
    public IFormFile? Gambar { get; set; }
}