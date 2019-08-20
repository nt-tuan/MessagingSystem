using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.SharedKernel;
using CleanArchitecture.Infrastructure.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        void ApplyMeta<T>(T entity, DateTime? at, AppUser user) where T:BaseDetailEntity<T>
        {
            entity.DateCreated = DateTime.Now;
            if (user == null)
                entity.CreatedById = null;
            else
                entity.CreatedById = user.Id;
            entity.DateEffective = at ?? DateTime.Now;
        }

        #region helps
        public IQueryable<T> ApplyFitlerToQuery<T>(dynamic filter, IQueryable<T> query)
        {
            var rs = query;
            if (filter != null)
            {
                var dict = ((object)filter).GetType().GetProperties().ToDictionary(u => u.Name, u => (object)u.GetValue(filter));
                foreach (var item in dict)
                {
                    var value = item.Value;
                    if (value is int)
                    {
                        rs = rs.Where(u => EF.Property<int>(u, item.Key) == (int)value);
                    }
                    else if (value is int?)
                    {
                        rs = rs.Where(u => EF.Property<int>(u, item.Key) == (int?)value);
                    }
                    else if (value is string && !String.IsNullOrEmpty((string)value))
                    {
                        rs = rs.Where(u => EF.Property<string>(u, item.Key).Contains((string)value));
                    }
                    else if (value is bool)
                    {
                        rs = rs.Where(u => EF.Property<bool>(u, item.Key) == (bool)value);
                    }
                    else if (value is DateTime || value is DateTime?)
                    {
                        if (value == null)
                        {
                            rs = rs.Where(u => EF.Property<DateTime>(u, item.Key) == null);
                        }
                        else
                        {
                            var date = (DateTime)value;
                            var beginDate = date.Date;
                            var endDate = beginDate.AddDays(1);
                            rs = rs.Where(u => EF.Property<DateTime>(u, item.Key) >= beginDate && EF.Property<DateTime>(u, item.Key) <= endDate);
                        }
                    }
                }
            }
            return rs;
        }

        public IQueryable<T> ApplyDefaultWhere<T>(IQueryable<T> query, DateTime at) where T : BaseDetailEntity<T>
        {
            var rs = query.Where(u => u.DateEffective <= at && (u.DateEnd == null || u.DateEnd > at));
            return rs;
        }
        public IQueryable<T> ApplyDefaultWhere<T>(IQueryable<T> query, int id, DateTime at) where T : BaseDetailEntity<T>
        {
            var rs = query.Where(u => u.Id == id || u.OriginId == id).Where(u => u.DateEffective <= at && (u.DateEnd == null || u.DateEnd > at));
            return rs;
        }
        public IQueryable<T> ApplyDefaultPaging<T>(IQueryable<T> query, int? page, int? pageRows, string orderby, int? orderdir)
        {
            if (page != null && pageRows != null)
            {
                if (orderdir == null || orderdir == 1)
                    query = query.OrderBy(u => orderby);
                else
                    query = query.OrderByDescending(u => orderby);
                query = query.Take(pageRows.Value).Skip(page.Value * (pageRows.Value));
            }
            return query;
        }
        #endregion
        #region GET
        public async Task<T> GetById<T>(int id) where T : BaseEntity
        {
            var query = _dbContext.Set<T>();
            return await GetById(query, id);
        }

        public async Task<T> GetById<T>(IQueryable<T> query, int id) where T : BaseEntity
        {
            var entity = await query.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            _dbContext.DetachAllEntities();
            return entity;
        }

        public async Task<T> GetById<T>(int id, DateTime? at) where T : BaseDetailEntity<T>
        {
            var query = _dbContext.Set<T>();
            return await GetById(query, id, at ?? DateTime.Now);
        }

        public async Task<T> GetById<T>(IQueryable<T> query, int id, DateTime? at) where T : BaseDetailEntity<T>
        {
            query = ApplyDefaultWhere(query, at ?? DateTime.Now);
            var entity = await query.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id || e.OriginId == id);
            _dbContext.DetachAllEntities();
            return entity;
        }
        #endregion
        #region LIST
        public async Task<List<T>> List<T>() where T : BaseEntity
        {
            var list = await _dbContext.Set<T>().AsNoTracking().ToListAsync();
            _dbContext.DetachAllEntities();
            return list;
        }

        public async Task<List<T>> List<T>(string search, int? page, int? pageRows, string orderby, int? orderdir, dynamic filter) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();
            return await List(query, search, page, pageRows, orderby, orderdir, filter);
        }

        public async Task<List<T>> List<T>(IQueryable<T> query, string search, int? page, int? pageRows, string orderby, int? orderdir, dynamic filter) where T : BaseEntity
        {
            query = query.AsNoTracking();
            query = ApplyFitlerToQuery<T>(filter, query);
            query = ApplyDefaultPaging<T>(query, page, pageRows, orderby, orderdir);

            var list = await query.ToListAsync();
            _dbContext.DetachAllEntities();
            return list;
        }

        public async Task<List<T>> List<T>(string search, int? page, int? pageRows, string orderby, int? orderdir, dynamic filter, DateTime? at) where T : BaseDetailEntity<T>
        {
            var query = _dbContext.Set<T>().AsQueryable<T>();
            return await List(query, search, page, pageRows, orderby, orderdir, filter, at);
        }

        public async Task<List<T>> List<T>(IQueryable<T> query, string search, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = 1, dynamic filter = null, DateTime? at = null) where T : BaseDetailEntity<T>
        {
            query = query.AsNoTracking();
            query = ApplyFitlerToQuery<T>(filter, query);
            query = ApplyDefaultWhere<T>(query, at ?? DateTime.Now);
            query = ApplyDefaultPaging<T>(query, page, pageRows, orderby, orderdir);
            var list = await query.ToListAsync();
            _dbContext.DetachAllEntities();
            return list;
        }
        #endregion
        public async Task<T> Add<T>(T entity, AppUser user) where T : BaseEntity
        {
            entity.CreatedById = user.Id;
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update<T>(T entity, AppUser appUser) where T : BaseEntity
        {
            entity.CreatedById = appUser.Id;
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }


        #region Count
        public async Task<int> Count<T>(dynamic filter) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();
            var count = await Count(query, filter);
            return count;
        }

        public async Task<int> Count<T>(IQueryable<T> query, dynamic filter) where T : BaseEntity
        {
            query = query.AsNoTracking();
            query = ApplyFitlerToQuery<T>(filter, query);
            var count = await query.CountAsync();
            return count;
        }

        public async Task<int> Count<T>(dynamic filter, DateTime? at) where T : BaseDetailEntity<T>
        {
            var query = _dbContext.Set<T>().AsQueryable();
            return await Count(query, filter, at);
        }


        public async Task<int> Count<T>(IQueryable<T> query, dynamic filter, DateTime? at = null) where T : BaseDetailEntity<T>
        {
            query = query.AsNoTracking();
            query = ApplyDefaultWhere<T>(query, at ?? DateTime.Now);
            query = ApplyFitlerToQuery<T>(filter, query);
            return await query.CountAsync();
        }
        #endregion

        public async Task<T> AddDetail<T>(T entity, DateTime? at, AppUser user) where T : BaseDetailEntity<T>
        {
            entity.OriginId = null;
            entity.DateCreated = DateTime.Now;
            entity.DateEffective = at ?? DateTime.Now;
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateDetail<T>(T entity, DateTime? at, AppUser appUser) where T : BaseDetailEntity<T>
        {
            at = at ?? DateTime.Now;
            var current = await GetById<T>(entity.OriginId??entity.Id, at);
            entity.OriginId = current.OriginId ?? current.Id;
            entity.Id = 0;
            current.DateEnd = DateTime.Now;
            current.DateReplaced = DateTime.Now;
            ApplyMeta(entity, at, appUser);
            _dbContext.Set<T>().Update(current);
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete<T>(T entity, AppUser user) where T : BaseEntity
        {
            var current = await GetById<T>(entity.Id);
            current.RemovedById = user.Id;
            current.DateRemoved = DateTime.Now;
            _dbContext.Set<T>().Update(current);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDetail<T>(T entity, DateTime? at = null, AppUser appUser = null) where T : BaseDetailEntity<T>
        {
            at = at ?? DateTime.Now;
            var current = await GetById<T>(entity.Id, at);
            current.DateEnd = at;
            current.DateRemoved = DateTime.Now;
            current.RemovedById = appUser.Id;
            _dbContext.Set<T>().Update(current);
            await _dbContext.SaveChangesAsync();
        }
    }
}
