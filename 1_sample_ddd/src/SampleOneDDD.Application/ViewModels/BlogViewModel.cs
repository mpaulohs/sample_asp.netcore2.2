using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SampleOneDDD.Application.ViewModels
{
    public class BlogViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Url is Required")]        
        [DisplayName("Url")]
        public string Url { get; set; }

       
    }
}
