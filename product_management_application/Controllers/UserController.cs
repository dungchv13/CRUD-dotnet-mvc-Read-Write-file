using product_management_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace product_management_application.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String username, String password)
        {
            if(username == "admin" && password == "admin")
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
    }
}