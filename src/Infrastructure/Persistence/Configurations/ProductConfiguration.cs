using Clean_Architecture_Task.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.HasIndex(s =>s.BarCode).IsUnique();
            builder.HasIndex(s => s.Name).IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(250);

            builder.Property(x => x.BarCode)
                 .HasMaxLength(15)
                 .IsRequired();

            builder.Property(x => x.SellingPrice)
             .HasColumnType("Decimal(8,2)")
             .IsRequired(true);

            builder.Property(x => x.Deleted)
                    .HasDefaultValue(false);

            builder.Property(x => x.Disabled)
                    .HasDefaultValue(false);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
