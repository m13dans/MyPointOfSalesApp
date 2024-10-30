namespace PointOfSalesApp.API.Domain;

public class Stok
{
    public required string NamaBarang { get; set; }
    public Option<Kategori> Kategori { get; set; }
    public required int JumlahStokSaatIni { get; set; }
    public required decimal Harga { get; set; }
}
