using DAL.Repositories.Interface;
using DAL.Repositories.Logging;
using Database;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DeathmatchDbContext context, ILogMessageManager<Role> logMessageManager) : base(context, logMessageManager)
        {

        }
    }
}
