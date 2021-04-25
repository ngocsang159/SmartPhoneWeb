using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LxShop.Models.EF
{
    [MetadataType(typeof(Brand.Metadata))]
    public partial class Brand
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public class Metadata
        {
            //public long Stt { get; set; }
            [DisplayName("Id hãng")]
            public string Brand_id { get; set; }
            [DisplayName("Tên hãng")]
            public string Brand_name { get; set; }
            [DisplayName("Quốc gia")]
            public string Country { get; set; }
            [DisplayName("Trạng thái")]
            public Nullable<int> Status { get; set; }
            [DisplayName("Ngày tạo")]
            public Nullable<System.DateTime> CreateDate { get; set; }
            [DisplayName("Người tạo")]
            public string CreateBy { get; set; }
            [DisplayName("Ngày cập nhật")]
            public Nullable<System.DateTime> UpdateDate { get; set; }
            [DisplayName("Người cập nhật")]
            public string UpdateBy { get; set; }
            [DisplayName("Hoạt động")]
            public Nullable<bool> IsDelete { get; set; }
        }
    }
}
