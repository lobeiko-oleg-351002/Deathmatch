using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.View;

namespace ViewModels.Create
{
    public class UserCreateModel : CreateModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public RoleViewModel Role { get; set; }
    }
}
