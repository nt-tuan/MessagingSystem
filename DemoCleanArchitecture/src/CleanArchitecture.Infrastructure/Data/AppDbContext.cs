using CleanArchitecture.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.SMS;
using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.SharedKernel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CleanArchitecture.Core.Entities.Accounts;

namespace CleanArchitecture.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        //SMS Module
        //public DbSet<AutoMessageConfig> AutoMessageConfigs { get; set; }
        //public DbSet<AutoMessageConfigDetails> AutoMessageConfigDetails { get; set; }
        public DbSet<MessageReceiver> MessageReceivers { get; set; }
        public DbSet<ReceiverCategory> ReceiverCategory { get; set; }
        //public DbSet<MessageReceiverGroup> MessageReceiverGroups { get; set; }
        //public DbSet<MessageServiceProvider> MessageServiceProviders { get; set; }
        //public DbSet<ReceiverProvider> ReceiverProviders { get; set; }
        //public DbSet<SentMessage> SentMessages { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasOne(u => u.Department).WithMany(u => u.Employees);
            modelBuilder.Entity<Employee>().HasMany(u => u.EmployeeJobs).WithOne(u => u.Employee).HasForeignKey(u => u.EmployeeId);
            modelBuilder.Entity<EmployeeJob>().HasMany(u => u.EmployeeJobRequirements).WithOne(u => u.EmployeeJob).HasForeignKey(u => u.EmployeeJobId);
            modelBuilder.Entity<JobRequirement>().HasMany(u => u.EmployeeJobRequirements).WithOne(u => u.JobRequirement).HasForeignKey(u => u.JobRequirementId);
            modelBuilder.Entity<MessageReceiver>().HasOne(u => u.ReceiverCategory).WithMany(u => u.MessageReceivers).HasForeignKey(u => u.ReceiverCategoryId);
            modelBuilder.Entity<MessageReceiver>().Ignore(u => u.MessageReceiverGroups);
            modelBuilder.Entity<EmployeeJobRequirement>().HasKey(u => u.JobRequirementId);
            modelBuilder.Entity<EmployeeJobRequirement>().HasKey(u => u.EmployeeJobId);
        }
    }
}