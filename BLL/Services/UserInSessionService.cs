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
        public UserInSessionService(IRepository<UserInSession> repository, IMapper mapper) : base(repository, mapper)
        {
            
        }

        public async Task<List<UserInSessionViewModel>> GetUsersInParticularSession(SessionViewModel session)
        {
            var entity = _mapper.Map<Session>(session);
            var items = await (_repository as IUserInSessionRepository).GetUsersInParticularSession(entity);
            return _mapper.Map<List<UserInSessionViewModel>>(items);
        }
    }
}
