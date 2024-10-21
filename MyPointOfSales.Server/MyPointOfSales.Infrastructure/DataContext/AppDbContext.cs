using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MyPointOfSales.Domain.Items;
using MyPointOfSales.Domain.Transactions;
using MyPointOfSales.Domain.Users;

namespace MyPointOfSales.Infrastructure.DataContext;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
