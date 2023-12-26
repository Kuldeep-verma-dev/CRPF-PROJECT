using CRPFGC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CRPFGC.Controllers
{
    public class AccountantController : Controller
    {
        DataLayer dataLayer = new DataLayer();
        DBLayer db = new DBLayer();
        // GET: Accountant
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            DataTable dt1 = dataLayer.SelectActiveQuarterno();
            ViewBag.quarterno = dt1;
            DataTable dt2 = dataLayer.SelectActiveRankno();
            ViewBag.rankno = dt2;
            DataTable dt3 = dataLayer.SelectActivePlaceOfPosting();
            ViewBag.placeofposting = dt3;
            return View();
        }
        [HttpPost]
        public ActionResult Register(DataModel model)
        {
            object result = "";
            if (model.reg_quarter_no != 0 && model.reg_rank != 0 && model.force_no != null && model.name != null && model.reg_unit!=0 && model.mobile!=0 && model.email!=null && model.gender!=null && model.aadhar!=0 && model.quarter_allotment_order_no!=null && model.quarter_allotment_date!=null && model.quarter_acquisition_date!=null && model.physical_occupation_report.FileName!=null && model.upload_quarter_allotment_letter.FileName!=null)
            {
                model.physical_occupation_report.SaveAs(Server.MapPath("/content/images/registration/") + model.physical_occupation_report.FileName);
                model.upload_quarter_allotment_letter.SaveAs(Server.MapPath("/content/images/registration") + model.upload_quarter_allotment_letter.FileName);
                result = dataLayer.AddRegistration(model);
            }
            else
            {
                result = "Please fill all fields properly.";
            }
            return Content("<script>alert('" + result + "');location.href='/accountant/Register'</script>");
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(long mobile)
        {
            DataTable dt = dataLayer.CheckUserLogin(mobile,1);
            if (dt.Rows.Count > 0)
            {
                Session["userinfo"] = mobile;
                return RedirectToAction("Index", "User");
            }
            else
            {
                return Content("<script>alert('Invalid credentials.');location.href='/accountant/UserLogin'</script>");
            }
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(string username, string password)
        {
           DataTable dt= dataLayer.CheckLogin(username, password, 1);
            if(dt.Rows.Count>0)
            {
                Session["admininfo"] =username;
                return RedirectToAction("index","admin");
            }
            else
            {
                return Content("<script>alert('Invalid credentials.');location.href='/accountant/AdminLogin'</script>");
            }
        }
        public ActionResult MeterReaderLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MeterReaderLogin(string username, string password)
        {
            DataTable dt = dataLayer.CheckLogin(username, password, 2);
            if (dt.Rows.Count > 0)
            {
                Session["operatorinfo"] = username;
                return RedirectToAction("AddUnit", "Technician");
            }
            else
            {
                return Content("<script>alert('Invalid credentials.');location.href='/accountant/MeterReaderLogin'</script>");
            }
        }
    }
}