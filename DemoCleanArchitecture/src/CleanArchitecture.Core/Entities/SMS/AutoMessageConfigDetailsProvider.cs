using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class AutoMessageConfigDetailsProvider : BaseEntity
    {
        public int AutoMessageConfigDetailsId { get; set; }
        public AutoMessageConfigDetails AutoMessageConfigDetails { get; set; }

        public int MessageServiceProviderId { get; set; }
        public MessageServiceProvider MessageServiceProvider { get; set; }
    }
}
