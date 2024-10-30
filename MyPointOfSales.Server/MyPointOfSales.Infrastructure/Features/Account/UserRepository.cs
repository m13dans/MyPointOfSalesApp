using ErrorOr;
using Microsoft.EntityFrameworkCore;
using MyPointOfSales.Application.Features.Account;
using MyPointOfSales.Domain.Users;
using MyPointOfSales.Infrastructure.DataContext;

namespace MyPointOfSales.Infrastructure.Features.Account;

public class UserRepository(AppDbContext dbContext) : IUserRepoSitory
{
    public async Task<ErrorOr<Created>> AddUser(User user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
        return Result.Created;
    }

    public async Task<User?> FindUserByEmail(string email)
    {
        User? result = await dbContext.Users
            .SingleOrDefaultAsync(u => u.Email == email);
        return result;
    }
}
