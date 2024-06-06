using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Persistence.Mappings
{
    public sealed class PropertyTypeMapping : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(pt => pt.CreatedAt)
                .IsRequired();
        }
    }
}
