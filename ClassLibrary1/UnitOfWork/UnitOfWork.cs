using Core.Common;
using Models.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductCategoryDbContext _context;
        public IGenericRepository GenericRepository { get; }

        public UnitOfWork(ProductCategoryDbContext context, IGenericRepository genericRepository)
        {
            _context = context;
            GenericRepository = genericRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
