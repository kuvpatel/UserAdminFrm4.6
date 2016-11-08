using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAdmin.Models;
using UserAdmin.DataLayer;
using MVC4UserAdmin.ViewModels;

namespace MVC4UserAdmin.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        [HttpGet]
        public ActionResult Index()
        {
            UserListViewModel model = new UserListViewModel();
            UserRepository repository = new UserRepository();
            IEnumerable<User1> dbList = repository.GetAll();
            List<UserViewModel> uvmList = new List<UserViewModel>();
            UserViewModel uvm = null;
            foreach (User1 u in dbList)
            {
                uvm = new UserViewModel();
                uvm.Active = (bool)u.Active;
                uvm.Email = u.Email;
                uvm.Firstname = u.Firstname;
                uvm.ID = u.ID;
                uvm.Surname = u.Surname;
                uvm.Username = u.Username;
                uvmList.Add(uvm);
            }
            model.UserList = uvmList;
            return View( "Index", model);
        }


        [HttpPost]
        public ActionResult UserGrid()
        {
            UserListViewModel model = new UserListViewModel();
            UserRepository repository = new UserRepository();
            IEnumerable<User1> dbList = repository.GetAll();
            List<UserViewModel> uvmList = new List<UserViewModel>();
            UserViewModel uvm = null;
            foreach (User1 u in dbList)
            {
                uvm = new UserViewModel();
                uvm.Active = (bool)u.Active;
                uvm.Email = u.Email;
                uvm.Firstname = u.Firstname;
                uvm.ID = u.ID;
                uvm.Surname = u.Surname;
                uvm.Username = u.Username;
                uvmList.Add(uvm);
            }
            model.UserList = uvmList;
            return View(model);
        }


        public JsonResult FillIndex()
        {
            UserRepository repository = new UserRepository();
            IEnumerable<User1> dbList = repository.GetAll();
            List<UserViewModel> uvmList = new List<UserViewModel>();
            UserViewModel uvm = null;
            foreach (User1 u in dbList)
            {
                uvm = new UserViewModel();
                uvm.Active = (bool)u.Active;
                uvm.Email = u.Email;
                uvm.Firstname = u.Firstname;
                uvm.ID = u.ID;
                uvm.Surname = u.Surname;
                uvm.Username = u.Username;
                uvmList.Add(uvm);
            }

            return Json(uvmList, JsonRequestBehavior.AllowGet);
        }

       [HttpPost]
        public ActionResult Create1()
        {
            var model = new UserViewModel();

            return PartialView("_CreateUser", model);
            
        }

        [HttpPost]
        public JsonResult Create( User1 user )
        {
            bool result = false;
            UserRepository repository = new UserRepository();
            try
            {
                user.DateCreated = DateTime.Now;
                user.DateUpdated = DateTime.Now;
                result = repository.Add(user); 
            }
            catch( Exception ex)
            {
                // to do logging
                result = false;
            }
            finally
            {
                repository = null;
            }

            return new JsonResult
            {
                Data = new
                {
                    Result = result,
                    Message = ""
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            //return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Edit(int ID)
        {
            UserRepository repository = new UserRepository();
            UserViewModel uvm = new UserViewModel();
           
            try
            {
                User1 u = repository.Get(ID);

                uvm = new UserViewModel();
                uvm.Active = (bool)u.Active;
                uvm.Email = u.Email;
                uvm.Firstname = u.Firstname;
                uvm.ID = u.ID;
                uvm.Surname = u.Surname;
                uvm.Username = u.Username;
            }
            catch ( Exception ex )
            {
                // log error
            }
            finally
            {
                repository = null;
            }
            return Json(uvm, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Edit(User1 user)
        {
            string result = "fail";
            UserRepository repository = new UserRepository();
            try
            {
                repository.Update(user);
                result = repository.Add(user) ? "success" : "fail";
                result = "success";
            }
            catch (Exception ex)
            {
                // to do logging
                result = "fail";
            }
            finally
            {
                repository = null;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Delete()
        {
            return View();
        }


        //public ActionResult PopulateUserGridDataTable()
        //{

        //    UserRepository repository = new UserRepository();
        //    IEnumerable<User1> dbList = repository.GetAll();
        //    List<UserViewModel> uvmList = new List<UserViewModel>();
        //    UserViewModel uvm = null;
        //    foreach (User1 u in dbList)
        //    {
        //        uvm = new UserViewModel();
        //        uvm.Active = (bool)u.Active;
        //        uvm.Email = u.Email;
        //        uvm.Firstname = u.Firstname;
        //        uvm.ID = u.ID;
        //        uvm.Surname = u.Surname;
        //        uvm.Username = u.Username;
        //        uvmList.Add(uvm);
        //    }


        //    var data = new
        //    {
        //        success = "true",
        //        aaData = uvmList.ToArray()
        //    };


        //    return Json(data, JsonRequestBehavior.AllowGet);

        //    //  return Json(new {  result = uvmList }, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult PopulateUserGridDataTable()
        {
            try
            {
                UserRepository repository = new UserRepository();
                IEnumerable<User1> dbList = repository.GetAll();
                string[][] dataArray = new string[dbList.Count()][];

                List<string> lineItem = new List<string>();
                int index = 0;
                foreach (User1 u in dbList)
                {
                    lineItem.Add(u.Firstname);
                    lineItem.Add(u.Surname);
                    lineItem.Add(u.Username);
                    lineItem.Add(u.Email);
                    lineItem.Add(u.Active == true ? "True" : "False");

                    dataArray[index] = new string[5];
                    dataArray[index] = lineItem.ToArray();
                    index++;
                    lineItem.Clear();
                }

                List<string> headerList = new List<string>();
                headerList.Add("Firstname");
                headerList.Add("Surname");
                headerList.Add("Username");
                headerList.Add("Email");
                headerList.Add("Active");

                var data = new
                {
                    aaData = dataArray,
                    aaHeaders = headerList.ToArray(),
                    success = true
                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                var data = new
                {
                    aaData = "",
                    aaHeaders = "",
                    success = false
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
          
        }

    }


}
