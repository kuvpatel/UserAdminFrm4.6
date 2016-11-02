using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UserAdmin.Models.Mapping;

namespace UserAdmin.Models
{
    public partial class UsersContext : DbContext
    {
        static UsersContext()
        {
            Database.SetInitializer<UsersContext>(null);
        }

        public UsersContext()
            : base("Name=UsersContext")
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        public DbSet<Permisson> Permissons { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User1> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new GroupPermissionMap());
            modelBuilder.Configurations.Add(new PermissonMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserGroupMap());
        }
    }
}
