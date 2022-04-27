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

        public async Task<List<UserInSession>> GetUsersInParticularSession(Session session)
        {
            var items = _context.UserInSessions.Where(item => item.Session.Id == session.Id);
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
    }
}
