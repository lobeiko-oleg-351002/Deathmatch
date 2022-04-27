using DAL.Repositories.Interface;
using DAL.Repositories.Logging;
using Database;
using Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository(DeathmatchDbContext context, ILogMessageManager<Session> logMessageManager) : base(context, logMessageManager)
        {

        }

        public async Task<int> GetCurrentPlayerCountInSession(Guid sessionId)
        {
            return await _context.UserInSessions.CountAsync(userInSession => userInSession.Session.Id == sessionId); 
        }
    }
}
