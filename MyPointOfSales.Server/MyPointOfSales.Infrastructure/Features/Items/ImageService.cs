using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyPointOfSales.Application.Features.Items;

namespace MyPointOfSales.Infrastructure.Features.Items;

public class ImageService(IWebHostEnvironment environment) : IImageService
{
    public async Task<string> SaveImage(IFormFile file)
    {
        string uploadFolder = Path.Combine(environment.WebRootPath, "images");
        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }

        string newFileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(uploadFolder, newFileName);

        using FileStream fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);

        return Path.Combine("images", newFileName);
    }

    public async Task<string> UpdateImage(string oldImageName, IFormFile newFile)
    {
        string uploadFolder = Path.Combine(environment.WebRootPath, "images");
        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }

        string oldImagePath = Path.Combine(environment.WebRootPath, oldImageName);
        if (File.Exists(oldImagePath))
        {
            File.Delete(oldImagePath);
        }

        string newFileName = Path.GetRandomFileName() + Path.GetExtension(newFile.FileName);
        string newFilePath = Path.Combine(uploadFolder, newFileName);

        using FileStream fileStream = new FileStream(newFilePath, FileMode.Create);
        await newFile.CopyToAsync(fileStream);
        return Path.Combine("images", newFileName);
    }
}
