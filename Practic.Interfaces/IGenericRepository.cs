using Practic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Interfaces
{
   public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity Find(int id);
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        void Delete(TEntity item);
        void Update(TEntity item);
    }
}
