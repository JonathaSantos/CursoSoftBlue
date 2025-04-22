using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModeloNet6.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}
