using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nazwa użytkownika")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
