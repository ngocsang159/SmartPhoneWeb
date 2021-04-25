using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LxShop.Models.EF
{
    [MetadataType(typeof(Product_Category_Type.Metadata))]
    public partial class Product_Category_Type
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public  class Metadata
        {
            [DisplayName("Stt")]
            public long Stt { get; set; }
            [DisplayName("Id loại danh mục")]
            public string Product_Category_TypeId { get; set; }
            [DisplayName("Tên loại danh mục")]
            public string Product_Category_TypeName { get; set; }
            [DisplayName("Id danh mục")]
            public string Product_CategoryId { get; set; }
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
