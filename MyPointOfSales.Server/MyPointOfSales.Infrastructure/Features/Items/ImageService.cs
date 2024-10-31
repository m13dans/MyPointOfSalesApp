using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyPointOfSales.Application.Features.Items;

namespace MyPointOfSales.Infrastructure.Features.Items;

public class ImageService(IWebHostEnvironment environment) : IImageService
{
    public async Task<string> SaveImage(IFormFile file)
    {
        var uploadFolder = Path.Combine(environment.WebRootPath, "images");
        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }

        string newFileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(uploadFolder, newFileName);

        using var fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);

        return Path.Combine("images", newFileName);
    }
}
