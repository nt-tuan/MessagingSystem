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
        }

        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.HasIndex(u => u.Code).IsUnique();
        }
    }
}
