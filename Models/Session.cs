using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Session : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int MaxPlayerCount { get; set; }

        [Required]
        public virtual Location Level { get; set; }

        [Required]
        public virtual User Host { get; set; }

        public virtual List<UserInSession> UsersInSession { get; set; }
    }
}
