﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class EnterMovie
    {
        //everything is required except for Edited, LentTo, and Notes

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        //the ? makes it possible to leave this field blank in the form without errors
        public bool? Edited { get; set; }

        public string LentTo { get; set; }
        
        //StringLength to ensure that no more than 25 characters are inputed in the notes field.
        [StringLength(25, ErrorMessage = "Note must be 25 characters or less")]
        public string Notes { get; set; }
    }
}
