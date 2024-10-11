using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public interface IGenericRepository
    {
        public Task<List<T>> GetAll<T>(params Expression<Func<T, object>>[] includes) where T : class;
        public Task<T> GetById<T>(object id, params Expression<Func<T, object>>[] children) where T : class;
        public Task<List<T>> GetByFilter<T>(Expression<Func<T, bool>> filter) where T : class;
        public Task<T> CreateOne<T>(T one) where T : class;
        public Task<T> UpdateById<T, U>(object id, U one)
            where T : class
            where U : class;
        public Task<T> DeleteById<T>(object id) where T : class;
        public Task<T> DeleteByObjEquality<T>(object obj) where T : class;
        public Task<int> SaveChanges();
        public Task ReloadEntities<T>(List<T> entities) where T : class;
        public Task<T> DetachById<T>(object id) where T : class;
        public void DetachEntities<T>(List<T> entities) where T : class;
        Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);
    }
}