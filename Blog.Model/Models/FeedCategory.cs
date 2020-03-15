using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Models
{
    public class FeedCategory
    {
        [Key]
        public int ID { get; set; }
        public int FeedID { get; set; }
        public Feed Feed { get; set; }

        public string CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
