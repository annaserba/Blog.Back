using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Blog.Models
{
    public class Source
    {
        [Key]
        public int ID { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public ICollection<FeedSource> FeedSources { get; set; }
    }
}
