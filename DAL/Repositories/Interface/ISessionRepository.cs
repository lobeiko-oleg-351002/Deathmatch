using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task<int> GetCurrentPlayerCountInSession(Guid sessionId);
    }
}
