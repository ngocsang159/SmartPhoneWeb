//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class AccountAdmin
    {
        public Nullable<long> stt { get; set; }
        public long ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public Nullable<int> Gender { get; set; }
        public string Displayname { get; set; }
        public Nullable<int> Phone { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}