using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;
using System.Linq;

namespace CleanArchitecture.Web
{
    public static class SeedData
    {
        public static void PopulateInitData(AppDbContext dbContext)
        {
            if (!dbContext.ReceiverCategories.ToList().Any())
            {
                dbContext.ReceiverCategories.Add(new Core.Entities.Messaging.ReceiverCategory
                {
                    Code = "E",
                    Name = "Nhân viên"
                });
                dbContext.ReceiverCategories.Add(new Core.Entities.Messaging.ReceiverCategory
                {
                    Code = "C",
                    Name = "Khách hàng"
                });
                dbContext.SaveChanges();
            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            
        }

    }
}
