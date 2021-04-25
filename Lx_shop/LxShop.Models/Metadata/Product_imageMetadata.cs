using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LxShop.Models.EF
{
    [MetadataType(typeof(Product_image.Metadata))]
    public partial class Product_image
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        sealed class Metadata
        {
            [DisplayName("Stt")]
            public long Stt { get; set; }
            [DisplayName("Id ảnh")]
            public string Image_Id { get; set; }
            [DisplayName("Tên ảnh")]
            public string Image_Name { get; set; }
            [DisplayName("Link ảnh")]
            public string Image { get; set; }
            [DisplayName("Loại ảnh")]
            public string Image_Type { get; set; }
            [DisplayName("Id sản phẩm")]
            public Nullable<long> Product_Id { get; set; }
          
            [DisplayName("Mô tả")]
            public string Description { get; set; }
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
