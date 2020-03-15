using Blog.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Models
{
    public class Tag
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public Language Language { get; set; }
        [Required]
        public string Name { get; set; }
        public string Excerpt { get; set; }
        public ICollection<FeedTag> FeedTags { get; set; }
    }
}
