using System;
using System.Collections.Generic;

namespace UserAdmin.Models
{
    public partial class GroupPermission
    {
        public int ID { get; set; }
        public int PermissionID { get; set; }
        public int GroupID { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public virtual Group Group { get; set; }
        public virtual Permisson Permisson { get; set; }
    }
}
