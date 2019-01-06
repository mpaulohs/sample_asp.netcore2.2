﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace demo.Application.ViewModels
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
