using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserAdmin.Models;
 
namespace UserAdmin.DataLayer
{
    public class UserRepository : IUserRepository
    {
        private UsersContext db = new UsersContext();


        public IEnumerable<User1> GetAll()
        {

            var users = from u in db.Users
                        where u.Active == true
                        select u;

            return users;
        }


        public IEnumerable<User1> GetAll(int? currentPage, int pageSize)
        {
            var users = db.Users
                .OrderByDescending(u => u.DateCreated)
                .Skip(((currentPage.HasValue ? currentPage.Value : 1) - 1) * pageSize)
                .Take(pageSize);

            return users;
        }

        public User1 Get(int ID)
        {
            return db.Users.Single(u => u.ID == ID);
        }

        public bool Add(User1 user)
        {
            db.Users.Add(user);
            Save();
            return true;
        }

        public bool Update(User1 user)
        {
            var ExistingUser = db.Users.Single(u => u.ID == user.ID);
            ExistingUser.Active = user.Active;
            ExistingUser.DateUpdated = DateTime.Now;
            ExistingUser.Email = user.Email;
            ExistingUser.Firstname = user.Firstname;
            ExistingUser.Password = user.Password;
            ExistingUser.Surname = user.Surname;
            ExistingUser.Username = user.Username;
            Save();
            return true;
        }

        public void Delete(int ID)
        {
            db.Users.Remove(db.Users.Single(f => f.ID == ID));
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }

}