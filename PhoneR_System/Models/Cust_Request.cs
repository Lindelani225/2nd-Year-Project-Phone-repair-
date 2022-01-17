using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;

namespace PhoneR_System.Models
{
    public class Cust_Request
    {
        [Key]
        public int CustReq_Id { get; set; }
        [DisplayName("Home Adress")]
        [Required]
        public string Home_Adress { get; set; }

        [Required]
        [DisplayName("Device Pick-Up Date")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Pick_Date { get; set; }

        [DataType(DataType.Time)]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DisplayName("Device Pick-Up Time")]
        public Nullable<System.DateTime> pick_Time { get; set; }

        [Required]
        public Nullable<int> Brand_ID { get; set; }
        public virtual Device Device { get; set; }

        [Required]
        public Nullable<int> Problem_ID { get; set; }
        public virtual ProblemDesc ProblemDesc { get; set; }

        [Required]
        public Nullable<int> Storg_ID { get; set; }
        public virtual storage storage { get; set; }

        [Required]
        public Nullable<int> OS_Id { get; set; }
        public virtual Operating_Sy Operating_Sy { get; set; }

        [Required]
        public Nullable<int> Col_ID { get; set; }
        public virtual Color Color { get; set; }

        [Required]
        [DisplayName("IMEI Number")]
        [StringLength(10)]
        public string IMEI_Num { get; set; }

        [Required]
        public Nullable<int> Prov_ID { get; set; }
        public virtual Province Province { get; set; }

        [DisplayName("Basic Price")]
        public Nullable<decimal> B_Price { get; set; }
        [DisplayName("Pick-Up Price")]
        public Nullable<decimal> P_Price { get; set; }
        [DisplayName("Total")]
        public Nullable<decimal> T_Price { get; set; }
        [DisplayName("Status")]
        public string Dev_Status { get; set; } = "In Progress";


        PHONEEntities db = new PHONEEntities();
        // get values form db
        public Nullable<decimal> getBrandRate()
        {
            return (db.Devices.Find(Brand_ID).Brand_Rate);
        }

        public Nullable<decimal> getProblemPr()
        {
            return (db.ProblemDescs.Find(Problem_ID).Problem_BscCost);
        }
        public Nullable<decimal> getStorageRate()
        {
            return (db.storages.Find(Storg_ID).Storg_Rate);
        }
        public Nullable<decimal> getOSRate()
        {
            return (db.Operating_Sy.Find(OS_Id).OS_Rate);
        }
        public Nullable<decimal> getProvicerate()
        {
            return (db.Provinces.Find(Prov_ID).Prov_ID);
        }
        //Calc basic

        public Nullable<decimal> CalcBPrice()
        {
            return ((getBrandRate() * getProblemPr()) + (getStorageRate() * getOSRate()));
        }
        //Calc PickUp
        public Nullable<decimal> CalcPickUpPrice()
        {
            return (CalcBPrice() / (getProvicerate() * getOSRate()));
        }
        //Calc total
        public Nullable<decimal> CalcTotalPrice()
        {
            return (CalcBPrice() + CalcPickUpPrice());
        }


    }
}
                                                                                               