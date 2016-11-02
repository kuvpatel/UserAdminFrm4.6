using System;
using System.Collections.Generic;

namespace UserAdmin.Models
{
    public partial class User1
    {
        //public User1()
        //{
        //    this.UserGroups = new List<UserGroup>();
        //}

        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
