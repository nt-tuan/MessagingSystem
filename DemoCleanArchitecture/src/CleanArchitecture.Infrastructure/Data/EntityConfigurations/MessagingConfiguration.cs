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
        IEntityTypeConfiguration<AutoMessageConfigProvider>
    {
        public void Configure(EntityTypeBuilder<AutoMessageConfig> builder)
        {
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigMessageReceiver> builder)
        {
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigMessageReceiverGroup> builder)
        {
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigProvider> builder)
        {
        }
    }
}
