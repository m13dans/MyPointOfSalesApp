using System.ComponentModel.DataAnnotations;

namespace MyPointOfSales.Application.Features.Reports;

public class QueryOption
{
    public OrderOption OrderOption { get; set; }
}

public enum OrderOption
{
    [Display(Name = "Tanggal Transaksi")] TanggalTransaksi,
    [Display(Name = "Total Transaksi")] TotalTransaksi
}
