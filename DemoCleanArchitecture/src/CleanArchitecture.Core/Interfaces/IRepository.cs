using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IRepository
    {
        //Get by Id
        //Task<T> GetById<T>(IQueryable<T> query, int id) where T : BaseEntity;
        //Task<T> GetById<T>(IQueryable<T> query, int id, DateTime? at = null) where T: BaseDetailEntity;
        Task<T> GetById<T>(int id) where T : BaseEntity;
        Task<T> GetById<T>(int id, DateTime? at = null) where T : BaseDetailEntity;
        //List

        //Task<List<T>> List<T>(IQueryable<T> query, string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null) where T : BaseEntity;

        Task<List<T>> List<T>(string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null) where T : BaseEntity;

        //Task<List<T>> List<T>(IQueryable query, string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null, DateTime? at = null) where T : BaseDetailEntity;

        Task<List<T>> List<T>(string search, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null, DateTime? at = null) where T : BaseDetailEntity;

        //Count
        Task<int> Count<T>(dynamic filter) where T : BaseEntity;
        Task<int> Count<T>(dynamic filter, DateTime? time = null) where T : BaseDetailEntity;

        //Add
        Task<T> Add<T>(T entity) where T : BaseEntity;
        Task<T> AddDetail<T>(T entity, DateTime? at = null) where T : BaseDetailEntity;

        //Update
        Task Update<T>(T entity) where T : BaseEntity;
        Task UpdateDetail<T>(T entity, DateTime? at = null) where T : BaseDetailEntity;

        //Delete
        Task Delete<T>(T entity) where T : BaseEntity;
        Task DeleteDetail<T>(T entity, DateTime? at = null) where T : BaseDetailEntity;
    }
}
