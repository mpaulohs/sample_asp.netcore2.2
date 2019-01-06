using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOneDDD.Domain.Models
{
    public class Blog
    {
        public Blog(string url)
        {
            Url = url;
        }
        public Blog() { }

        public int BlogId { get; set; }
        public string Url { get; set; }

        public BlogImage BlogImage { get; set; }
    }
}
