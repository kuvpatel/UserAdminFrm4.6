using System;
using System.Collections.Generic;

namespace UserAdmin.Models
{
    public partial class Permisson
    {
        public Permisson()
        {
            this.GroupPermissions = new List<GroupPermission>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
    }
}
