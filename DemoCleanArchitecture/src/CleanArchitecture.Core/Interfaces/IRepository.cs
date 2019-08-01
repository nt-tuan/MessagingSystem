using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : BaseEntity;
        T GetById<T>(int id, DateTime time) where T : BaseDetailEntity;
        List<T> List<T>() where T : BaseEntity;
        List<T> List<T>(string search, int? page, int? pageRows, string orderby, int? orderdir, IDictionary<string, string> filter) where T : BaseEntity;
        List<T> List<T>(string search, int? page, int? pageRows, string orderby, int? orderdir, IDictionary<string, string> filter, DateTime time) where T : BaseDetailEntity;
        int Count<T>(Dictionary<string, string> filter) where T : BaseEntity;
        int Count<T>(Dictionary<string, string> filter, DateTime time) where T : BaseDetailEntity;
        T Add<T>(T entity) where T : BaseEntity;
        T AddDetail<T>(T entity) where T : BaseDetailEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Update<T>(int id) where T : BaseEntity;
        void UpdateDetail<T>(int id) where T : BaseDetailEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        void Delete<T>(int id) where T : BaseDetailEntity;
        void DeleteDetail<T>(int id) where T : BaseDetailEntity;
    }
}
