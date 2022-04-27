using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.View;

namespace ViewModels.Create
{
    public class SessionCreateModel : CreateModel
    {
        public string Name { get; set; }

        public int MaxPlayerCount { get; set; }

        public virtual LocationViewModel Level { get; set; }

        public virtual UserViewModel Host { get; set; }
    }
}
