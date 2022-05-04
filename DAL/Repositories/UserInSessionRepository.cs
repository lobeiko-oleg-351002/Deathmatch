using DAL.Exceptions;
using DAL.Repositories.Interface;
using DAL.Repositories.Logging;
using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserInSessionRepository : Repository<UserInSession>, IUserInSessionRepository
    {
        public UserInSessionRepository(DeathmatchDbContext context, ILogMessageManager<UserInSession> logMessageManager) : base(context, logMessageManager)
        {

        }

        public async Task<List<UserInSession>> GetUsersInParticularSession(Guid sessionId)
        {
            var items = _context.UserInSessions.Where(item => item.Session.Id == sessionId);
            return await items.ToListAsync();
        }

        public async Task RemoveByUserId(Guid userId)
        {
            var itemToDelete = await _context.UserInSessions.FirstOrDefaultAsync(item => item.User.Id == userId);
            if (itemToDelete != null)
            {
                _context.Remove(itemToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public override async Task Create(UserInSession entity)
        {
            try
            {
                _logMessageManager.LogEntityCreation(entity);
                entity.User = await _context.Users.FirstOrDefaultAsync(user => user.Id == entity.User.Id);
                entity.Session = await _context.Sessions.FirstOrDefaultAsync(session => session.Id == entity.Session.Id);
                var result = await _context.Set<UserInSession>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logMessageManager.LogFailure(ex.Message);
                throw new DalCreateException(ex.Message);
            }
        }
    }
}
