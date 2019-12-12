using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Core3._0.Models
{
    public class Quote
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        public string Author { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        public string Type { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }
    }
}
