using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace UserAdmin.Models.Mapping
{
    public class GroupPermissionMap : EntityTypeConfiguration<GroupPermission>
    {
        public GroupPermissionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("GroupPermission");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PermissionID).HasColumnName("PermissionID");
            this.Property(t => t.GroupID).HasColumnName("GroupID");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");

            // Relationships
            this.HasRequired(t => t.Group)
                .WithMany(t => t.GroupPermissions)
                .HasForeignKey(d => d.GroupID);
            this.HasRequired(t => t.Permisson)
                .WithMany(t => t.GroupPermissions)
                .HasForeignKey(d => d.PermissionID);

        }
    }
}
