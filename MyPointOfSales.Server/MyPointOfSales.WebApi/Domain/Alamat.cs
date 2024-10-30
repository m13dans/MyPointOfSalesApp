namespace PointOfSalesApp.API.Domain;

public class Alamat
{
    public int Id { get; set; }
    public required string Provinsi { get; set; }
    public required string Kota { get; set; }
    public required string AlamatLengkap { get; set; }
}