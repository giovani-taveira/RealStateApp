using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Persistence.Mappings
{
    public sealed class CondominiumTypeMapping : IEntityTypeConfiguration<CondominiumType>
    {
        public void Configure(EntityTypeBuilder<CondominiumType> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CreatedAt)
                .IsRequired();

        }
    }
}
