using CleanArchitecture.Core.Entities.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data.EntityConfigurations
{
    class MessageReceiverConfiguration : IEntityTypeConfiguration<MessageReceiver>
    {
        public void Configure(EntityTypeBuilder<MessageReceiver> builder)
        {
            
        }
    }
}
