using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class MessageReceiverDetail : BaseDetailEntity
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
    }
}
