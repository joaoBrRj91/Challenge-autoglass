using System;
using ClallangeAutoGlass.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeAutoGlass.Infra.Data.Mappings
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.HasMany(f => f.Products)
                 .WithOne(p => p.Supplier)
                 .HasForeignKey(p => p.SupplierId);

            builder.ToTable("Suppliers");
        }
    }
}

