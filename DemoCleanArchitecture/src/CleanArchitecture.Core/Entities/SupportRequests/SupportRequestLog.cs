using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.SupportRequests
{
    public class SupportRequestLog
    {
        public int Id { get; set; }

        public int SupportRequestId { get; set; }

        public SupportRequest SupportRequest { get; set; }

        public DateTime Time { get; set; }

        public int Status { get; set; }
        public string Note { get; set; }
    }
}
