using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Persistence.Mappings
{
    public sealed class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.CEP)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(a => a.StreetName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.NeighborhoodName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Longitude)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Latitude)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Number)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.Complement)
                .HasMaxLength(100);

            builder.Property(a => a.CreatedAt)
                .IsRequired();
        }
    }
}
