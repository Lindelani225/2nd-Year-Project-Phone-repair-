//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PhoneR_System.Models
{
    public class storage
    {
        [Key]

        public int Storg_ID { get; set; }
        [DisplayName("Storage Size")]
        public string Storg_Name { get; set; }
        [DisplayName("Storage Rate")]
        public Nullable<decimal> Storg_Rate { get; set; }

    }
}
