using EMP_CRUD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMP_CRUD_MVC.Controllers
{
    public class DeptsController : Controller
    {
        EmployeeCRUDOperationMVCEntities dbo = new EmployeeCRUDOperationMVCEntities();
        // GET: Depts
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(tblDept dept)
        {
            dbo.tblDepts.Add(dept);
            int n = dbo.SaveChanges();
            if (n > 0)
            {
                ViewBag.msg = "Department added successfully..!";
                    return View();
            }
            else
            {
                ViewBag.msg = "Failed to add department..!";
                return View();
            }
        }
    }
}