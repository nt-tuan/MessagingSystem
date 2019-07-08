using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class AutoMessageConfigDetails : BaseEntity
    {
        public int AutoMessageConfigId { get; set; }
        public AutoMessageConfig AutoMessageConfig { get; set; }
        public string Period { get; set; }
        public string Content { get; set; }

        public ICollection<AutoMessageConfigDetailsMessageReceiver> AutoMessageConfigDetailsMessageReceivers { get; set; }
        public ICollection<AutoMessageConfigDetailsMessageReceiverGroup> AutoMessageConfigDetailsMessageReceiverGroups { get; set; }

        public ICollection<AutoMessageConfigDetailsProvider> AutoMessageConfigDetailsProviders { get; set; }

        public int VersionNumber { get; set; }

        //Meta data
        public DateTime CreatedTime { get; set; }
        public int? CreatedById { get; set; }
        public Employee CreatedBy { get; set; }

        public ICollection<MessageReceiver> GetMessageReceivers()
        {
            return AutoMessageConfigDetailsMessageReceivers.Select(u => u.MessageReceiver).ToList();
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
