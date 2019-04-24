using CleanArchitecture.Core.Entities.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.SupportRequests
{
    public class RequestProcessAction
    {
        public int Id { get; set; }

        public int? SupportRequestId { get; set; }

        public SupportRequest SupportRequest { get; set; }

        public DateTime ActionTime { get; set; }

        public int RequestStateId { get; set; }
        public RequestState RequestState { get; set; }

        //The ID whose take action
        public int? ActionById { get; set; }
        public Employee ActionBy { get; set; }
    }
}
