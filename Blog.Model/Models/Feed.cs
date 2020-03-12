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
        public string Url { get; set; }
        [Required]
        public Language Language { get; set; }
        [Required]
        public string Title { get; set; }
        public string Excerpt { get; set; }
        [Required]
        public string Content { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; } 
        public DateTime Modified { get; set; } 
        public string UrlTileImage { get; set; }
        public bool CommentStatus { get; set; }
        public FeedType Type { get; set; }
        public string MetaDescription { get; set; }
    }
}
