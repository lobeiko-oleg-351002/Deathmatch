using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services.Interface
{
    public interface IRoleService : IService<RoleViewModel, RoleCreateModel>
    {
        
    }
}
