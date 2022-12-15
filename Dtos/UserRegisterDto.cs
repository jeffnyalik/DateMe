using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAPI.Dtos
{
    public class UserRegisterDto
    {   
        [Required(ErrorMessage = "Username is required")]
        public string UserName {get;set;}
        
        [Required(ErrorMessage = "Email is required")]
        public string Email {get;set;}

        [Required(ErrorMessage = "Password can not be empty")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 8")]
        public string Password {get;set;}
    }
}