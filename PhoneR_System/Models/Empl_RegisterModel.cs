

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneR_System.Models
{
    public class Empl_RegisterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_Reg_ID { get; set; }
        [Required]
        public Nullable<int> Rol_ID { get; set; }
        public virtual Role Role { get; set; }
        [Required]
        [DisplayName("FirstName")]
        public string FtName { get; set; }
        [Required]
        [DisplayName("LastName")]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DisplayName("Rate of pay")]
        public Nullable<decimal> Emp_Rate { get; set; }
        [Required]
        [DisplayName("Hours to work")]
        public Nullable<decimal> Emp_Hours { get; set; }
        [Required]
        [DisplayName("Employee Wage")]
        public Nullable<decimal> Emp_Wage { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Passward")]
        public string Pass { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("Pass")]
        [DisplayName("Conform Passward")]
        public string C_Pass { get; set; }



        //Calc Wage
        public Nullable<decimal> CalcWages()
        {
            return (Emp_Rate * Emp_Hours);
        }

    }
}
