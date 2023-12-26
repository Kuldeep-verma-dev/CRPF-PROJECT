using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRPFGC.Controllers
{
    public class TechnicianController : Controller
    {
        // GET: Technician
        public ActionResult AddUnit()
        {
            if (Session["operatorinfo"] != null)
                return View();
            else
                return RedirectToAction("MeterReaderLogin", "Accountant");
        }
        public ActionResult Logout()
        {
            Session.Remove("operatorinfo");
            return RedirectToAction("meterreaderlogin", "accountant");
        }
    }
}