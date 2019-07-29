using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class MessageServiceProvider : BaseEntity
    {
        public ICollection<ReceiverProvider> ReceiverProviders { get; set; }
    }
}
