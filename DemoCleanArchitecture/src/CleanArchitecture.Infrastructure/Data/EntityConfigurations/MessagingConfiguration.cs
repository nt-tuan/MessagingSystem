using CleanArchitecture.Core.Entities.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.EntityConfigurations
{
    class MessagingConfiguration :
        IEntityTypeConfiguration<AutoMessageConfig>, IEntityTypeConfiguration<AutoMessageConfigMessageReceiver>,
       IEntityTypeConfiguration<AutoMessageConfigMessageReceiverGroup>,
        IEntityTypeConfiguration<AutoMessageConfigProvider>,
        IEntityTypeConfiguration<AutoMessageConfigDetail>
    {
        public void Configure(EntityTypeBuilder<AutoMessageConfig> builder)
        {
            builder.HasIndex(u => u.OriginId);
            builder.HasOne(u => u.Origin).WithMany().HasForeignKey(u => u.OriginId);
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigMessageReceiver> builder)
        {
            builder.HasKey(u => new { u.MessageReceiverId, u.AutoMessageConfigId });
            builder.HasOne(u => u.MessageReceiver).WithMany().HasForeignKey(u => u.MessageReceiverId);
            builder.HasOne(U => U.AutoMessageConfig).WithMany(u => u.AutoMessageConfigMessageReceivers).HasForeignKey(u => u.AutoMessageConfigId);
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigMessageReceiverGroup> builder)
        {
            builder.HasKey(u => new { u.AutoMessageConfigId, u.MessageReceiverGroupId });
            builder.HasOne(u => u.AutoMessageConfig).WithMany(u => u.AutoMessageConfigMessageReceiverGroups).HasForeignKey(u => u.AutoMessageConfigId);
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigProvider> builder)
        {
            builder.HasKey(u => new { u.AutoMessageConfigId, u.MessageServiceProviderId });
            builder.HasOne(u => u.AutoMessageConfig).WithMany(u => u.AutoMessageConfigProviders).HasForeignKey(u => u.AutoMessageConfigId);
            builder.HasOne(u => u.MessageServiceProvider).WithMany().HasForeignKey(u => u.MessageServiceProviderId);
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigDetail> builder)
        {
            builder.Property(u => u.Title).IsRequired();
            builder.Property(u => u.Period).IsRequired();
            builder.Property(u => u.Content).IsRequired();
            builder.HasOne(u => u.Origin).WithMany().HasForeignKey(u => u.OriginId);
        }
    }
}
