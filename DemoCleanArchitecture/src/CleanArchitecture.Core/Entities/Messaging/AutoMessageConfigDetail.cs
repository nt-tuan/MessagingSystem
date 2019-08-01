using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class AutoMessageConfigDetail : BaseDetailEntity
    {
        public enum AutoMessageStatus { ACTIVE = 1, INACTIVE = 0, DELETED = -1 }
        public AutoMessageConfig Origin { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public string Period { get; set; }
        public string Content { get; set; }
    }
}
