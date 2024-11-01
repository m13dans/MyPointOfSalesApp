namespace MyPointOfSales.Domain.Reports;

public class Report
{
    public DateOnly TanggalTransaksi { get; set; }
    public required List<int> ItemId { get; set; }
    public string NamaBarang { get; set; }
    public required List<string> Kategori { get; set; }
    public int TotalTransaksi { get; set; }
    public decimal TotalHargaTransaksi { get; set; }

}
