using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class AutoMessageConfigMessageReceiverGroup
    {
        public int AutoMessageConfigId { get; set; }
        public AutoMessageConfig AutoMessageConfig { get; set; }

        public int MessageReceiverGroupId { get; set; }
        public MessageReceiverGroup MessageReceiverGroup { get; set; }
    }
}
