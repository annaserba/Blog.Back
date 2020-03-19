using Blog.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Blog.Models
{
    public class BasicCategory
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
        public ICollection<FeedCategory> Feeds { get; set; }
    }
    public class Category: BasicCategory
    {
        public string Excerpt { get; set; }
    }
}
