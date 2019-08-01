using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class AutoMessageConfig : BaseDetailEntity
    {
        public AutoMessageConfig Origin { get; set; }
        public ICollection<AutoMessageConfigMessageReceiver> AutoMessageConfigMessageReceivers { get; set; }
        public ICollection<AutoMessageConfigMessageReceiverGroup> AutoMessageConfigMessageReceiverGroups { get; set; }

        public ICollection<AutoMessageConfigProvider> AutoMessageConfigProviders { get; set; }

        public ICollection<MessageReceiver> GetMessageReceivers()
        {
            return AutoMessageConfigMessageReceivers.Select(u => u.MessageReceiver).ToList();
        }

        public ICollection<MessageReceiverGroup> GetMessageReceiverGroups()
        {
            return AutoMessageConfigMessageReceiverGroups.Select(u => u.MessageReceiverGroup).ToList();
        }

        public ICollection<MessageServiceProvider> GetProviders()
        {
            return AutoMessageConfigProviders.Select(u => u.MessageServiceProvider).ToList();
        }
        
    }
}
