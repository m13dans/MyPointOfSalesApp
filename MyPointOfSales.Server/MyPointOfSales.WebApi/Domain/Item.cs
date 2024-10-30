namespace PointOfSalesApp.API.Domain;

public class Item
{
    public int Id { get; set; }
    public required string NamaBarang { get; set; }
    public required decimal Harga { get; set; }
    public required int StokAwal { get; set; }
    public List<Kategori>? Kategori { get; set; }
    public string? UrlGambar { get; set; }
}
