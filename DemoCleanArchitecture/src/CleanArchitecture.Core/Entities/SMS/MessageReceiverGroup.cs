using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class MessageReceiverGroup : BaseEntity
    {
        public Boolean IsPrivate { get; set; }
    }
}
