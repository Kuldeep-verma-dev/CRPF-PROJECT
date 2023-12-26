using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRPFGC.Models
{
    public class DataModel
    {
        public string quarter_type { get; set; }
        public float water_charge { get; set; }
        public string rank { get; set; }
        public string rank_code { get; set; }
        public int quarter_sn{ get; set;}
        public float flm { get; set; }
        public string unit { get; set; }
        public string place_of_posting { get; set;}
        public float license_fee {  get; set; }
        public string quarter_no { get; set; }
        public string block {  get; set; }
        public int rank_sn { get; set; }
        public string rank_typecode { get; set; }
        public string rank_type { get; set; }
        public float unit_charge { get; set; }
        public float fixed_electricity_charge {  get; set; }
        public int reg_quarter_no { get; set; }
        public int reg_rank { get; set; }
        public string force_no { get; set; }
        public string name { get; set; }
        public int reg_unit { get; set; }
        public int mobile { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public int aadhar { get; set; }
        public string quarter_allotment_order_no { get; set; }
        public string quarter_allotment_date { get; set; }
        public string quarter_acquisition_date { get; set; }
        public HttpPostedFileBase physical_occupation_report {  get; set; }
        public HttpPostedFileBase upload_quarter_allotment_letter {  get; set; }
    }
}