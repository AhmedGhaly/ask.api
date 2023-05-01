using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Social_website.Models
{
    public class answers
    {
        [Key]
        public int Id { get; set; }
         
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }


        [Required]
        public int UserId { get; set; }


        [Required]
        public virtual questions Questions { get; set; }

        public virtual users Users { get; set; }
        //public int lover_id { get; set; }
        //public virtual users lover { get; set; }


    }
}