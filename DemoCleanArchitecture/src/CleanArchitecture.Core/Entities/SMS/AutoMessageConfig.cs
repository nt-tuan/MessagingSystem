using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class AutoMessageConfig : BaseEntity
    {
        public enum AutoMessageStatus {ACTIVE = 1, INACTIVE = 0, DELETED = -1 }

        public string Title { get; set; }

        public int Status { get; set; }

        //Meta data
        public DateTime CreateTime { get; set; }
        public int? CreatedById { get; set; }
        public Employee CreatedBy { get; set; }

        public ICollection<AutoMessageConfigDetails> Versions { get; set; }
    }
}
