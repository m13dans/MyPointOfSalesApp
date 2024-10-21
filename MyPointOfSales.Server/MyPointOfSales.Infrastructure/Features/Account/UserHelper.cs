using MyPointOfSales.Application.Features.Account;
using MyPointOfSales.Domain.Users;

namespace MyPointOfSales.Infrastructure.Features.Account;

public static class UserHelper
{
    public static User MapToUser(RegisterUserCommand command)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(command.Password);
        return new User()
        {
            Nama = command.Nama,
            Email = command.Email,
            PasswordHash = passwordHash
        };
    }
}
