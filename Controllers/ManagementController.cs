using EMP_CRUD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMP_CRUD_MVC.Controllers
{
    public class ManagementController : Controller
    {
        DB_Emp_Oct_MVCEntities dbo = new DB_Emp_Oct_MVCEntities();
        // GET: Management
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signup()
        {
            //Emp registration+login details
            return View();
        }
        [HttpGet]

        //CRUD--->Read operation
        public ActionResult Login()
        {          
            return View();
        }
        [HttpPost]

        //CRUD--->Read operation
        public ActionResult Login(tblLogin lg)
        {
            tblLogin lgTemp = dbo.tblLogins.FirstOrDefault(x => x.UserName == lg.UserName && x.Password == lg.Password);
            if (lgTemp==null)
            {
                ViewBag.msg = "Invalid username or password!!!";
                return View();
            }
            else
            {
                return RedirectToAction("DashBoard", "Home");
            }

               
        }
    }
}