using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Persistence.Mappings
{
    public sealed class CondominumMapping : IEntityTypeConfiguration<Condominium>
    {
        public void Configure(EntityTypeBuilder<Condominium> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.HasMany(c => c.Characteristics)
                .WithOne(cc => cc.Condominium)
                .HasForeignKey(cc => cc.CondominiumId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Properties)
                .WithOne(cc => cc.Condominium)
                .HasForeignKey(cc => cc.CondominiumId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.CondominiumType)
                .WithMany(cc => cc.Condominiums)
                .HasForeignKey(cc => cc.CondominiumTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
