using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class AutoMessageConfigDetailsMessageReceiverGroup : BaseEntity
    {
        public int AutoMessageConfigDetailsId { get; set; }
        public AutoMessageConfigDetails AutoMessaegConfigDetails { get; set; }

        public int MessageReceiverGroupId { get; set; }
        public MessageReceiverGroup MessageReceiveGroup { get; set; }
    }
}
