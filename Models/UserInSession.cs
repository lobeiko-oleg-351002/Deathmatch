using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserInSession : Entity
    {
        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Session Session { get; set; }

        public int KillCount { get; set; }
        public int DeathCount { get; set; }


    }
}
