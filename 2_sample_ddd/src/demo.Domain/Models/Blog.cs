using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace demo.Domain.Models
{
    public class Blog
    {
        public Blog(string url, string title)
        {
            Url = url;
            Title = title;
        }        
        public Blog() { }

        public int Id { get; set; }        
        public string Url { get; set; }
        [MaxLength(5)]
        public string Title { get; set; }
    }
}
