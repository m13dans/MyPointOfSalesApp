namespace MyPointOfSales.Application.Features.Account;

public record RegisterUserResponse(
    string Nama,
    string Email,
    string Password
);

public record LoginUserResponse(
    string Bearer
);