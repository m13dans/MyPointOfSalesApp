namespace MyPointOfSales.Wasm.Pages.Account.Register;

public record RegisterModel
{
  public string Nama { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
}