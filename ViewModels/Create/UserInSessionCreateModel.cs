using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.View;

namespace ViewModels.Create
{
    public class UserInSessionCreateModel : CreateModel
    {
        public virtual UserViewModel User { get; set; }
        public virtual SessionViewModel Session { get; set; }
    }
}
