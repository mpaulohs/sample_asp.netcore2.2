using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOneDDD.Domain.Models
{
    public class BlogImage
    {
        public int BlogImageId { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
