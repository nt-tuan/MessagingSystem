using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.Entities.Articles;

namespace CleanArchitecture.Core.Entities.SupportRequests
{
    public class SupportRequest
    {
        public static readonly string[] STATUS_COLLECTION = { "Yêu cầu", "Chấp nhận yêu cầu", "Xử lí yêu cầu", "Hoàn thành yêu cầu", "Người dùng nghiệm thu" };

        public string Request { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string Solution { get; set; }
        public string DenyNote { get; set; }
        public string ConfirmFinishCode { get; set; }

        public DateTime CreateTime { get; set; }

        public int OwnerId { get; set; }

        public Employee Owner { get; set; }

        public int? CreatedById { get; set; }

        public Employee CreatedBy { get; set; }

        public int? ReferenceId { get; set; }

        public Page Reference { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        public int? AssignedById { get; set; }

        public Employee AssignedBy { get; set; }


        public int? CurrentRequestActionId { get; set; }

        public RequestProcessAction CurrentRequestAction { get; set; }


        public ICollection<RequestProcessAction> RequestProcessActions { get; set; }
        /*
        //Create a support request by anonoymous user
        public static async Task<SupportRequest> CreateByAnonymouse(ApplicationDbContext context, string email, string content)
        {
            var sp = new SupportRequest
            {
                Request = content,
                Email = email,
                Status = REQUEST,
                CreateTime = DateTime.Now
            };
            context.SupportRequests.Add(sp);
            await context.SaveChangesAsync();
            return sp;
        }

        public static async Task<SupportRequest> Create(ApplicationDbContext context, AppUser by, AppUser to, string content)
        {
            var sp = new SupportRequest
            {
                Request = content,
                Email = to.Email,
                Status = REQUEST,
                CreateTime = DateTime.Now,
                CreatedBy = by.Employee,
                RequestTo = to.Employee
            };
            context.SupportRequests.Add(sp);
            await context.SaveChangesAsync();
            return sp;
        }

        //A support request is accept by it-support user
        public static async Task<SupportRequest> AcceptRequest(ApplicationDbContext context, AppUser by, int id)
        {
            var sp = await GetEntity(context, id);
            if (sp.Status != REQUEST)
                throw new EntityNotAllowUpdate();
            if (sp.RequestTo != null && sp.RequestTo.Id != by.Employee.Id)
                throw new EntityNotAllowUpdate();
            sp.ProcessBy = by.Employee;
            sp.Status = BEGINPROCESSING;
            sp.ProcessTime = DateTime.Now;
            sp.ProcessBy = by.Employee;
            context.Update(sp);
            await context.SaveChangesAsync();
            return sp;
        }

        //A support request is cancel by it-support user
        public static async Task<SupportRequest> CancelRequest(ApplicationDbContext context, AppUser by, SupportRequest sp, string note)
        {
            if(sp.Status == DONE)
            {
                throw new EntityNotAllowUpdate();
            }
            sp.DenyNote = note;
            sp.CancelTime = DateTime.Now;
            sp.CancelBy = by.Employee;
            sp.Status = CANCEL;
            context.Update(sp);
            await context.SaveChangesAsync();
            return sp;
        }

        public static async Task<SupportRequest> DeclineRequest(ApplicationDbContext context, SupportRequest sr)
        {
            if (sr.Status == DONE || sr.Status == REQUEST || sr.Status == CANCEL)
                throw new EntityNotAllowUpdate();
            sr.Status = REQUEST;
            sr.ProcessBy = null;
            sr.ProcessTime = null;
            sr.Solution = null;
            sr.FinishTime = null;
            sr.DoneTime = null;
            context.Update(sr);
            await context.SaveChangesAsync();
            return sr;
        }

        public static async Task<SupportRequest> StartProcess(ApplicationDbContext context, int id)
        {
            var sp = await GetEntity(context, id);
            if (sp.Status != BEGINPROCESSING)
                throw new EntityNotAllowUpdate();
            sp.Status = PROCESSING;
            sp.ProcessTime = DateTime.Now;
            context.Update(sp);
            await context.SaveChangesAsync();
            return sp;
        }

        //Stop a working process
        public static async Task<SupportRequest> StopProcessing(ApplicationDbContext context, int id)
        {
            var sp = await GetEntity(context, id);
            if (sp.Status < PROCESSING || sp.Status > FINISH)
                throw new EntityNotAllowUpdate();
            sp.Status = BEGINPROCESSING;
            context.Update(sp);
            await context.SaveChangesAsync();
            return sp;
        }

        public static async Task<SupportRequest> FinishProcessing(ApplicationDbContext context, SupportRequest sp)
        {
            if (sp.Status != PROCESSING)
                throw new EntityNotAllowUpdate();
            sp.Status = FINISH;
            sp.FinishTime = DateTime.Now;
            //generate code
            do
            {
                var str = Helper.UtilityHelper.GetRandomString(24);
                sp.ConfirmFinishCode = str;
            } while (await context.SupportRequests.Where(u => u.ConfirmFinishCode == sp.ConfirmFinishCode).CountAsync() > 0);
            
            //
            context.Update(sp);
            await context.SaveChangesAsync();
            return sp;
        }

        public static async Task<SupportRequest> ConfirmFinish(ApplicationDbContext context, string code)
        {
            var sp = await context.SupportRequests.Include(u => u.ProcessBy).Where(u => u.ConfirmFinishCode == code).FirstOrDefaultAsync();
            if (sp == null)
                return sp;
            if (sp.Status != FINISH)
                throw new EntityNotAllowUpdate();
            if (sp.ConfirmFinishCode != code)
                throw new EntityNotAllowUpdate();
            sp.Status = DONE;
            sp.DoneTime = DateTime.Now;
            context.Update(sp);
            await context.SaveChangesAsync();
            return sp;
        }

        public static async Task<SupportRequest> GetEntity(ApplicationDbContext context, int id)
        {
            var sp = await context.SupportRequests.FindAsync(id);
            if (sp == null)
                throw new EntityNotFoundException();
            return sp;
        }

        public static async Task<List<SupportRequest>> GetSupportRequest(ApplicationDbContext context)
        {
            return await context.SupportRequests.Where(u => u.Status != SupportRequest.DONE && u.Status != SupportRequest.CANCEL).ToListAsync();
        }
        */
    }
}
