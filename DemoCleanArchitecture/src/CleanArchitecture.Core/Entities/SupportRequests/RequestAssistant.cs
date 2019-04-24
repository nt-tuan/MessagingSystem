using CleanArchitecture.Core.Entities.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.SupportRequests
{
    public class RequestAssistant
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int SupportRequestId { get; set; }

        public SupportRequest SupportRequest {get;set;}
    }
}
