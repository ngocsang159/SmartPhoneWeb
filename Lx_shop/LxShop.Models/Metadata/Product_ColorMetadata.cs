using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LxShop.Models.EF
{
    [MetadataType(typeof(Product_Color.Metadata))]
   public partial class Product_Color
    {

        public int? page_num { get; set; }
        public int? page_size { get; set; }
        sealed class Metadata
        {
            [DisplayName("Stt")]
            public long Stt { get; set; }
            [DisplayName("Id")]
            public string Color_Id { get; set; }
            [DisplayName("Tên màu")]
            public string Color_name { get; set; }
            [DisplayName("Id sản phẩm")]
            public Nullable<long> Product_Id { get; set; }
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
