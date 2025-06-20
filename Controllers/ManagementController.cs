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
        [HttpGet]
        public ActionResult Signup()
        {
            DB_Emp_Oct_MVCEntities dbo = new DB_Emp_Oct_MVCEntities();
            List<tblDept> deptList = dbo.tblDepts.ToList();
            ViewBag.DeptList = deptList;
            //Emp registration+login details
            return View();
        }
        [HttpPost]
        public ActionResult Signup(EmpDetailsWithLogin edl)
        {
            DB_Emp_Oct_MVCEntities dbo = new DB_Emp_Oct_MVCEntities();
           

            //step1  insert record in tblEmpDetails and create and retrive new empid

            dbo.tblEmpDetails.Add(edl.empDetail);
            int n=dbo.SaveChanges();

            int empID = dbo.tblEmpDetails.FirstOrDefault(x => x.Name == edl.empDetail.Name && x.Address == edl.empDetail.Address && x.Contact == edl.empDetail.Contact).ID;

            edl.login.EmpID = empID;
            dbo.tblLogins.Add(edl.login);
            n = dbo.SaveChanges();
            if (n>0)
            {
                return RedirectToAction("Login");
            }
            else
            {
                
                List<tblDept> deptList = dbo.tblDepts.ToList();
                            ViewBag.DeptList = deptList;
           
                return View();
            }
            
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
                String UserName = dbo.tblEmpDetails.FirstOrDefault(x => x.ID == lgTemp.EmpID).Name;
                TempData["userName"] = UserName;
                return RedirectToAction("DashBoard", "Home");
            }

               
        }
    }
}