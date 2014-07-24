﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrandValues.Entries
{
    public class PostEntry
    {
        //Individual or team
        [Required]
        public string Type { get; set; }

        //Video, text, image
        [Required]
        public string Format { get; set; }

        [Required(ErrorMessage = "Which Brand Value are you demonstrating?")]
        public string Values { get; set; }

        [StringLength(600)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "We need a description i.e. Summary of how this entry lives the Brand Values")]
        public string Description { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "A name would be very helpful")]
        public string Name { get; set; }
        
        public string UserName { get; set; }

        public string TeamName { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public string UserArea { get; set; }
    }
}