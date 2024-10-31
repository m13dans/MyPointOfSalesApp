using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace MyPointOfSales.Application.Features.Items;

public class CreateItemValidator : AbstractValidator<CreateItemRequest>
{
    public CreateItemValidator()
    {
        RuleFor(x => x.NamaBarang).MinimumLength(3).MaximumLength(255);
        RuleFor(x => x.StokAwal).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Kategori).MinimumLength(3).MaximumLength(255);
        RuleFor(x => x.Gambar)
            .Must(ValidateImageSize)
            .WithMessage("Gambar harus kurang dari 2 Mb");
        RuleFor(x => x.Gambar)
            .Must(ValidateImageExtension)
            .WithMessage("Harus berupa gambar .jpg / .png");
    }

    public static bool ValidateImageSize(IFormFile file)
    {
        const long allowedSize = 1024 * 1024 * 2;
        return file.Length < allowedSize;
    }

    public static bool ValidateImageExtension(IFormFile file)
    {
        string[] allowedExt = [".jpg", ".png", ".jpeg", ".webp"];
        string fileExtension = Path.GetExtension(file.FileName).ToLower();

        return allowedExt.Contains(fileExtension);
    }
}
public class UpdateItemValidator : AbstractValidator<UpdateItemRequest>
{
    public UpdateItemValidator()
    {
        RuleFor(x => x.NamaBarang).MinimumLength(3).MaximumLength(256);
        RuleFor(x => x.StokAwal).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Kategori).MinimumLength(3).MaximumLength(256);
        When(x => x.Gambar is not null, () =>
        {
            RuleFor(x => x.Gambar)
                .Must(ValidateImageSize!)
                .WithMessage("Gambar harus kurang dari 2 Mb");
            RuleFor(x => x.Gambar)
                .Must(ValidateImageExtension!)
                .WithMessage("Harus berupa gambar .jpg / .png");
        });

    }

    public static bool ValidateImageSize(IFormFile file)
    {
        const long allowedSize = 1024 * 1024 * 2;
        return file.Length < allowedSize;
    }

    public static bool ValidateImageExtension(IFormFile file)
    {
        string[] allowedExt = [".jpg", ".png", ".jpeg", ".webp"];
        string fileExtension = Path.GetExtension(file.FileName).ToLower();

        return allowedExt.Contains(fileExtension);
    }
}
