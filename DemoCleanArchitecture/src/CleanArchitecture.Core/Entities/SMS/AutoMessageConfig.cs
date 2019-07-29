using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class AutoMessageConfig : BaseEntity
    {
        public enum AutoMessageStatus {ACTIVE = 1, INACTIVE = 0, DELETED = -1 }

        public int Status { get; set; }
    }
}
