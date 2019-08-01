using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(int id) where T : BaseEntity
        {

            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public List<T> List<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public T GetById<T>(int id, DateTime time) where T : BaseDetailEntity
        {
            var entity = _dbContext.Set<T>().FirstOrDefault(u => u.DateEffective <= time && (u.Id == id || u.OriginId == id) && (u.DateEnd == null || u.DateEnd > time));
            return entity;
        }

        public List<T> List<T>(string search, int? page, int? pageRows, string orderby, int? orderdir, IDictionary<string, string> filter) where T : BaseEntity
        {
            var query = _dbContext.Set<T>();
            if (filter != null)
            {
                foreach (var item in filter)
                {
                    
                }
            }
            
        }

        public List<T> List<T>(string search, int? page, int? pageRows, string orderby, int? orderdir, IDictionary<string, string> filter, DateTime time) where T : BaseDetailEntity
        {
            throw new NotImplementedException();
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
