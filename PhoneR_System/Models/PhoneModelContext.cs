﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PhoneR_System.Models
{
    public class PHONEEntities : DbContext
    {
        public PHONEEntities() : base("PhoneDB")
        {


        }


        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Cust_RegisterModel> Cust_RegisterModel { get; set; }
        public virtual DbSet<Cust_Request> Cust_Request { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Empl_RegisterModel> Empl_RegisterModels { get; set; }
        public virtual DbSet<Operating_Sy> Operating_Sy { get; set; }
        public virtual DbSet<ProblemDesc> ProblemDescs { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<storage> storages { get; set; }
        public virtual DbSet<Cust_WalkIn> Cust_WalkIn { get; set; }
    }
}
