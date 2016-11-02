using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserAdmin.Models;

namespace UserAdmin.DataLayer
{
    public interface IUserRepository
    {
        bool Add(User1 film);
        void Delete(int ID);
        IEnumerable<User1> GetAll();
        IEnumerable<User1> GetAll(int? curentPage, int pageSize);
        User1 Get(int ID);
        void Save();
        bool Update(User1 user);
    }

}