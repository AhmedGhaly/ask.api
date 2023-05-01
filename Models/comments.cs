using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Social_website.Models
{
    public class comments
    {
        [Key]
        public int Id { get; set; }

        

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int AnswerId { get; set; }
        public virtual users Users { get; set; }

        public virtual answers Answers { get; set; }
    }
}