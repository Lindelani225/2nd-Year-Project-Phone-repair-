

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneR_System.Models
{
    public class Cust_WalkIn
    {
        [Key]
        public int Walk_Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayName("WalkIn Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Walkin_Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Walk-In Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public Nullable<System.DateTime> Walkin_Time { get; set; }

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
        public string IMEI_Num { get; set; }
        [DisplayName("Walkin Price")]
        public Nullable<decimal> B_Price { get; set; }

        //get values from db
        PHONEEntities db = new PHONEEntities();
        public Nullable<decimal> getBrandRate()
        {
            return (db.Devices.Find(Brand_ID).Brand_Rate);
        }

        public Nullable<decimal> getProblemPr()
        {
            return (db.ProblemDescs.Find(Problem_ID).Problem_BscCost);
        }
        // Appointment Price
        public Nullable<decimal> CalcAppPrice()
        {
            return (getBrandRate() * getProblemPr());
        }

    }
}
