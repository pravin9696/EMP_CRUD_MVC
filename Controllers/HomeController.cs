using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMP_CRUD_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DashBoard()
        {
            @ViewBag.userName = TempData["userName"];
            return View();
        }
    }
}