using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.Entities.Core;
using CleanArchitecture.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.EntityConfigurations
{

    class CoreConfiguration : IEntityTypeConfiguration<Person>, IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasOne(u => u.AppUser).WithOne(u => u.Person).HasForeignKey<AppUser>(u => u.PersonId);
        }
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasOne(u => u.AppUser).WithOne(u => u.Business).HasForeignKey<AppUser>(u => u.BusinessId);
        }
    }

}
