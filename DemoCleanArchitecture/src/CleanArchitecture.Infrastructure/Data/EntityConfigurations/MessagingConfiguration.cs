using CleanArchitecture.Core.Entities.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.EntityConfigurations
{
    class MessagingConfiguration :
        IEntityTypeConfiguration<AutoMessageConfigDetail>,       IEntityTypeConfiguration<AutoMessageConfigDetailMessageReceiver>,
        IEntityTypeConfiguration<AutoMessageConfigDetailMessageReceiverGroup>,
        IEntityTypeConfiguration<AutoMessageConfigDetailProvider>,
        IEntityTypeConfiguration<MessageReceiverGroupMessageReceiver>
    {
        public void Configure(EntityTypeBuilder<AutoMessageConfigDetail> builder)
        {
            builder.Property(u => u.Title).IsRequired();
            builder.Property(u => u.Period).IsRequired();
            builder.Property(u => u.Content).IsRequired();
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigDetailMessageReceiver> builder)
        {
            builder.HasKey(u => new { u.MessageReceiverId, u.AutoMessageConfigDetailId });
            builder.HasOne(u => u.MessageReceiver).WithMany().HasForeignKey(u => u.AutoMessageConfigDetailId);
            builder.HasOne(u => u.AutoMessageConfigDetail).WithMany(u => u.AutoMessageConfigDetailMessageReceivers).HasForeignKey(u => u.AutoMessageConfigDetailId);
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigDetailMessageReceiverGroup> builder)
        {
            builder.HasKey(u => new { u.AutoMessageConfigDetailId, u.MessageReceiverGroupId });
            builder.HasOne(u => u.AutoMessageConfigDetail).WithMany(u => u.AutoMessageConfigDetailsMessageReceiverGroups).HasForeignKey(u => u.AutoMessageConfigDetailId);
            builder.HasOne(u => u.MessageReceiverGroup).WithMany().HasForeignKey(u => u.MessageReceiverGroupId);
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigDetailProvider> builder)
        {
            builder.HasKey(u => new { u.AutoMessageConfigDetailId, u.MessageServiceProviderId });
            builder.HasOne(u => u.AutoMessageConfigDetail).WithMany(u => u.AutoMessageConfigDetailsProviders).HasForeignKey(u => u.AutoMessageConfigDetailId);
            builder.HasOne(u => u.MessageServiceProvider).WithMany().HasForeignKey(u => u.MessageServiceProviderId);
        }

        public void Configure(EntityTypeBuilder<MessageReceiverGroupMessageReceiver> builder)
        {
            builder.HasKey(u => new { u.MessageReceiverId, u.MessageReceiverGroupId });
        }
    }
}
