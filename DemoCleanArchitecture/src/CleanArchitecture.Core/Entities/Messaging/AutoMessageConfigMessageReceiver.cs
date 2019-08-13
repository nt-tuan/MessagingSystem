using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class AutoMessageConfigMessageReceiver : BaseDetailEntity<AutoMessageConfigMessageReceiver>
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }

        public int AutoMessageConfigId { get; set; }
        public AutoMessageConfig AutoMessageConfig { get; set; }
    }
}
