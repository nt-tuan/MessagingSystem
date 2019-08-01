using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.Entities.HR;

namespace CleanArchitecture.Core.Entities.Messaging
{
    public class MessageReceiver : BaseDetailEntity
    {
        public ICollection<MessageReceiverGroupMessageReceiver> MessageReceiverGroupMessageReceivers { get; set; }
        public ICollection<ReceiverProvider> ReceiverProviders { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? EmployeeId { get; set; }
        public HR.Employee Employee { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public int? ReceiverCategoryId { get; set; }
        public ReceiverCategory ReceiverCategory { get; set; }
    }
}
