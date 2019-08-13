using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class ReceiverProvider: BaseDetailEntity<ReceiverProvider>
    {
        public int MessageReceiverId { get; set; }
        public MessageReceiver MessageReceiver { get; set; }
        public int MessageServiceProviderId { get; set; }
        public MessageServiceProvider MessageServiceProvider { get; set; }
        public string ReceiverAddress { get; set; }
    }
}
