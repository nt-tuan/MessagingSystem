using CleanArchitecture.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Messaging;
using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.SharedKernel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.Entities.Sales;

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

        //Messaging Module
        //public DbSet<AutoMessageConfig> AutoMessageConfigs { get; set; }
        //public DbSet<AutoMessageConfigDetails> AutoMessageConfigDetails { get; set; }
        public DbSet<AutoMessageConfig> AutoMessageConfigs { get; set; }
        public DbSet<AutoMessageConfigDetails> AutoMessageConfigDetails { get; set; }
        public DbSet<AutoMessageConfigDetailsMessageReceiver> AutoMesasgeConfigDetailsMessageReceivers { get; set; }
        public DbSet<AutoMessageConfigDetailsMessageReceiverGroup> AutoMessageConfigDetailsMessageReceiverGroups { get;set;}
        public DbSet<AutoMessageConfigDetailsProvider> AutoMessageConfigDetailsProviders { get; set; }
        public DbSet<MessageReceiver> MessageReceivers { get; set; }
        public DbSet<MessageReceiverGroup> MessageReceiverGroups { get; set; }
        public DbSet<MessageReceiverGroupMessageReceiver> MessageReceiverGroupMessageReceivers { get; set; }
        public DbSet<MessageServiceProvider> MessageServiceProviders { get; set; }
        public DbSet<ReceiverCategory> ReceiverCategories { get; set; }
        public DbSet<ReceiverProvider> ReceiverProviders { get; set; }
        public DbSet<SentMessage> SentMessages { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Distributor> Distributors { get; set; }

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

            //Messaging constraints
            modelBuilder.Entity<AutoMessageConfig>().HasOne(u => u.CreatedBy).WithMany().HasForeignKey(u => u.CreatedById);

            modelBuilder.Entity<AutoMessageConfigDetails>().HasOne(u => u.AutoMessageConfig).WithMany(u => u.Versions).HasForeignKey(u => u.AutoMessageConfigId);

            modelBuilder.Entity<AutoMessageConfigDetails>().HasOne(u => u.CreatedBy).WithMany().HasForeignKey(u => u.CreatedById);

            //AutoMessageConfigDetailsMessageReceiver many-to-many
            modelBuilder.Entity<AutoMessageConfigDetailsMessageReceiver>().Ignore(u => u.Id);
            modelBuilder.Entity<AutoMessageConfigDetailsMessageReceiver>().HasOne(u => u.AutoMessageConfigDetails).WithMany(u => u.AutoMessageConfigDetailsMessageReceivers).HasForeignKey(u => u.AutoMessageConfigDetailsId);

            modelBuilder.Entity<AutoMessageConfigDetailsMessageReceiver>().HasOne(u => u.MessageReceiver).WithMany().HasForeignKey(u => u.MessageReceiverId);

            modelBuilder.Entity<AutoMessageConfigDetailsMessageReceiver>().HasKey(u => new { u.MessageReceiverId, u.AutoMessageConfigDetailsId });

            //AutoMessageConfigDetailsMessageReceiverGroup many-to-many
            modelBuilder.Entity<AutoMessageConfigDetailsMessageReceiverGroup>().Ignore(u => u.Id);
            modelBuilder.Entity<AutoMessageConfigDetailsMessageReceiverGroup>().HasOne(u => u.AutoMessaegConfigDetails).WithMany(u => u.AutoMessageConfigDetailsMessageReceiverGroups).HasForeignKey(u => u.AutoMessageConfigDetailsId);

            modelBuilder.Entity<AutoMessageConfigDetailsMessageReceiverGroup>().HasOne(u => u.MessageReceiveGroup).WithMany().HasForeignKey(u => u.MessageReceiverGroupId);

            modelBuilder.Entity<AutoMessageConfigDetailsMessageReceiverGroup>().HasKey(u => new { u.AutoMessageConfigDetailsId, u.MessageReceiverGroupId });

            //AutoMessageConfigDetailsProvider many-to-many
            modelBuilder.Entity<AutoMessageConfigDetailsProvider>().Ignore(u => u.Id);
            modelBuilder.Entity<AutoMessageConfigDetailsProvider>().HasOne(u => u.AutoMessageConfigDetails).WithMany(u => u.AutoMessageConfigDetailsProviders).HasForeignKey(u => u.AutoMessageConfigDetailsId);

            modelBuilder.Entity<AutoMessageConfigDetailsProvider>().HasOne(u => u.MessageServiceProvider).WithMany().HasForeignKey(u => u.MessageServiceProviderId);

            modelBuilder.Entity<AutoMessageConfigDetailsProvider>().HasKey(u => new { u.AutoMessageConfigDetailsId, u.MessageServiceProviderId });

            //MessageServiceProvider many-to-many
            modelBuilder.Entity<ReceiverProvider>().Ignore(u => u.Id);
            modelBuilder.Entity<ReceiverProvider>().HasOne(u => u.MessageReceiver).WithMany(u => u.ReceiverProviders).HasForeignKey(u => u.MessageReceiverId);

            modelBuilder.Entity<ReceiverProvider>().HasOne(u => u.MessageServiceProvider).WithMany(u => u.ReceiverProviders).HasForeignKey(u => u.MessageServiceProviderId);

            modelBuilder.Entity<ReceiverProvider>().HasKey(u => new { u.MessageServiceProviderId, u.MessageReceiverId });

            //MessageReceiverGroup
            modelBuilder.Entity<MessageReceiverGroupMessageReceiver>().Ignore(u => u.Id);
            modelBuilder.Entity<MessageReceiverGroupMessageReceiver>().HasOne(u => u.MessageReceiverGroup).WithMany(u => u.MessageReceiverGroupMessageReceivers).HasForeignKey(u => u.MessageReceiverGroupId);

            modelBuilder.Entity<MessageReceiverGroupMessageReceiver>().HasOne(u => u.MessageReceiver).WithMany(u => u.MessageReceiverGroupMessageReceivers).HasForeignKey(u => u.MessageReceiverId);

            modelBuilder.Entity<MessageReceiverGroupMessageReceiver>().HasKey(u => new {u.MessageReceiverGroupId, u.MessageReceiverId });

            modelBuilder.Entity<MessageReceiver>().HasOne(u => u.ReceiverCategory).WithMany(u => u.MessageReceivers).HasForeignKey(u => u.ReceiverCategoryId);
            
            modelBuilder.Entity<EmployeeJobRequirement>().HasKey(u => u.JobRequirementId);
            modelBuilder.Entity<EmployeeJobRequirement>().HasKey(u => u.EmployeeJobId);
        }
    }
}