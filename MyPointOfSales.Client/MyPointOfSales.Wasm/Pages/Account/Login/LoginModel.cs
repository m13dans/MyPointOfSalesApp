namespace MyPointOfSales.Wasm.Pages.Account.Login;

public record LoginModel
{
  public string Email { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
}

public record LoginUserResponse(
    string Bearer
);