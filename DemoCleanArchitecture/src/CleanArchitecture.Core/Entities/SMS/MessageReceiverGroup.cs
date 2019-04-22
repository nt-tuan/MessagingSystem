using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class MessageReceiverGroup : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<MessageReceiver> MessageReceivers { get; set; }
        public ICollection<Tag> Tags { get; set; }

        //Meta data
        public DateTime CreatedTime { get; set; }
        public int? CreatedBy { get; set; }
    }
}
