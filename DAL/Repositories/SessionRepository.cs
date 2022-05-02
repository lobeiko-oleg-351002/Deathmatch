using DAL.Repositories.Interface;
using DAL.Repositories.Logging;
using Database;
using Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Exceptions;
using System.Collections.Generic;

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

        public new async Task<Guid> Create(Session entity)
        {
            try
            {
                entity.Id = new Guid();
                _logMessageManager.LogEntityCreation(entity);
                entity.Host = await _context.Users.FirstOrDefaultAsync(user => user.Id == entity.Host.Id);
                entity.Level = await _context.Locations.FirstOrDefaultAsync(location => location.Id == entity.Level.Id);
                var result = await _context.Set<Session>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                _logMessageManager.LogFailure(ex.Message);
                throw new DalCreateException(ex.Message);
            }
        }
    }
}
