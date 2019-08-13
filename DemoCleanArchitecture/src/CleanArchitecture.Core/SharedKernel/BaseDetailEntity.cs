using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.SharedKernel
{
    public class BaseDetailEntity : BaseEntity
    {
        public DateTime DateEffective { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateReplaced { get; set; }
        public string DiscriptionNote { get; set; }
        public int? OriginId { get; set; }

        public ICollection<BaseDetailEntity> Changes { get; set; }
    }
}
