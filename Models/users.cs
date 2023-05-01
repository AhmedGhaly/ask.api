using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social_website.Models
{
    public class users
    {

            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "*")]
            [MaxLength(50)]
            public string Username { get; set; }

            [Required(ErrorMessage = "*")]
            [MaxLength(10)]
            [Remote("checkUserNameId", "user", ErrorMessage = "already Exist")]
            public string userName_id { get; set; }

            [Required(ErrorMessage = "*")]
            [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = "invlaid email" )]
            [MaxLength(100)]
            public string Email { get; set; }

            [Required(ErrorMessage = "*")]
            [MaxLength(100)]
            public string Password { get; set; }

            [Required(ErrorMessage = "*")]
            [NotMapped]
            [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "passwords not match")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "*")]
            [MaxLength(100)]
            public string ProfilePicture { get; set; }

            public int followers { get; set; }
            public string Bio { get; set; }

            public int? follow_id { get; set; }
            public virtual users user { get; set; }
            public virtual users block_user { get; set; }
            public virtual ICollection<users> follow { get; set; }

            public int? block_id { get; set; }
        
            public virtual ICollection<users> block_users { get; set; }

            public virtual ICollection<questions> Questions { get; set; }
            public virtual ICollection<answers> Answers { get; set; }
        //public virtual ICollection<answers> loveAnswers { get; set; }

        


    }
}