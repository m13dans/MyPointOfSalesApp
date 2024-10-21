using MyPointOfSales.Domain.Users;

namespace MyPointOfSales.Application.Features.Account;

public class TokenService(ITokenRepoSitory tokenRepo)
{
    public string GenerateJWTToken(User user) =>
        tokenRepo.GenerateJWTToken(user);
}
