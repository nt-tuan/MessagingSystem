using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class ReceiverCategory : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<MessageReceiver> MessageReceivers { get; set; }
    }
}
