using CleanArchitecture.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.SMS;
using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        //SMS Module
        public DbSet<AutoMessageConfig> AutoMessageConfigs { get; set; }
        public DbSet<AutoMessageConfigDetails> AutoMessageConfigDetails { get; set; }
        public DbSet<MessageReceiver> MessageReceivers { get; set; }
        public DbSet<MessageReceiverGroup> MessageReceiverGroups { get; set; }
        public DbSet<MessageServiceProvider> MessageServiceProviders { get; set; }
        public DbSet<ReceiverProvider> ReceiverProviders { get; set; }
        public DbSet<SentMessage> SentMessages { get; set; }

        //HR Module
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<EmployeeJob> EmpoyeeJobs { get; set; }
        public DbSet<EmployeeJobRequirement> EmployeeJobRequirements { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }

            return result;
        }
    }
}