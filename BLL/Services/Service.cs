using AutoMapper;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services
{
    public class Service<TEntity, UEntity, YEntity> : IService<UEntity, YEntity>
         where TEntity : Entity
         where UEntity : ViewModel
         where YEntity : CreateModel
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        public Service(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task Create(YEntity entity)
        { 
            await _repository.Create(_mapper.Map<TEntity>(entity));
        }

        public virtual async Task Delete(Guid id)
        { 
            await _repository.Delete(id);
        }

        public virtual async Task<List<UEntity>> GetAll()
        {
            var query = _repository.GetAll();
            var entities = await query.ToListAsync();
            return entities.Select(_mapper.Map<UEntity>).ToList();
        }

        public virtual async Task<UEntity> Get(Guid id)
        {
            var entity = await _repository.Get(id);
            return _mapper.Map<UEntity>(entity);
        }

        public virtual async Task Update(YEntity entity)
        {
            await _repository.Update(_mapper.Map<TEntity>(entity));
        }

        public string GetKey(string id)
        {
            return typeof(UEntity) + "_" + id;
        }
    }
}
