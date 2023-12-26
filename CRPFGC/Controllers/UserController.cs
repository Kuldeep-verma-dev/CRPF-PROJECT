using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRPFGC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["userinfo"] != null)
                return View();
            else
                return RedirectToAction("UserLogin", "Accountant");
        }
        public ActionResult RequestManagement()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("userinfo");
            return RedirectToAction("userlogin", "accountant");
        }
    }
}