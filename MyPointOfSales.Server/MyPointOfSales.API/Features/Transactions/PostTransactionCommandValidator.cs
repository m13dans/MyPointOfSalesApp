using FluentValidation;
using MyPointOfSales.Application.Features.Transactions;

namespace MyPointOfSales.API.Features.Transactions;

public class PostTransactionCommandValidator : AbstractValidator<PostTransactionRequest>
{
    public PostTransactionCommandValidator()
    {
        RuleFor(x => x.JumlahItem).GreaterThan(0).WithMessage("Jumlah Item yang akan di jual Harus lebih dari 1");
        RuleFor(x => x.ItemId).NotEmpty();
    }

}
