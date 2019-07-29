using CleanArchitecture.Core.Entities.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.EntityConfigurations
{
    class HRConfiguration : IEntityTypeConfiguration<Department>,
        IEntityTypeConfiguration<DepartmentDetail>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasIndex(u => new { u.Code, u.Removed });
        }

        public void Configure(EntityTypeBuilder<DepartmentDetail> builder)
        {
            builder.HasOne(u => u.Department).WithMany().HasForeignKey(u => u.DepartmentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(u => u.Parent).WithMany(u => u.Children).HasForeignKey(u => u.ParentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.Manager).WithMany().HasForeignKey(u => u.ManagerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
