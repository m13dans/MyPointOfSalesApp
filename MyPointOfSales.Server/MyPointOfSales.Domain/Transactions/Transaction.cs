namespace MyPointOfSales.Domain.Transactions;

public class Transaction
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int JumlahItemDiJual { get; set; }
    public int SisaItem { get; set; }
    public required string Kategori { get; set; }
    public decimal Harga { get; set; }
    public decimal TotalHarga { get; set; }
    public DateOnly TanggalTransaksi { get; set; }
}
