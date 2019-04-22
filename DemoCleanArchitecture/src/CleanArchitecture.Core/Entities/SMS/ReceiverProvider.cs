using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class ReceiverProvider : BaseEntity
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }
        public int SendMessageProviderId { get; set; }
        public MessageServiceProvider MessageServiceProvider { get; set; }

        public string ReceiverAddress { get; set; }

        //Meta data
        public DateTime CreatedTime { get; set; }
        public int? CreatedBy { get; set; }
    }
}
