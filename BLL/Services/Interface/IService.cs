using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services.Interface
{
    public interface IService<TEntity, UEntity>
        where TEntity : ViewModel
        where UEntity : CreateModel
    {
        Task Create(UEntity entity);

        Task<List<TEntity>> GetAll();

        Task<TEntity> Get(Guid id);

        Task Delete(Guid id);

        Task Update(UEntity entity);

        public string GetKey(string id);
    }
}
