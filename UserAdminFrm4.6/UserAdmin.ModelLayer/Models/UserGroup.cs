using System;
using System.Collections.Generic;

namespace UserAdmin.Models
{
    public partial class UserGroup
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public virtual Group Group { get; set; }
        public virtual User1 User { get; set; }
    }
}
