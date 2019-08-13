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
using CleanArchitecture.Infrastructure.Data.EntityConfigurations;
using CleanArchitecture.Core.Entities.Core;

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
        //Core module
        public DbSet<Core.Entities.Core.Business> Businesses { get; set; }
        public DbSet<Core.Entities.Core.Person> People { get; set; }
        public DbSet<Core.Entities.Core.Country> Countries { get; set; }

        //Messaging Module
        public DbSet<AutoMessageConfig> AutoMessageConfigs { get; set; }
        public DbSet<AutoMessageConfigMessageReceiver> AutoMesasgeConfigMessageReceivers { get; set; }
        public DbSet<AutoMessageConfigMessageReceiverGroup> AutoMessageConfigMessageReceiverGroups { get; set; }
        public DbSet<AutoMessageConfigProvider> AutoMessageConfigProviders { get; set; }
        public DbSet<MessageReceiver> MessageReceivers { get; set; }
        public DbSet<MessageReceiverGroup> MessageReceiverGroups { get; set; }
        public DbSet<MessageReceiverGroupMessageReceiver> MessageReceiverGroupMessageReceivers { get; set; }
        public DbSet<MessageServiceProvider> MessageServiceProviders { get; set; }
        public DbSet<ReceiverCategory> ReceiverCategories { get; set; }
        public DbSet<ReceiverProvider> ReceiverProviders { get; set; }
        public DbSet<SentMessage> SentMessages { get; set; }


        //Customer
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Distributor> Distributors { get; set; }

        //public DbSet<MessageReceiverGroup> MessageReceiverGroups { get; set; }
        //public DbSet<MessageServiceProvider> MessageServiceProviders { get; set; }
        //public DbSet<ReceiverProvider> ReceiverProviders { get; set; }
        //public DbSet<SentMessage> SentMessages { get; set; }

        //HR Module
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTitle> EmployeeTitles { get; set; }
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
            //apply version control constraints
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<Person>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<Business>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<Employee>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<Department>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<Distributor>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<Customer>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<AutoMessageConfig>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<AutoMessageConfigMessageReceiver>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<AutoMessageConfigMessageReceiverGroup>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<AutoMessageConfigProvider>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<MessageReceiver>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<MessageReceiverGroup>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<MessageReceiverGroupMessageReceiver>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<MessageServiceProvider>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<ReceiverCategory>());
            modelBuilder.ApplyConfiguration(new BaseDetailConfiguration<ReceiverProvider>());

            //apply core module constraint
            var coreConf = new CoreConfiguration();
            modelBuilder.ApplyConfiguration<Person>(coreConf);
            modelBuilder.ApplyConfiguration<Business>(coreConf);
            
            var hrConf = new HRConfiguration();
            modelBuilder.ApplyConfiguration<Employee>(hrConf);
            modelBuilder.ApplyConfiguration<Department>(hrConf);
            
            var saleConf = new SaleConfiguration();
            modelBuilder.ApplyConfiguration<Distributor>(saleConf);
            modelBuilder.ApplyConfiguration<Customer>(saleConf);
            
            /*
            var messagingConf = new MessagingConfiguration();
            modelBuilder.ApplyConfiguration<AutoMessageConfig>(messagingConf);
            modelBuilder.ApplyConfiguration<AutoMessageConfigMessageReceiver>(messagingConf);
            modelBuilder.ApplyConfiguration<AutoMessageConfigMessageReceiverGroup>(messagingConf);
            modelBuilder.ApplyConfiguration<AutoMessageConfigProvider>(messagingConf);

            var receiverConf = new MessageReceiverConfiguration();
            modelBuilder.ApplyConfiguration<MessageReceiverGroupMessageReceiver>(receiverConf);
             modelBuilder.ApplyConfiguration<ReceiverProvider>(receiverConf);
             */
        }
    }
}