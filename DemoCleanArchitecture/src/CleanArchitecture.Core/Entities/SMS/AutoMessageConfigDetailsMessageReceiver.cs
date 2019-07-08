using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class AutoMessageConfigDetailsMessageReceiver : BaseEntity
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }

        public int AutoMessageConfigDetailsId { get; set; }
        public AutoMessageConfigDetails AutoMessageConfigDetails { get; set; }
    }
}
