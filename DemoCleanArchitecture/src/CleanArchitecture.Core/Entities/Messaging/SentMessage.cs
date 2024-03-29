﻿using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class SentMessage : BaseEntity
    {
        public enum SentMessageStatus { SENDING = 1, SENT = 2, ERROR = -1}

        public string Content { get; set; }
        public int? AutoMessageConfigId { get; set; }
        public AutoMessageConfig AutoMessageDetails { get; set; }

        public DateTime SendTime { get; set; }
        public DateTime? ReceiveTime { get; set; }

        public int Status { get; set; }

        public int ReceiverProviderId { get; set; }
    }
}
