using CleanArchitecture.Core.Entities.HR;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public Employee CreatedBy { get; set; }
        public DateTime? RemoveTime { get; set; }
        public Employee RemovedBy { get; set; }
        public bool Removed { get; set; }
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}