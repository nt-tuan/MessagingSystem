using CleanArchitecture.Core.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.EntityConfigurations
{
    class SaleConfiguration : IEntityTypeConfiguration<Customer>,
        IEntityTypeConfiguration<Distributor>
        
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(u => u.Code).IsUnique();
            builder.HasIndex(u => u.OriginId);
            builder.HasOne(u => u.Origin).WithMany().HasForeignKey(u => u.OriginId);
        }

        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.HasIndex(u => u.Code).IsUnique();
            builder.HasIndex(u => u.OriginId);
            builder.HasOne(u => u.Origin).WithMany().HasForeignKey(u => u.OriginId);
        }
    }
}
