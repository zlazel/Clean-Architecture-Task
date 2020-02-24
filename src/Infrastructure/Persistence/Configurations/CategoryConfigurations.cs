using Clean_Architecture_Task.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen.Persistence.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired().HasMaxLength(120);

            builder.Property(s => s.Disabled)
                .HasDefaultValue(false);

            builder.Property(s => s.Deleted)
                .HasDefaultValue(false);
        }
    }
}
