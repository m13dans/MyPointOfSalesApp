using ErrorOr;
using Microsoft.EntityFrameworkCore;
using MyPointOfSales.Application.Features.Account;
using MyPointOfSales.Domain.Users;
using MyPointOfSales.Infrastructure.DataContext;
using static MyPointOfSales.Infrastructure.Features.Account.UserHelper;

namespace MyPointOfSales.Infrastructure.Features.Account;

public class UserRepository(
    AppDbContext dbContext,
    TokenRepository tokenRepository) : IUserRepoSitory
{
    public async Task<ErrorOr<Created>> RegisterUser(RegisterUserCommand command)
    {
        User? userExist = await FindUserByEmail(command.Email);
        if (userExist is not null)
            return Error.Validation(code: "User.Validation", description: "Email sudah digunakan");

        User user = MapToUser(command);
        var result = await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
        return Result.Created;
    }

    public async Task<ErrorOr<LoginUserResponse>> LoginUser(LoginUserCommand command)
    {
        User? user = await FindUserByEmail(command.Email);
        if (user is null)
            return Error.Validation(code: "User.Validation", description: "Email atau password salah");

        string passwordHash = user.PasswordHash;

        var verify = BCrypt.Net.BCrypt.Verify(command.Password, passwordHash);
        if (!verify)
            return Error.Validation(code: "User.Validation", description: "Email atau password salah");

        var jwt = tokenRepository.GenerateJWTToken(user);
        return new LoginUserResponse(jwt);
    }

    public async Task<User?> FindUserByEmail(string email)
    {
        User? result = await dbContext.Users
            .SingleOrDefaultAsync(u => u.Email == email);
        return result;
    }
}
