using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.Entities.HR;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity
    {
        public enum ListOrder {ASC = 1, DESC = 0}
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public AppUser CreatedBy { get; set; }
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}