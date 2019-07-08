using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CleanArchitecture.Core.Entities.Sales;

namespace CleanArchitecture.Core.Entities.SMS
{
    public class MessageReceiver : BaseEntity
    {
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? EmployeeId { get; set; }
        public HR.Employee Employee { get; set; }

        public int? ReceiverCategoryId { get; set; }
        public ReceiverCategory ReceiverCategory { get; set; }

        public string FullName { get; set; }
        public string ShortName { get; set; }

        public ICollection<MessageReceiverGroupMessageReceiver> MessageReceiverGroupMessageReceivers { get; set; }
        public ICollection<ReceiverProvider> ReceiverProviders { get; set; }

        //Meta data
        public DateTime CreatedTime { get; set; }
        public int? CreatedBy { get; set; }

        public ICollection<MessageReceiverGroup> GetMessageReceiverGroups()
        {
            return MessageReceiverGroupMessageReceivers.Select(u => u.MessageReceiverGroup).ToList();
        }
    }
}
