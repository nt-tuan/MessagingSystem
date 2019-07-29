using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class AutoMessageConfigDetailMessageReceiverGroup : BaseEntity
    {
        public int AutoMessageConfigDetailId { get; set; }
        public AutoMessageConfigDetail AutoMessageConfigDetail { get; set; }

        public int MessageReceiverGroupId { get; set; }
        public MessageReceiverGroup MessageReceiverGroup { get; set; }
    }
}
