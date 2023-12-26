using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.Expressions;

namespace CRPFGC.Models
{
    public class DataLayer
    {
        DBLayer db = new DBLayer();

        //-----Add New Quarter Type to tbl_QuarterType-------
        public object AddQuarterType(DataModel data)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@quarter_type",data.quarter_type),
                new SqlParameter("@water_charge",data.water_charge)
            };
          return  db.ExecuteScaler("sp_addQuarterType", parameters);
        }
        //-------Select All Quarter Types added in tbl_QuarterType--
        public DataTable SelectAllQuarterType()
        {
            DataTable dt = db.ExecuteSelect("sp_selectQuarterType");
            return dt;
        }
        //--------select active quarter type added in tbl_quarterType
        public DataTable SelectActiveQuarterType()
        {
            DataTable dt = db.ExecuteSelect("sp_selectActiveQuarterType");
            return dt;
        }

        //-----Add New Rank to tbl_tbl_rank-----
        public object AddRank(DataModel data)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@rank",data.rank),
                new SqlParameter("@rank_code",data.rank_code),
                new SqlParameter("@quarter_type",data.quarter_sn),
                new SqlParameter("@flm",data.flm)
            };
            return db.ExecuteScaler("sp_addRank", parameters);
        }

        //-----Select All Rank added in tbl_Rank-----
        public DataTable SelectAllRank()
        {
            DataTable dt = db.ExecuteSelect("sp_selectRank");
            return dt;
        }
        //-----Add New Place of Posting to tbl_postingPlace-----
        public object AddPlaceOfPosting(DataModel data)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@unit",data.unit),
                new SqlParameter("@place_of_posting",data.place_of_posting),
                new SqlParameter("@license_fee",data.license_fee)
            };
            return db.ExecuteScaler("sp_addPlaceOfPosting", parameters);
        }

        //-----Select All Place of Posting added in tbl_postingPlace-----
        public DataTable SelectAllPlaceOfPosting()
        {
            DataTable dt = db.ExecuteSelect("sp_selectPlaceOfPosting");
            return dt;
        }

        //-----Add New Quarter Detail to tbl_rank-----
        public object AddQuarterDetail(DataModel data)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@quarter_no",data.quarter_no),
                new SqlParameter("@quarter_type",data.quarter_sn),
                new SqlParameter("@block",data.block)
            };
            return db.ExecuteScaler("sp_addQuarterDetail", parameters);
        }

        //-----Select All Quarter Detail added in tbl_Rank-----
        public DataTable SelectQuarterDetail()
        {
            DataTable dt = db.ExecuteSelect("sp_selectQuarterDetail");
            return dt;
        }
        //-----Add New Rank Type to tbl_rankType-----
        public object AddRankType(DataModel data)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@rank",data.rank_sn),
                new SqlParameter("@rank_type",data.rank_type),
                new SqlParameter("@rank_typeCode",data.rank_typecode)
            };
            return db.ExecuteScaler("sp_addRankType", parameters);
        }

        //-----Select All Rank added in tbl_RankType-----
        public DataTable SelectAllRankType()
        {
            DataTable dt = db.ExecuteSelect("sp_selectRankType");
            return dt;
        }
        //--------select active ranktype added in tbl_rankType---------
        public DataTable SelectActiveRankType()
        {
            DataTable dt = db.ExecuteSelect("sp_selectActiveRankType");
            return dt;
        }
        //--------add new electricity charge in tbl_electricity_charge----------
        public object AddElectricityCharge(DataModel data)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@unit_charge",data.unit_charge),
                new SqlParameter("@fixed_electicity_charge",data.fixed_electricity_charge)
            };
            return db.ExecuteScaler("sp_addElectricityCharge", parameters);
        }
        //-----Select All Rank added in tbl_Rank-----
        public DataTable SelectAllElectricityCharge()
        {
            DataTable dt = db.ExecuteSelect("sp_selectElectricityCharge");
            return dt;
        }
        //-----Add registration in tbl_registration-----
        public object AddRegistration(DataModel data)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@reg_quarter_no",data.reg_quarter_no),
                new SqlParameter("@reg_rank",data.reg_rank),
                new SqlParameter("@force_no",data.force_no),
                new SqlParameter("@name",data.name),
                new SqlParameter("@reg_unit",data.reg_unit),
                new SqlParameter("@mobile_no",data.mobile),
                new SqlParameter("@email_id",data.email),
                new SqlParameter("@gender",data.gender),
                new SqlParameter("@aadhar_no",data.aadhar),
                new SqlParameter("@quarter_allotment_order_no",data.quarter_allotment_order_no),
                new SqlParameter("@quarter_allotment_date",data.quarter_allotment_date),
                new SqlParameter("@quarter_aquisition_date",data.quarter_acquisition_date),
                new SqlParameter("@physical_occupation_report",data.physical_occupation_report.FileName),
                new SqlParameter("@quarter_allotment_letter",data.upload_quarter_allotment_letter.FileName)
            };
            return db.ExecuteScaler("sp_addRegistration", parameters);
        }
        //--------select active quarterno added in tbl_quarter------
        public DataTable SelectActiveQuarterno()
        {
            DataTable dt = db.ExecuteSelect("sp_selectActiveQuarterno");
            return dt;
        }
        //--------select active rankno added in tbl_rank------
        public DataTable SelectActiveRankno()
        {
            DataTable dt = db.ExecuteSelect("sp_selectActiveRankno");
            return dt;
        }
        //--------select active pop in tbl_postingplace
        public DataTable SelectActivePlaceOfPosting()
        {
            DataTable dt = db.ExecuteSelect("sp_selectActivePlaceOfPosting");
            return dt;
        }
        //-------select all employee in tbl_registration
        public DataTable SelectAllEmployee()
        {
            DataTable dt = db.ExecuteSelect("sp_selectAllEmployee");
            return dt;
        }

        //login of admin and operator
        public DataTable CheckLogin(string username, string password, int action)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@username",username),
                new SqlParameter("@password",password),
                new SqlParameter("@action",action)
            };
            DataTable dt = db.ExecuteSelect("sp_login", parameters);
            return dt;
        }
        //login of user
        public DataTable CheckUserLogin(long mobile,int action)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@mobile_no",mobile),
                new SqlParameter("@action",action)
            };
            DataTable dt = db.ExecuteSelect("sp_userlogin", parameters);
            return dt;
        }

    }
    
}