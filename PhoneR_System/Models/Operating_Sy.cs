

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneR_System.Models
{
    public class Operating_Sy
    {
        [Key]
        public int OS_Id { get; set; }
        [DisplayName("Operating System")]
        public string Device_os { get; set; }
        [DisplayName("Rate")]
        public Nullable<decimal> OS_Rate { get; set; }


    }
}
