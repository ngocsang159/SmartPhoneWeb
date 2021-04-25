using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LxShop.Models.EF
{
    [MetadataType(typeof(Product.Metadata))]
    public partial class Product
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public class Metadata
        {
            [DisplayName("Stt")]
            public long Stt { get; set; }
            [DisplayName("ID")]
            public string Product_Id { get; set; }
            [DisplayName("Tên sản phẩm")]
            public string Product_Name { get; set; }
            [DisplayName("Ảnh")]
            public string ImgaeAvatar { get; set; }
            [DisplayName("Giá mới")]
            public Nullable<decimal> Price { get; set; }
            [DisplayName("Giá cũ")]
            public Nullable<decimal> Original_Price { get; set; }
            [DisplayName("Loại danh mục")]
            public string Product_Category_TypeId { get; set; }
            [DisplayName("Ngày áp dụng")]
            public Nullable<System.DateTime> ApplyDate { get; set; }
            [DisplayName("Hãng sản xuất")]
            public Nullable<long> Brand_id { get; set; }
            [DisplayName("Nổi bật")]
            public Nullable<int> Is_Hot { get; set; }
            [DisplayName("Mô tả")]
            [AllowHtml]
            public string Description { get; set; }
            [DisplayName("Thông tin")]
            public string Product_Infor { get; set; }
            [DisplayName("Tình trạng")]
            public Nullable<int> Old_New { get; set; }
            [DisplayName("Số lượng")]
            public Nullable<int> Quantity { get; set; }
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
