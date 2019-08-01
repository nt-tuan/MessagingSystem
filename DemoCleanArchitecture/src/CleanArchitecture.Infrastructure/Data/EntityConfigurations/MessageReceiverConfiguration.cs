using CleanArchitecture.Core.Entities.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.EntityConfigurations
{
    class MessageReceiverConfiguration : IEntityTypeConfiguration<MessageReceiverGroupMessageReceiver>,
        IEntityTypeConfiguration<ReceiverProvider>
    {
        public void Configure(EntityTypeBuilder<MessageReceiverGroupMessageReceiver> builder)
        {
            builder.HasKey(u => new { u.MessageReceiverGroupId, u.MessageReceiverId });
            builder.HasOne(u => u.MessageReceiver).WithMany(u => u.MessageReceiverGroupMessageReceivers).HasForeignKey(u => u.MessageReceiverId);
            builder.HasOne(u => u.MessageReceiverGroup).WithMany(u => u.MessageReceiverGroupMessageReceivers).HasForeignKey(u => u.MessageReceiverGroupId);
        }

        public void Configure(EntityTypeBuilder<ReceiverProvider> builder)
        {
            builder.HasKey(u => new { u.MessageReceiverId, u.MessageServiceProviderId });
            builder.HasOne(u => u.MessageReceiver).WithMany(u => u.ReceiverProviders).HasForeignKey(u => u.MessageReceiverId);
            builder.HasOne(u => u.MessageServiceProvider).WithMany(u => u.ReceiverProviders).HasForeignKey(u => u.MessageServiceProviderId);
        }
    }
}
