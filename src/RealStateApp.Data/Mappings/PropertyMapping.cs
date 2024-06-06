using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Persistence.Mappings
{
    public sealed class PropertyMapping : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Characteristics)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.QtyBedrooms)
                .IsRequired();

            builder.Property(p => p.QtyBathrooms)
                .IsRequired();

            builder.Property(p => p.QtySuites)
                .IsRequired();

            builder.Property(p => p.BuildingArea)
                .IsRequired();

            builder.Property(p => p.LandArea)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .IsRequired();

            builder.Property(p => p.AddressId)
               .IsRequired();

            builder.Property(p => p.PropertyTypeId)
              .IsRequired();

            builder.HasOne(p => p.Address)
                .WithOne(a => a.Property)
                .HasForeignKey<Property>(p => p.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Condominium)
                .WithMany(c => c.Properties)
                .HasForeignKey(p => p.CondominiumId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PropertyType)
                .WithMany(pt => pt.Properties)
                .HasForeignKey(p => p.PropertyTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
