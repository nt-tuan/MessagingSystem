using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class MessageReceiverGroupMessageReceiver : BaseEntity
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }

        public int MessageReceiverGroupId { get; set; }
        public MessageReceiverGroup MessageReceiverGroup { get; set; }
    }
}
