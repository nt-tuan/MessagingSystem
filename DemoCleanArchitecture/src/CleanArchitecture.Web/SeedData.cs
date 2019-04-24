using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;
using System.Linq;

namespace CleanArchitecture.Web
{
    public static class SeedData
    {
        public static void PopulateInitData(AppDbContext dbContext)
        {
            if (!dbContext.ReceiverCategory.ToList().Any())
            {
                dbContext.ReceiverCategory.Add(new Core.Entities.SMS.ReceiverCategory
                {
                    Code = "E",
                    Name = "Nhân viên"
                });
                dbContext.ReceiverCategory.Add(new Core.Entities.SMS.ReceiverCategory
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
