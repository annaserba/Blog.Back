using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Blog.Models
{
     public class FeedSource
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public int FeedID { get; set; }
        [ForeignKey("FeedID")]
        public Feed Feed { get; set; }
        [JsonIgnore]
        public int SourceID { get; set; }
        [ForeignKey("SourceID")]
        public Source Source { get; set; }
    }
}
