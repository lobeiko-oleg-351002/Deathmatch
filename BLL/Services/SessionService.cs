using AutoMapper;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services
{
    public class SessionService : Service<Session, SessionViewModel, SessionCreateModel>, ISessionService
    {
        private readonly IUserInSessionRepository _userInSessionRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        public SessionService(ISessionRepository SessionRepository, IUserInSessionRepository userInSessionRepository, IUserRepository UserRepository,
            ILocationRepository Locationepository, IMapper mapper)
            : base(SessionRepository, mapper)
        {
            _userInSessionRepository = userInSessionRepository;
            _userRepository = UserRepository;
            _locationRepository = Locationepository;
        }

        public override async Task<SessionViewModel> Get(Guid id)
        {
            var entity = await base.Get(id);
            entity.CurrentPlayerCount = await (_repository as ISessionRepository).GetCurrentPlayerCountInSession(id);
            return entity;
        }

        public override async Task<List<SessionViewModel>> GetAll()
        {
            var entities = await base.GetAll();
            foreach (var entity in entities)
            {
                entity.CurrentPlayerCount = await (_repository as ISessionRepository).GetCurrentPlayerCountInSession(entity.Id);
            }
            return entities;
        }

        public override async Task Create(SessionCreateModel entity)
        {
            var dalEntity = _mapper.Map<Session>(entity);
            
            dalEntity.Host = await _userRepository.Get(dalEntity.Host.Id);
            dalEntity.Level = await _locationRepository.Get(dalEntity.Level.Id);
            var sessionId = await (_repository as ISessionRepository).Create(dalEntity);
            var hostInSession = new UserInSession { User = dalEntity.Host, Session = await _repository.Get(sessionId) };
            await _userInSessionRepository.Create(hostInSession);
        }

        public async Task RemoveUserFromSession(UserViewModel user, SessionViewModel session)
        {
            await _userInSessionRepository.RemoveByUserId(user.Id);
            if (session.Host.Equals(user))
            {
                await _repository.Delete(session.Id);
            }
        }
    }
}
