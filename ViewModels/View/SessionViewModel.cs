using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.View
{
    public class SessionViewModel : ViewModel
    {
        public string Name { get; set; }

        public int MaxPlayerCount { get; set; }

        public int CurrentPlayerCount { get; set; }

        public virtual LocationViewModel Level { get; set; }

        public virtual UserViewModel Host { get; set; }
    }
}
