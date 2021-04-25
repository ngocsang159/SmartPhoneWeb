using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LxShop.Models.EF
{
    [MetadataType(typeof(AccountAdmin.Metadata))]
    public partial  class AccountAdmin
    {
        
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        sealed class Metadata
        {
            public Nullable<long> stt { get; set; }
            [DisplayName("ID")]
            public long ID { get; set; }
            [DisplayName("Tên đăng nhập")]
            public string Username { get; set; }
            [DisplayName("Mật khẩu")]
            public string Password { get; set; }
            [DisplayName("Avatar")]
            public string Avatar { get; set; }
            [DisplayName("Giới tính")]
            public Nullable<int> Gender { get; set; }
            [DisplayName("Tên người dùng")]
            public string Displayname { get; set; }
            [DisplayName("Số điện thoại")]
            public Nullable<int> Phone { get; set; }
            [DisplayName("Facebook")]
            public string Facebook { get; set; }
            [DisplayName("Email")]
            public string Email { get; set; }
            [DisplayName("Địa chỉ")]
            public string Address { get; set; }
            [DisplayName("Trạng thái")]
            public Nullable<int> Status { get; set; }
            [DisplayName("Ngày tạo")]
            public Nullable<System.DateTime> CreateDate { get; set; }
            [DisplayName("Người tạo")]
            public string CreateBy { get; set; }
            [DisplayName("Ngày cập nhật")]
            public Nullable<System.DateTime> UpdatedDate { get; set; }
            [DisplayName("Người cập nhật")]
            public string UpdatedBy { get; set; }
            [DisplayName("Hoạt động")]
            public Nullable<bool> IsDeleted { get; set; }
        
        }
    }
}
