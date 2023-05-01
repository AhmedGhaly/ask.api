using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Social_website.Models
{
    public class questions
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public string unkown { get; set; }

        [Required]
        public int UserId { get; set; }


        public virtual users User { get; set; }


        public virtual answers Answers { get; set; }


    }
}