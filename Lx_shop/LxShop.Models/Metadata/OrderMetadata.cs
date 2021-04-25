using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; 

namespace LxShop.Models.EF
{
    [MetadataType(typeof(Order.Metadata))]
    public partial class Order
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        sealed class Metadata
        {
            [DisplayName("Id")]
            public long Order_id { get; set; }
            [DisplayName("Họ tên")]
            public string fullname { get; set; }
            [DisplayName("Số điện thoại")]
            public Nullable<long> phone { get; set; }
            [DisplayName("Email")]
            public string email { get; set; }
            [DisplayName("Tỉnh/Thành Phố")]
            public Nullable<long> ProvinceId { get; set; }
            [DisplayName("Quận/Huyện")]
            public Nullable<long> DistrictId { get; set; }
            [DisplayName("Địa chỉ")]
            public string Address { get; set; }
            [DisplayName("Ghi chú")]
            public string Note { get; set; }
            [DisplayName("Tình trạng")]
            public string Order_Status_Id { get; set; }
            [DisplayName("Khách hàng")]
            public string Customer_id { get; set; }
            [DisplayName("Trạng thái")]
            public int Status { get; set; }
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
