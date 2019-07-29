using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class AutoMessageConfigDetailMessageReceiver
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }

        public int AutoMessageConfigDetailId { get; set; }
        public AutoMessageConfigDetail AutoMessageConfigDetail { get; set; }
    }
}
