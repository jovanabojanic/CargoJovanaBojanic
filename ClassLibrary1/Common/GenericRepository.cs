using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Models.DbContexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ProductCategoryDbContext _context;

        public GenericRepository(ProductCategoryDbContext dbContext)
        {
            _context = dbContext;
        }

        public Task<List<T>> GetAll<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            try
            {
                DbSet<T> table = _context.Set<T>();

                foreach (var inclusion in includes)
                {
                    table.Include(inclusion).Load();
                }

                return table.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"[Error] GetAll entities. Message: {ex.Message}", ex);
            }
        }

        public async Task<T> GetById<T>(object id, params Expression<Func<T, object>>[] includes) where T : class
        {
            T existing;
            DbSet<T> table = _context.Set<T>();

            foreach (var inclusion in includes)
            {
                table.Include(inclusion).Load();
            }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            existing = await table.FindAsync(id).ConfigureAwait(false);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existing == null)
                throw new ArgumentNullException(nameof(id), "[Error] GetById null entity.");

            return existing;
        }

        public async Task<List<T>> GetByFilter<T>(Expression<Func<T, bool>> filter) where T : class
        {
            DbSet<T> table = _context.Set<T>();

            return filter == null ? await table.ToListAsync().ConfigureAwait(false) : await table.Where(filter).ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> CreateOne<T>(T one) where T : class
        {
            if (one == null)
                throw new ArgumentNullException(nameof(one), "[Error] Insert null entity.");

            DbSet<T> table = _context.Set<T>();

            await table.AddAsync(one).ConfigureAwait(false);

            return one;
        }

        public async Task<T> UpdateById<T, U>(object id, U one)
            where T : class
            where U : class
        {
            T existing;

            DbSet<T> table = _context.Set<T>();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            existing = await table.FindAsync(id).ConfigureAwait(false);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existing is null)
            {
                throw new ArgumentNullException(nameof(id), "[Error] Update null entity.");
            }

            existing = UpdateObjectProperties<T, U>(existing, one);

            return existing;
        }

        public async Task<T> DetachById<T>(object id)
            where T : class
        {

            T existing;

            DbSet<T> table = _context.Set<T>();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            existing = await table.FindAsync(id).ConfigureAwait(false);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existing is null)
            {
                throw new ArgumentNullException(nameof(id), "[Error] Entity not found for detaching.");
            }

            _context.Entry(existing).State = EntityState.Detached;

            return existing;
        }

        public void DetachEntities<T>(List<T> entities)
            where T : class
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
        }

        private T UpdateObjectProperties<T, U>(T dest, U src)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            List<PropertyInfo> properties = src.GetType().GetProperties().ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            // Provera da li je polje null ili ako tip implementira ICollection (ovo je potrebno kako ne bi pregazio vezanu listu objekata u tabeli)
            List<PropertyInfo> notNullProperties = properties
                .FindAll(p => p.GetValue(src) is not null &&
                p.PropertyType.IsAssignableTo(typeof(ICollection)) is false);

            foreach (PropertyInfo item in notNullProperties)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                dest.GetType().GetProperty(item.Name).SetValue(dest, item.GetValue(src));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            return dest;
        }

        public async Task<T> DeleteById<T>(object id) where T : class
        {
            T existing;

            DbSet<T> table = _context.Set<T>();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            existing = await table.FindAsync(id).ConfigureAwait(false);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existing is null)
            {
                throw new ArgumentNullException(nameof(id), "[Error] Delete null entity.");
            }

            table.Remove(existing);

            return existing;
        }

        public async Task<T> DeleteByObjEquality<T>(object obj) where T : class
        {
            T existing;

            DbSet<T> table = _context.Set<T>();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            existing = await table.FirstOrDefaultAsync(item => item.Equals(obj)).ConfigureAwait(false);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (existing is null)
            {
                throw new ArgumentNullException(nameof(obj), "[Error] Delete null entity.");
            }

            table.Remove(existing);

            return existing;
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Explicitly tells EF Core to load given entities directly from database
        /// instead of in-memory cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task ReloadEntities<T>(List<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                await _context.Entry(entity).ReloadAsync().ConfigureAwait(false);
            }
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == categoryId))
                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsByPriceRange(decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.Products.AsQueryable();

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            return await query.ToListAsync();
        }

    }
}