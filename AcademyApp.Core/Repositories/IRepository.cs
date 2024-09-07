﻿using AcademyApp.Core.Entities.Common;
using System.Linq.Expressions;

namespace AcademyApp.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetEntity(Expression<Func<T, bool>> predicate = null, params string[] includes);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null, params string[] includes);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> IsExist(Expression<Func<T, bool>> predicate = null);
        Task Commit();
    }
}
