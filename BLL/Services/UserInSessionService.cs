using AutoMapper;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services
{
    public class UserInSessionService : Service<UserInSession, UserInSessionViewModel, UserInSessionCreateModel>, IUserInSessionService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionRepository _sessionRepository;
        public UserInSessionService(IUserInSessionRepository repository, IUserRepository userRepository, ISessionRepository sessionRepository, IMapper mapper)
            : base(repository, mapper)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
        }

        public async Task<List<UserInSessionViewModel>> GetUsersInParticularSession(Guid sessionId)
        {
            var items = await (_repository as IUserInSessionRepository).GetUsersInParticularSession(sessionId);
            return _mapper.Map<List<UserInSessionViewModel>>(items);
        }

        public override async Task Create(UserInSessionCreateModel entity)
        {
            var dalEntity = _mapper.Map<UserInSession>(entity);
            dalEntity.User = await _userRepository.Get(dalEntity.User.Id);
            dalEntity.Session = await _sessionRepository.Get(dalEntity.Session.Id);
            await _repository.Create(dalEntity);
        }
    }
}
