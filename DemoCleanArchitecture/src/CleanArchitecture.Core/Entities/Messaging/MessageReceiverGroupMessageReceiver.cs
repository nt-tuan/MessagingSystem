using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class MessageReceiverGroupMessageReceiver: BaseDetailEntity<MessageReceiverGroupMessageReceiver>
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }

        public int MessageReceiverGroupId { get; set; }
        public MessageReceiverGroup MessageReceiverGroup { get; set; }
    }
}
