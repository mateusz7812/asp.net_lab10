using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace lab10.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
