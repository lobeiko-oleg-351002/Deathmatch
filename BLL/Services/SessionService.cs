using AutoMapper;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using Models;
using System;
using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services
{
    public class SessionService : Service<Session, SessionViewModel, SessionCreateModel>, ISessionService
    {
        private readonly IUserInSessionRepository _userInSessionRepository;
        public SessionService(ISessionRepository SessionRepository, IUserInSessionRepository userInSessionRepository, IMapper mapper)
            : base(SessionRepository, mapper)
        {
            _userInSessionRepository = userInSessionRepository;
        }

        public override async Task<SessionViewModel> Get(Guid id)
        {
            var entity = await base.Get(id);
            entity.CurrentPlayerCount = await (_repository as ISessionRepository).GetCurrentPlayerCountInSession(id);
            return entity;
        }

        public override async Task Create(SessionCreateModel entity)
        {
            await _repository.Create(_mapper.Map<Session>(entity));
            var hostInSession = _mapper.Map<UserInSession>(entity.Host);
            await _userInSessionRepository.Create(hostInSession);
        }

        public async Task RemoveUserFromSession(UserInSessionViewModel user, SessionViewModel session)
        {
            await _userInSessionRepository.RemoveByUserId(user.Id);
            if (session.Host.Equals(user.User))
            {
                await _repository.Delete(session.Id);
            }
        }
    }
}
