using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LxShop.Models.EF
{
    [MetadataType(typeof(Banner.Metadata))]
    public partial class Banner
    {
        public int? page_num  { get; set; }
        public int? page_size { get; set; }
        public class Metadata
        {
           // public long stt { get; set; }
           [DisplayName("Id Banner")]
            public string Banner_Id { get; set; }
            [DisplayName("Tên Banner")]
            public string Banner_Name { get; set; }
            [DisplayName("Tiêu đề")]
            public string Banner_Title { get; set; }
            [DisplayName("Loại banner")]
            public Nullable<int> Banner_Type { get; set; }
            [DisplayName("Ảnh")]
            public string Banner_Image { get; set; }
            [DisplayName("Sản phẩm")]
            public string Product_Id { get; set; }
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
            //[DisplayName("")]
            //public Nullable<bool> IsDeleted { get; set; }
        }
    }
}
