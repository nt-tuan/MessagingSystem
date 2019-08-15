using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanArchitecture.Tests.Integration.Data
{
    public class CoreRepositoryShould
    {
        private AppDbContext _db;
        private static DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("cleararchitecture").UseInternalServiceProvider(serviceProvider);
            return builder.Options;
        }

        [Fact]
        public void AddEmployeeAndSetId()
        {
            //import from excel files
        }

        private EfRepository GetRepository()
        {
            var options = CreateNewContextOptions();
            var mockDispatcher = new Mock<IDomainEventDispatcher>();

            _db = new AppDbContext(options, mockDispatcher.Object);
            return new EfRepository(_db);
        }
    }
}
