using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class ReceiverProviderDetail : BaseDetailEntity
    {
        public int ReceiverProviderId { get; set; }
        public ReceiverProvider ReceiverProvider { get; set; }

        public string ReceiverAddress { get; set; }
    }
}
