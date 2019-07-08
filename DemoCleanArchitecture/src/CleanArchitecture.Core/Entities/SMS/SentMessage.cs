using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class SentMessage : BaseEntity
    {
        public enum SentMessageStatus { SENDING = 1, SENT = 2, ERROR = -1}

        public string Content { get; set; }
        public int? AutoMessageConfigDetailsId { get; set; }
        public AutoMessageConfigDetails AutoMessageConfigDetails { get; set; }

        public DateTime SendTime { get; set; }
        public DateTime? ReceiveTime { get; set; }

        public int Status { get; set; }

        public int ReceiverProviderId { get; set; }
        public ReceiverProvider ReceiverProvider { get; set; }

        //Meta data
        public int? SentBy { get; set; }
    }
}
