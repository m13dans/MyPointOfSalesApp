using Microsoft.AspNetCore.Http;

namespace MyPointOfSales.Application.Features.Items;

public interface IImageService
{
    public Task<string> SaveImage(IFormFile file);
}