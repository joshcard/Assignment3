using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class EnterMovie
    {
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

        //For some reason this is acting like a [Required] field. Probably because it's boolean.
        public bool Edited { get; set; }

        public string LentTo { get; set; }
        
        //[MinLength(0)]
        //[MaxLength(25, ErrorMessage = "Note must be 25 characters or less")]
        [StringLength(25, ErrorMessage = "Note must be 25 characters or less")]
        public string Notes { get; set; }
    }
}
