using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class BasicFeedApi
    {
        public BasicFeed Feed { get; set; }
        public SortedList<string,string> Tags { get; set; }
        public SortedList<string, string> Categories { get; set; }
    }
}
