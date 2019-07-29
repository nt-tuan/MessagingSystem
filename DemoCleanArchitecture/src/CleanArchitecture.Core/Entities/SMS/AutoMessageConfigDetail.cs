using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class AutoMessageConfigDetail : BaseDetailEntity
    {
        public int AutoMessageConfigId { get; set; }
        public AutoMessageConfig AutoMessageConfig { get; set; }
        public string Title { get; set; }
        public string Period { get; set; }
        public string Content { get; set; }
        public ICollection<AutoMessageConfigDetailMessageReceiver> AutoMessageConfigDetailMessageReceivers { get; set; }
        public ICollection<AutoMessageConfigDetailMessageReceiverGroup> AutoMessageConfigDetailsMessageReceiverGroups { get; set; }

        public ICollection<AutoMessageConfigDetailProvider> AutoMessageConfigDetailsProviders { get; set; }

        public ICollection<MessageReceiver> GetMessageReceivers()
        {
            return AutoMessageConfigDetailMessageReceivers.Select(u => u.MessageReceiver).ToList();
        }

        public ICollection<MessageReceiverGroup> GetMessageReceiverGroups()
        {
            return AutoMessageConfigDetailsMessageReceiverGroups.Select(u => u.MessageReceiveGroup).ToList();
        }

        public ICollection<MessageServiceProvider> GetProviders()
        {
            return AutoMessageConfigDetailsProviders.Select(u => u.MessageServiceProvider).ToList();
        }
    }
}
