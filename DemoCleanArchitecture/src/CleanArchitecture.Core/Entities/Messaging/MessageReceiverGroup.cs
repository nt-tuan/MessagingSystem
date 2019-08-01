using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class MessageReceiverGroup : BaseDetailEntity
    {
        public Boolean IsPrivate { get; set; }
        public string Name { get; set; }
        public ICollection<MessageReceiverGroupMessageReceiver> MessageReceiverGroupMessageReceivers { get; set; }
        public ICollection<MessageReceiver> GetMessageReceivers()
        {
            return MessageReceiverGroupMessageReceivers.Select(u => u.MessageReceiver).ToList();
        }


    }
}
