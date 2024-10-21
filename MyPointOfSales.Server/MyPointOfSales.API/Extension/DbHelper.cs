using Microsoft.EntityFrameworkCore;
using MyPointOfSales.Infrastructure.DataContext;

namespace MyPointOfSales.API.Extension;

public static class DbHelper
{
  public static void ApplyMigration(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetService<AppDbContext>();
    context!.Database.Migrate();
  }
}