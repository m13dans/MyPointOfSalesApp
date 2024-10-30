using ErrorOr;
using MyPointOfSales.Domain.Users;

namespace MyPointOfSales.Application.Features.Account;

public interface IUserRepoSitory
{
    public Task<ErrorOr<Created>> AddUser(User user);
    public Task<User?> FindUserByEmail(string email);
}
