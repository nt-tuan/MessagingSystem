using CleanArchitecture.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.EntityConfigurations
{
    public class BaseDetailConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseDetailEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasIndex(u => u.DateEffective);
            builder.HasIndex(u => u.DateEnd);
        }
    }
}
