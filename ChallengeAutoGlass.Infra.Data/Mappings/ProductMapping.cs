using System;
using ClallangeAutoGlass.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeAutoGlass.Infra.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.FabricationDate)
                .IsRequired();


            builder.Property(p => p.ExpirationDate)
                .IsRequired();

            builder.ToTable("Products");
        }
    }
}

