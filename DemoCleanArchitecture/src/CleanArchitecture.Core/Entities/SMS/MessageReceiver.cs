using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class MessageReceiver : BaseEntity
    {
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string FullName { get; set; }
        public string ShortName { get; set; }

        public int? EmployeeId { get; set; }
        public HR.Employee Employee { get; set; }

        public ICollection<MessageReceiverGroup> MessageReceiverGroups { get; set; }

        //Meta data
        public DateTime CreatedTime { get; set; }
        public int CreatedBy { get; set; }
    }
}
