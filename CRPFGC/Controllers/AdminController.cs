using CRPFGC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRPFGC.Controllers
{
    public class AdminController : Controller
    {
        DataLayer dataLayer = new DataLayer();
        DBLayer db = new DBLayer();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["admininfo"] != null)
                return View();
            else
                return RedirectToAction("adminlogin","accountant");
        }
        public ActionResult EmployeeManagement()
        {
            DataTable dt = dataLayer.SelectAllEmployee();
            ViewBag.employees = dt;
            return View();
        }
        public ActionResult RankManagement()
        {
            //select all quarter type to bind in DDL
            DataTable dt = dataLayer.SelectActiveQuarterType();
            ViewBag.quarters = dt;
            DataTable data = dataLayer.SelectAllRank();
            ViewBag.data = data;
            return View();
        }
        [HttpPost] 
        public ActionResult RankManagement(DataModel model)
        {
            object result = "";
            if (model.rank != null && model.rank_code != null && model.flm != 0 && model.quarter_sn != 0)
            {
                result = dataLayer.AddRank(model);
            }
            else
            {
                result = "Please fill all fields properly.";
            }
            return Content("<script>alert('" + result + "');location.href='/Admin/RankManagement'</script>");
        }
        public ActionResult deleteRank(int? sr)
        {
            SqlParameter[] sqlParameter = new SqlParameter[]
                { new SqlParameter("@sr", sr) };
            int deletedRow = db.ExecuteDML("sp_deleteRank", sqlParameter);
            if (deletedRow > 0)
            {
                return Content("<script>alert('Data deleted Successfully');location.href='/Admin/RankManagement'</script>");
            }
            else
            {
                return Content("<script>alert('Data not deleted');location.href='/Admin/RankManagement'</script>");
            }
        }
        public ActionResult PlaceOfPosting()
        {
            DataTable data = dataLayer.SelectAllPlaceOfPosting();
            ViewBag.data = data;
            return View();
        }
        [HttpPost]
        public ActionResult PlaceOfPosting(DataModel model)
        {
            object result = "";
            if (model.place_of_posting != null && model.unit != null && model.license_fee != 0)
            {
                result = dataLayer.AddPlaceOfPosting(model);
            }
            else
            {
                result = "Please fill all fields properly.";
            }
            return Content("<script>alert('" + result + "');location.href='/Admin/PlaceOfPosting'</script>");
        }
        public ActionResult deletePlaceOfPosting(int? sr)
        {
            SqlParameter[] sqlParameter = new SqlParameter[]
                { new SqlParameter("@sr", sr) };
            int deletedRow = db.ExecuteDML("sp_deletepostingPlace", sqlParameter);
            if (deletedRow > 0)
            {
                return Content("<script>alert('Data deleted Successfully');location.href='/Admin/PlaceOfPosting'</script>");
            }
            else
            {
                return Content("<script>alert('Data not deleted');location.href='/Admin/PlaceOfPosting'</script>");
            }
        }
        public ActionResult RankTypeManagement()
        {
            DataTable dt = dataLayer.SelectActiveRankType();
            ViewBag.rank = dt;
            DataTable data = dataLayer.SelectAllRankType();
            ViewBag.data = data;
            return View();
        }
        [HttpPost]
        public ActionResult RankTypeManagement(DataModel model)
        {
            object result = "";
            if (model.rank_sn != 0 && model.rank_type != null && model.rank_typecode != null)
            {
                result = dataLayer.AddRankType(model);
            }
            else
            {
                result = "Please fill all fields properly.";
            }
            return Content("<script>alert('" + result + "');location.href='/Admin/RankTypeManagement'</script>");
        }
        public ActionResult deleteRankTypeManagement(int? sr)
        {
            SqlParameter[] sqlParameter = new SqlParameter[]
                { new SqlParameter("@sr", sr) };
            int deletedRow = db.ExecuteDML("sp_deleterankType", sqlParameter);
            if (deletedRow > 0)
            {
                return Content("<script>alert('Data deleted Successfully');location.href='/Admin/RankTypeManagement'</script>");
            }
            else
            {
                return Content("<script>alert('Data not deleted');location.href='/Admin/RankTypeManagement'</script>");
            }
        }
        public ActionResult QuarterTypeManagement()
        {
            DataTable data = dataLayer.SelectActiveQuarterType();
            ViewBag.data = data;
            return View();
        }
        [HttpPost]
        public ActionResult QuarterTypeManagement(DataModel model)
        {
            object result = "";
            if (model.quarter_type != null && model.water_charge != 0)
            {
                result = dataLayer.AddQuarterType(model);
            }
            else
            {
                result = "Please fill all fields properly.";
            }
            return Content("<script>alert('" + result + "');location.href='/Admin/QuarterTypeManagement'</script>");
        }
        public ActionResult deleteQuarterType(int? sr)
        {
            SqlParameter[] sqlParameter = new SqlParameter[]
                { new SqlParameter("@sr", sr) };
            int deletedRow = db.ExecuteDML("sp_deleteQuarterType", sqlParameter);
            if (deletedRow > 0)
            {
                return Content("<script>alert('Data deleted Successfully');location.href='/Admin/QuarterTypeManagement'</script>");
            }
            else
            {
                return Content("<script>alert('Data not deleted');location.href='/Admin/QuarterTypeManagement'</script>");
            }
        }
        public ActionResult QuarterDetail()
        {
            //select all quarter type to bind in DDL
            DataTable dt = dataLayer.SelectActiveQuarterType();
            ViewBag.quarters = dt;

            DataTable data = dataLayer.SelectQuarterDetail();
            ViewBag.data = data;
            return View();
        }
        [HttpPost]
        public ActionResult QuarterDetail(DataModel model)
        {
            object result = "";
            if (model.quarter_no != null && model.quarter_sn != 0 && model.block != null)
            {
                result = dataLayer.AddQuarterDetail(model);
            }
            else
            {
                result = "Please fill all fields properly.";
            }
            return Content("<script>alert('" + result + "');location.href='/Admin/QuarterDetail'</script>");
        }
        public ActionResult deleteQuarterDetail(int? sr)
        {
            SqlParameter[] sqlParameter = new SqlParameter[]
                { new SqlParameter("@sr", sr) };
            int deletedRow = db.ExecuteDML("sp_deleteQuarterDetail", sqlParameter);
            if (deletedRow > 0)
            {
                return Content("<script>alert('Data deleted Successfully');location.href='/Admin/QuarterDetail'</script>");
            }
            else
            {
                return Content("<script>alert('Data not deleted');location.href='/Admin/QuarterDetail'</script>");
            }
        }
        public ActionResult ElectricityCharge()
        {
            DataTable data = dataLayer.SelectAllElectricityCharge();
            ViewBag.data = data;
            return View();
        }
        [HttpPost]
        public ActionResult ElectricityCharge(DataModel model)
        {
            object result = "";
            if (model.unit_charge != 0 && model.fixed_electricity_charge != 0)
            {
                result = dataLayer.AddElectricityCharge(model);
            }
            else
            {
                result = "Please fill all fields properly.";
            }
            return Content("<script>alert('" + result + "');location.href='/Admin/ElectricityCharge'</script>");
        }
        public ActionResult deleteElectricityCharge(int? sr)
        {
            SqlParameter[] sqlParameter = new SqlParameter[]
                { new SqlParameter("@sr", sr) };
            int deletedRow = db.ExecuteDML("sp_deleteelectricity_charge", sqlPadminloginarameter);
            if (deletedRow > 0)
            {
                return Content("<script>alert('Data deleted Successfully');location.href='/Admin/ElectricityCharge'</script>");
            }
            else
            {
                return Content("<script>alert('Data not deleted');location.href='/Admin/ElectricityCharge'</script>");
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("admininfo");
            return RedirectToAction("adminlogin", "accountant");
        }

    }
}