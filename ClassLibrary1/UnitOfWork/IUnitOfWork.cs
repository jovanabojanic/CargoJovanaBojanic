using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository GenericRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
