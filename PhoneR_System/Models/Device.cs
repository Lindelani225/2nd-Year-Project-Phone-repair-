

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneR_System.Models
{
    public class Device
    {
        [Key]
        public int Brand_ID { get; set; }
        [DisplayName("Brand Name")]
        public string Brand_Name { get; set; }
        [DisplayName("Brand Rate")]
        public Nullable<decimal> Brand_Rate { get; set; }
    }
}
