using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Models
{
    public class Image
    {
        [Key]
        public int ID { get; set; }
        public string Url { get; set; }
        
        public int FeedID { get; set; }
        [ForeignKey("FeedID")]
        public Feed Feed { get; set; }
    }
}
