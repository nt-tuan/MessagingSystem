using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class AutoMessageConfigDetailProvider : BaseEntity
    {
        public int AutoMessageConfigDetailId { get; set; }
        public AutoMessageConfigDetail AutoMessageConfigDetail { get; set; }

        public int MessageServiceProviderId { get; set; }
        public MessageServiceProvider MessageServiceProvider { get; set; }
    }
}
