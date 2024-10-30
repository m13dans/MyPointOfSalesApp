namespace MyPointOfSales.Application.Features.Account;

public record RegisterUserRequest(
  string Nama,
  string Email,
  string Password
);

public record LoginUserRequest(
  string Email,
  string Password
);

public record LoginUserResponse(
    string Bearer
);