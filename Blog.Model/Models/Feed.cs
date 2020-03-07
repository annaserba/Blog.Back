using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Blog.Enums;

namespace Blog.Models
{
    public class Feed
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }

        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public Language Language { get; set; }
        public ICollection<Image> Images { get; set; }

    }
}
