

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneR_System.Models
{
    public class Cust_RegisterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_Reg_ID { get; set; }
        public Nullable<int> Rol_ID { get; set; }
        public virtual Role Role { get; set; }
        [DisplayName("FirstName")]
        [Required]
        public string FtName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Passward")]
        public string Pass { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Pass")]
        [DisplayName("Conform Passward")]

        public string C_Pass { get; set; }

        public string loggInError { get; set; }

    }
}
