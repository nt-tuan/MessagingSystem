using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class AutoMessageConfigDetails : BaseEntity
    {
        public int AutoMessageConfigId { get; set; }
        public AutoMessageConfig GetAutoMessageConfig { get; set; }
        public string Period { get; set; }
        public string Content { get; set; }

        public ICollection<MessageReceiver> MessageReceivers { get; set; }
        public ICollection<MessageReceiverGroup> GetMessageReceiverGroups { get; set; }

        public ICollection<MessageServiceProvider> MessageServiceProviders { get; set; }

        public int VersionNumber { get; set; }

        //Meta data
        public DateTime CreatedTime { get; set; }
        public int? CreatedBy { get; set; }
    }
}
