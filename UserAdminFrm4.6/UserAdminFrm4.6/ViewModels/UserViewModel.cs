using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC4UserAdmin.ViewModels
{
    public partial class UserViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Firstname { get; set; }
        
        [Required]
        public string Surname { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public string PasswordConfirm { get; set; }


    }
}