using CleanArchitecture.Core.Entities.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.EntityConfigurations
{
    class HRConfiguration : IEntityTypeConfiguration<Department>,
        IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(u => u.Parent).WithMany(u => u.Children).HasForeignKey(u => u.ParentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.Manager).WithMany().HasForeignKey(u => u.ManagerId);
            
        }

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(u => u.Department).WithMany(u => u.Employees).HasForeignKey(u => u.DepartmentId);
        }
    }
}
