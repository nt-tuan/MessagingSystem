using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class MessageReceiverGroupMessageReceiver : BaseEntity
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }

        public int MessageReceiverGroupId { get; set; }
        public MessageReceiverGroupDetail MessageReceiverGroupDetail { get; set; }
    }
}
