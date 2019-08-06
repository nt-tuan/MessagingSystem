using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.SharedKernel;
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

        public async Task<T> GetById<T>(int id) where T : BaseEntity
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<T>> List<T>() where T : BaseEntity
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

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

        public async Task<T> GetById<T>(int id, DateTime time) where T : BaseDetailEntity
        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(u => u.DateEffective <= time && (u.Id == id || u.OriginId == id) && (u.DateEnd == null || u.DateEnd > time));
            return entity;
        }

        public async Task<List<T>> List<T>(string search, int? page, int? pageRows, string orderby, int? orderdir, dynamic filter) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();
            
            return await query.ToListAsync();
        }

        public async Task<List<T>> List<T>(string search, int? page, int? pageRows, string orderby, int? orderdir, dynamic filter, DateTime? at) where T : BaseDetailEntity
        {
            var query = _dbContext.Set<T>().AsQueryable<T>();
            query = ApplyFitlerToQuery<T>(filter, query);
            at = at?? DateTime.Now;
            query = query.Where(u => u.DateEffective <= at && (u.DateEnd == null || u.DateEnd >=at));
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
                    else if(value is int?)
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

        public int Count<T>(Dictionary<string, string> filter) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public int Count<T>(Dictionary<string, string> filter, DateTime time) where T : BaseDetailEntity
        {
            throw new NotImplementedException();
        }

        public T AddDetail<T>(T entity) where T : BaseDetailEntity
        {
            throw new NotImplementedException();
        }

        public void Update<T>(int id) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void UpdateDetail<T>(int id) where T : BaseDetailEntity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(int id) where T : BaseDetailEntity
        {
            throw new NotImplementedException();
        }

        public void DeleteDetail<T>(int id) where T : BaseDetailEntity
        {
            throw new NotImplementedException();
        }
    }
}
