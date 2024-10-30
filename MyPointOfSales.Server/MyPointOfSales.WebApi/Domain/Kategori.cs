using System.ComponentModel.DataAnnotations;

namespace PointOfSalesApp.API.Domain;

public class Kategori
{
    public int Id { get; set; }

    public required string NamaKategori { get; set; }
}