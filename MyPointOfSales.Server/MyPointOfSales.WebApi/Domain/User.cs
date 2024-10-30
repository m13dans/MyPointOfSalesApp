namespace PointOfSalesApp.API.Domain;

public class User
{
    public int Id { get; set; }
    public required string Nama { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public Option<List<Role>> Role { get; set; }
    public Option<List<Alamat>> Alamat { get; set; }
}

public class Role
{
    public int Id { get; set; }
    public required string NamaRole { get; set; }
}