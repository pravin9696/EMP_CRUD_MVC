using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMP_CRUD_MVC.Models
{
    public class EmpDetailsWithLogin
    {
        public tblEmpDetail empDetail { get; set; }
        public tblLogin login { get; set; }
        public String ConfirmPassword { get; set; }
    }
}