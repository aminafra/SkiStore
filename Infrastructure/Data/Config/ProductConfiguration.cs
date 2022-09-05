using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class ProductConfiguration :IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(prop => prop.Id).IsRequired();

        builder.Property(prop => prop.Name).IsRequired().HasMaxLength(100);

        builder.Property(prop => prop.Description).IsRequired();

        builder.Property(prop => prop.Price).HasColumnType("decimal(18,2)");

        builder.Property(prop => prop.PictureUrl).IsRequired();

        builder.HasOne(prop => prop.ProductBrand).WithMany()
            .HasForeignKey(prop => prop.ProductBrandId);

        builder.HasOne(prop => prop.ProductType).WithMany()
            .HasForeignKey(prop => prop.ProductTypeId);

    }
}