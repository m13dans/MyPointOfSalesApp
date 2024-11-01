using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPointOfSales.Domain.Items;

namespace MyPointOfSales.Infrastructure.Features.Items;

public class ItemEntityConfig : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.NamaBarang).HasMaxLength(256);
        builder.Property(x => x.Harga).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Kategori).HasMaxLength(256);
        builder.Property(x => x.UrlGambar).HasMaxLength(512);
    }
}
