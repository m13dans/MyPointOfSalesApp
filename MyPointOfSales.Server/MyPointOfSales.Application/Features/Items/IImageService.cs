using Microsoft.AspNetCore.Http;

namespace MyPointOfSales.Application.Features.Items;

public interface IImageService
{
    public Task<string> SaveImage(IFormFile file);
    public Task<string> UpdateImage(string oldImagePath, IFormFile file);
}