using ErrorOr;
using MyPointOfSales.Domain.Users;

namespace MyPointOfSales.Application.Features.Account;

public interface IUserRepoSitory
{
    public Task<ErrorOr<Created>> RegisterUser(RegisterUserCommand command);
    public Task<ErrorOr<LoginUserResponse>> LoginUser(LoginUserCommand command);
    public Task<User?> FindUserByEmail(string email);
}
