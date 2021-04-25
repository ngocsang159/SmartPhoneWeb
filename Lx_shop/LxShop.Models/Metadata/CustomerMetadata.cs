using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LxShop.Models.EF
{
    [MetadataType(typeof(Customer.Metadata))]
    public partial class Customer
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public virtual ICollection<District> Districts { get; set; }
        public  class Metadata
        {
            
            [DisplayName("Id khách hàng")]
            public long Customer_id { get; set; }
            [DisplayName("Tên khách hàng")]
            public string Customer_name { get; set; }
            [DisplayName("Số điện thoại")]
            public Nullable<long> phone { get; set; }
            [DisplayName("Email")]
            public string email { get; set; }
            [DisplayName("Mật khẩu")]
            public string Password { get; set; }
            [DisplayName("Mã huyện")]
            public string DistrictId { get; set; }
            [DisplayName("Mã Tỉnh")]
            public string ProvinceId { get; set; }
            [DisplayName("Địa chỉ")]
            public string Address { get; set; }
            [DisplayName("Trạng thái")]
            public Nullable<int> Status { get; set; }
            [DisplayName("Ngày tạo")]
            public Nullable<System.DateTime> CreatedDate { get; set; }
            [DisplayName("Người tạo")]
            public string CreatedBy { get; set; }
            [DisplayName("Ngày cập nhật")]
            public Nullable<System.DateTime> UpdatedDate { get; set; }
            [DisplayName("Người cập nhật")]
            public string UpdatedBy { get; set; }
            [DisplayName("Hoạt động")]
            public Nullable<bool> IsDeleted { get; set; }

           
        }
    }
}
