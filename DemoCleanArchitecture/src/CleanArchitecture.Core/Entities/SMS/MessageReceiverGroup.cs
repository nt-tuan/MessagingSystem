using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class MessageReceiverGroup : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<MessageReceiverGroupMessageReceiver> MessageReceiverGroupMessageReceivers { get; set; }

        //Meta data
        public DateTime CreatedTime { get; set; }
        public int? CreatedBy { get; set; }

        public Boolean IsPrivate { get; set; }
        public ICollection<MessageReceiver> GetMessageReceivers()
        {
            return MessageReceiverGroupMessageReceivers.Select(u => u.MessageReceiver).ToList();
        }
    }
}
