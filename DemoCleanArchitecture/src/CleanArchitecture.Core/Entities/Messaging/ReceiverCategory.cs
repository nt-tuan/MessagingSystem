using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class ReceiverCategory : BaseDetailEntity<ReceiverCategory>
    {
        public string Code { get; set; }
        public ICollection<MessageReceiver> MessageReceivers { get; set; }
        public string Name { get; set; }
    }
}
