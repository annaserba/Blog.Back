using Blog.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Blog.Models
{
    public class BasicTag
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public Language Language { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<FeedTag> Feeds { get; set; }
    }
    public class Tag: BasicTag
    {
        public string Excerpt { get; set; }
    }
}
