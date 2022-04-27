using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IUserInSessionRepository : IRepository<UserInSession>
    {
        Task RemoveByUserId(Guid userId);
        Task<List<UserInSession>> GetUsersInParticularSession(Session session);
    }
}
