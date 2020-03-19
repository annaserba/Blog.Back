using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Blog.Enums;

namespace Blog.Models
{
    public class BasicFeed
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public Language Language { get; set; }
        [Required]
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime Modified { get; set; }
        public string UrlTileImage { get; set; }
        [JsonIgnore]
        public ICollection<FeedTag> FeedTags { get; set; }
        [JsonIgnore]
        public ICollection<FeedCategory> FeedCategories { get; set; }
    }
    public class Feed: BasicFeed
    {
        [Required]
        public string Content { get; set; }
        public bool CommentStatus { get; set; }
        public string MetaDescription { get; set; }
        public string Source { get; set; }
    }
}
