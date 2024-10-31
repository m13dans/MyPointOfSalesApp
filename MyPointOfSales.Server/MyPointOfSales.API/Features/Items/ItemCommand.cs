namespace MyPointOfSales.API.Features.Items;

public record UpdateItemCommand
{
    public required string NamaBarang { get; set; }
    public required decimal Harga { get; set; }
    public required int StokAwal { get; set; }
    public required string Kategori { get; set; }
    public IFormFile? Gambar { get; set; }
    public string UrlGambar { get; set; } = string.Empty;
};