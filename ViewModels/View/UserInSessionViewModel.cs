using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.View
{
    public class UserInSessionViewModel : ViewModel
    {
        public virtual UserViewModel User { get; set; }

        public int KillCount { get; set; }
        public int DeathCount { get; set; }
    }
}
