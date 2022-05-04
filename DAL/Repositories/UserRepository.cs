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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DeathmatchDbContext context, ILogMessageManager<User> logMessageManager) : base(context, logMessageManager)
        {

        }

        public async Task<User> GetByNameAndPassword(string name, string password)
        {
            _logMessageManager.LogCustomMessage("GetByNameAndPassword. Name: " + name + " Password: " + password);
            var entity = await _context.Users.Include(role => role.Role).FirstOrDefaultAsync(e => (e.Name == name) && (e.Password == password));
            if (entity == null)
            {
                var ex = new ItemNotFoundException();
                _logMessageManager.LogFailure(ex.Message);
                throw ex;
            }
            _logMessageManager.LogSuccess();
            return entity;
        }

        public override async Task<User> Get(Guid id)
        {
            _logMessageManager.LogGet(id);
            User User = await _context.Users.Include(role => role.Role).FirstOrDefaultAsync(user => user.Id == id);
            if (User == null)
            {
                var ex = new ItemNotFoundException();
                _logMessageManager.LogFailure(ex.Message);
                throw ex;
            }
            _logMessageManager.LogSuccess();
            return User;
        }

        public override IQueryable<User> GetAll()
        {           
            _logMessageManager.LogGetAll();
            var elements = _context.Users.Include(role => role.Role).AsQueryable();
            if (elements.Any())
            {
                _logMessageManager.LogSuccess();
                return elements;
            }
            var ex = new NoElementsException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }


    }
}
