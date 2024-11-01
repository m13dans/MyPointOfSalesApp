using FluentValidation;
using MyPointOfSales.Domain.Users;

namespace MyPointOfSales.Application.Features.Account;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidator(IUserRepoSitory userRepo)
    {
        RuleFor(x => x.Nama).NotEmpty().MaximumLength(256);

        RuleFor(x => x.Email)
            .MustAsync(async (x, c) =>
            {
                User? user = await userRepo.FindUserByEmail(x);
                return user is null;
            }).WithMessage("Email sudah digunakan");

        RuleFor(x => x.Email).NotEmpty()
            .EmailAddress()
            .WithMessage("Masukan alamat email yang benar.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password harus di isi.")
            .MinimumLength(6).WithMessage("Password minimal 6 karakter.")
            .MaximumLength(20).WithMessage("Password maksimal 20 karakter.")
            .Matches(@"[A-Z]").WithMessage("Password memiliki setidaknya satu huruf kapital.")
            .Matches(@"[a-z]").WithMessage("Password memiliki setidaknya satu huruf kecil.")
            .Matches(@"[0-9]").WithMessage("Password memiliki setidaknya satu angka.")
            .Matches(@"[\W]").WithMessage("Password memiliki setidaknya satu karakter spesial (!.@ dll..).");
    }
}
public class LoginUserValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password harus di isi");
    }
}
