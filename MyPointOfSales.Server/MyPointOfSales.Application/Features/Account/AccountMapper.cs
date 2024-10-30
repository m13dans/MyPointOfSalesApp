using MyPointOfSales.Domain.Users;

namespace MyPointOfSales.Application.Features.Account;

public static class AccountMapper
{
    public static User ToEntity(this RegisterUserRequest request, string hashedPassword) =>
        new User()
        {
            Nama = request.Nama,
            Email = request.Email,
            PasswordHash = hashedPassword
        };
}
