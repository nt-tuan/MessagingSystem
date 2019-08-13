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
        #endregion
        #region GET
        public async Task<T> GetById<T>(int id) where T : BaseEntity
        {
            var query = _dbContext.Set<T>();
            return await GetById(query, id);
        }

        public async Task<T> GetById<T>(IQueryable<T> query, int id) where T : BaseEntity
        {
            return await query.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<T> GetById<T>(int id, DateTime? at) where T : BaseDetailEntity<T>
        {
            var query = _dbContext.Set<T>();
            return await GetById(query, id, at ?? DateTime.Now);
        }

        public async Task<T> GetById<T>(IQueryable<T> query, int id, DateTime? at) where T : BaseDetailEntity<T>
        {
            query = ApplyDefaultWhere(query, at ?? DateTime.Now);
            return await query.SingleOrDefaultAsync(e => e.Id == id);
        }
        #endregion
        #region LIST
        public async Task<List<T>> List<T>() where T : BaseEntity
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> List<T>(string search, int? page, int? pageRows, string orderby, int? orderdir, dynamic filter) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();
            return await List(query, search, page, pageRows, orderby, orderdir, filter);
        }

        public async Task<List<T>> List<T>(IQueryable<T> query, string search, int? page, int? pageRows, string orderby, int? orderdir, dynamic filter) where T : BaseEntity
        {
            query = ApplyFitlerToQuery<T>(filter, query);
            if (page != null && pageRows != null)
            {
                if (orderdir == null || orderdir == 1)
                    query = query.OrderBy(u => orderby);
                else
                    query = query.OrderByDescending(u => orderby);
                query = query.Take(pageRows.Value).Skip(page.Value * (pageRows.Value - 1));
            }
            var list = await query.ToListAsync();
            return list;
        }

        public async Task<List<T>> List<T>(string search, int? page, int? pageRows, string orderby, int? orderdir, dynamic filter, DateTime? at) where T : BaseDetailEntity<T>
        {
            var query = _dbContext.Set<T>().AsQueryable<T>();
            return await List(query, search, page, pageRows, orderby, orderdir, filter);
        }

        public async Task<List<T>> List<T>(IQueryable<T> query, string search, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = 1, dynamic filter = null, DateTime? at = null) where T : BaseDetailEntity<T>
        {
            query = ApplyFitlerToQuery<T>(filter, query);
            query = ApplyDefaultWhere<T>(query, at ?? DateTime.Now);
            if (page != null && pageRows != null)
            {
                if (orderdir == null || orderdir == 1)
                    query = query.OrderBy(u => orderby);
                else
                    query = query.OrderByDescending(u => orderby);
                query = query.Take(pageRows.Value).Skip(page.Value * (pageRows.Value - 1));
            }
            var list = await query.ToListAsync();
            return list;
        }
        #endregion
        public async Task<T> Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


        #region Count
        public async Task<int> Count<T>(dynamic filter) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();
            query = ApplyFitlerToQuery<T>(filter, query);
            var count = await query.CountAsync();
            return count;
        }

        public async Task<int> Count<T>(IQueryable<T> query, dynamic filter) where T : BaseEntity
        {
            query = ApplyFitlerToQuery<T>(filter, query);
            var count = await query.CountAsync();
            return count;
        }

        public async Task<int> Count<T>(dynamic filter, DateTime? at) where T : BaseDetailEntity<T>
        {
            var query = _dbContext.Set<T>().AsQueryable();
            return await Count(query, filter, at);
        }
#endregion

        public async Task<int> Count<T>(IQueryable<T> query, dynamic filter, DateTime? at = null) where T : BaseDetailEntity<T>
        {
            query = ApplyDefaultWhere<T>(_dbContext.Set<T>().AsQueryable(), at ?? DateTime.Now);
            query = ApplyFitlerToQuery<T>(query, filter);
            return await query.CountAsync();
        }

        public async Task<T> AddDetail<T>(T entity, DateTime? at) where T : BaseDetailEntity<T>
        {
            entity.OriginId = null;
            entity.DateCreated = DateTime.Now;
            entity.DateEffective = at ?? DateTime.Now;
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateDetail<T>(T entity, DateTime? at) where T : BaseDetailEntity<T>
        {
            at = at ?? DateTime.Now;
            var current = await GetById<T>(entity.Id, at);
            entity.OriginId = current.OriginId ?? current.Id;
            current.DateEnd = DateTime.Now;
            current.DateReplaced = DateTime.Now;
            entity.DateEffective = at ?? DateTime.Now;
            entity.DateCreated = DateTime.Now;
            _dbContext.Set<T>().Update(current);
            _dbContext.Set<T>().Add(current);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete<T>(int id) where T : BaseDetailEntity<T>
        {
            var current = await GetById<T>(id);
            _dbContext.Set<T>().Remove(current);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDetail<T>(T entity, DateTime? at = null) where T : BaseDetailEntity<T>
        {
            at = at ?? DateTime.Now;
            var current = await GetById<T>(entity.Id, at);
            current.DateEnd = at;
            _dbContext.Set<T>().Update(current);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetById<T>(IQueryable<T> query, int id) where T : BaseEntity
        {
            var entity = await query.SingleOrDefaultAsync(u => u.Id == id);
            return entity;
        }

        public async Task<T> GetById<T>(IQueryable<T> query, int id, DateTime? at = null) where T : BaseDetailEntity
        {
            var q = ApplyDefaultWhere<T>(query.Where(u => u.Id == id || u.OriginId == id), at ?? DateTime.Now);
            var entity = await q.SingleOrDefaultAsync();
            return entity;
        }

        public Task<List<T>> List<T>(IQueryable<T> query, string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = 1, dynamic filter = null) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> List<T>(IQueryable query, string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = 1, dynamic filter = null, DateTime? at = null) where T : BaseDetailEntity
        {
            throw new NotImplementedException();
        }


    }
}
