using System;
using System.Collections.Generic;

namespace UserAdmin.Models
{
    public partial class Group
    {
        public Group()
        {
            this.GroupPermissions = new List<GroupPermission>();
            this.UserGroups = new List<UserGroup>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
