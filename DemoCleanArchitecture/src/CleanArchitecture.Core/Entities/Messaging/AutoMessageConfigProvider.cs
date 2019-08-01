using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class AutoMessageConfigProvider
    {
        public int AutoMessageConfigId { get; set; }
        public AutoMessageConfig AutoMessageConfig { get; set; }

        public int MessageServiceProviderId { get; set; }
        public MessageServiceProvider MessageServiceProvider { get; set; }
    }
}
