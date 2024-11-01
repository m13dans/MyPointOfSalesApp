using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyPointOfSales.Application.Features.Account;
using MyPointOfSales.Domain.Users;

namespace MyPointOfSales.Infrastructure.Features.Account;

public class TokenRepository(IConfiguration config) : ITokenRepoSitory
{
    public string GenerateJWTToken(User user)
    {
        string key = config.GetValue<string>("JwtSettings:SignKey") ?? string.Empty;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        List<Claim> userClaims = [
            new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.Nama),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        ];

        var token = new JwtSecurityToken(
            issuer: config.GetValue<string>("JwtSettings:Issuer"),
            audience: config.GetValue<string>("JwtSettings:Audience"),
            claims: userClaims,
            expires: DateTime.UtcNow.AddHours(1.0),
            signingCredentials: credential
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    public bool VerifyToken(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
}
