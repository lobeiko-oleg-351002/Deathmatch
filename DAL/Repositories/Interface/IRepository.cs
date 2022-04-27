using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IRepository<TEntity>
        where TEntity : Entity

    {
        Task Create(TEntity entity);

        IQueryable<TEntity> GetAll();

        Task<TEntity> Get(Guid id);

        Task Delete(Guid id);

        Task Update(TEntity entity);
    }
}
