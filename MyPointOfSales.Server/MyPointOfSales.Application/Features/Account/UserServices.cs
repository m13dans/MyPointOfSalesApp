using ErrorOr;
using MyPointOfSales.Domain.Users;

namespace MyPointOfSales.Application.Features.Account;
public class UserService(IUserRepoSitory repo, ITokenRepoSitory tokenRepo)
{
    public async Task<ErrorOr<Created>> RegisterUser(RegisterUserRequest request)
    {
        User? userExist = await repo.FindUserByEmail(request.Email);
        if (userExist is not null)
            return Error.Validation(code: "User.Validation", description: "Email sudah digunakan");

        string hashedPassword = tokenRepo.HashPassword(request.Password);

        User user = request.ToEntity(hashedPassword);
        ErrorOr<Created> result = await repo.AddUser(user);
        return result;
    }

    public async Task<ErrorOr<LoginUserResponse>> LoginUser(LoginUserRequest request)
    {
        User? userExists = await repo.FindUserByEmail(request.Email);
        if (userExists is null)
            return Error.Validation(code: "User.Validation", description: "Email atau password salah");

        bool passwordMatch = tokenRepo.VerifyToken(request.Password, userExists.PasswordHash);
        if (!passwordMatch)
            return Error.Validation(code: "User.Validation", description: "Email atau password salah");

        var token = tokenRepo.GenerateJWTToken(userExists);
        return new LoginUserResponse(token);
    }

    public ErrorOr<Success> Logout()
    {
        return Result.Success;
    }
}