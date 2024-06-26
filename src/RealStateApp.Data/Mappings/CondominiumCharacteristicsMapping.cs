﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Persistence.Mappings
{
    public sealed class CondominiumCharacteristicsMapping : IEntityTypeConfiguration<CondominiumCharacteristic>
    {
        public void Configure(EntityTypeBuilder<CondominiumCharacteristic> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Characteristic)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CreatedAt)
                .IsRequired();
        }
    }
}
