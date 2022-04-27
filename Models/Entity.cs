using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class Entity
    {
        [Key, Required]
        public Guid Id { get; set; }
    }
}
