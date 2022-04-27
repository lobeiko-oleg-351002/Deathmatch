using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByNameAndPassword(string name, string password);
    }
}
