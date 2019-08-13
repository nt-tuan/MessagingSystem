using CleanArchitecture.Core.Entities.Accounts;
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
        #region GetById
        Task<T> GetById<T>(int id) where T : BaseEntity;
        Task<T> GetById<T>(IQueryable<T> query, int id) where T: BaseEntity;
        Task<T> GetById<T>(int id, DateTime? at = null) where T : BaseDetailEntity<T>;
        Task<T> GetById<T>(IQueryable<T> query, int id, DateTime? at) where T: BaseDetailEntity<T>;
        #endregion
        //List
        #region List
        Task<List<T>> List<T>(string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null) where T : BaseEntity;
        
        Task<List<T>> List<T>(string search, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null, DateTime? at = null) where T : BaseDetailEntity<T>;

        Task<List<T>> List<T>(IQueryable<T> query, string search, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null, DateTime? at = null) where T : BaseDetailEntity<T>;
        #endregion
        //Count
        #region Count
        Task<int> Count<T>(dynamic filter) where T : BaseEntity;
        Task<int> Count<T>(IQueryable<T> query, dynamic filter) where T : BaseEntity;
        Task<int> Count<T>(dynamic filter, DateTime? time = null) where T : BaseDetailEntity<T>;
        Task<int> Count<T>(IQueryable<T> query, dynamic filter, DateTime? time = null) where T:BaseDetailEntity<T>;
        #endregion
        //Add
        #region Add
        Task<T> Add<T>(T entity, AppUser appUser) where T : BaseEntity;
        Task<T> AddDetail<T>(T entity, DateTime? at = null, AppUser appUser) where T : BaseDetailEntity<T>;
        #endregion
        //Update
        #region Update
        Task Update<T>(T entity, AppUser appUser) where T : BaseEntity;
        Task UpdateDetail<T>(T entity, DateTime? at = null, AppUser appUser) where T : BaseDetailEntity<T>;
        #endregion
        //Delete
        #region Delete
        Task Delete<T>(T entity, AppUser appUser) where T : BaseEntity;
        Task DeleteDetail<T>(T entity, DateTime? at = null, AppUser appUser) where T : BaseDetailEntity<T>;
        #endregion
    }
}
