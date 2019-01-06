using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOneDDD.Domain.Models
{
    public class Tag
    {
        public string TagId { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
