namespace PointOfSalesApp.API.Domain;

public class Report
{
    public DateOnly TanggalTransaksi { get; set; }
    public required List<int> ItemId { get; set; }
    public Option<Kategori> Kategori { get; set; }
    public int TotalTransaksi { get; set; }
    public decimal TotalHargaTransaksi { get; set; }
}
