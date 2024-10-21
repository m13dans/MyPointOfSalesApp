using MyPointOfSales.Domain.Users;

namespace MyPointOfSales.Application.Features.Account;

public interface ITokenRepoSitory
{
    public string GenerateJWTToken(User user);
}
