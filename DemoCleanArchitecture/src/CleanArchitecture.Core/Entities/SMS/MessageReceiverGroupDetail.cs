using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class MessageReceiverGroupDetail : BaseDetailEntity
    {
        public int MessageReceiverGroupId { get; set; }
        public MessageReceiverGroup MessageReceiverGroup { get; set; }
        public string Name { get; set; }

        public ICollection<MessageReceiverGroupMessageReceiver> MessageReceiverGroupMessageReceivers { get; set; }

        public ICollection<MessageReceiver> GetMessageReceivers()
        {
            return MessageReceiverGroupMessageReceivers.Select(u => u.MessageReceiver).ToList();
        }
    }
}
