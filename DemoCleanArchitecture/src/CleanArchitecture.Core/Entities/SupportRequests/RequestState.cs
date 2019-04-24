using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.SupportRequests
{
    public class RequestState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discribe { get; set; }
        public string PostClassName { get; set; }
    }
}
