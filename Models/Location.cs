using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Location : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PosterFilepath { get; set; }
        [Required]
        public string LevelFilepath { get; set; }
    }
}
