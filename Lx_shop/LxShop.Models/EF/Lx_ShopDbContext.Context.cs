﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LxShop.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_smartphoneEntities : DbContext
    {
        public db_smartphoneEntities()
            : base("name=db_smartphoneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountAdmin> AccountAdmins { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_details> Order_details { get; set; }
        public virtual DbSet<Order_Status> Order_Status { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Category> Product_Category { get; set; }
        public virtual DbSet<Product_Category_Type> Product_Category_Type { get; set; }
        public virtual DbSet<Product_Color> Product_Color { get; set; }
        public virtual DbSet<Product_image> Product_image { get; set; }
        public virtual DbSet<Product_Specifications> Product_Specifications { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}