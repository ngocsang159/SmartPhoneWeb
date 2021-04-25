using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace LxShop.Models.EF
{
    [MetadataType(typeof(Product_Specifications.Metadata))]
    public partial class Product_Specifications
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        sealed class Metadata
        {
            [DisplayName("Stt")]
            public long Stt { get; set; }
            [DisplayName("Id")]
            public string Specification_Id { get; set; }
            [DisplayName("Tên ")]
            public string Specification_Name { get; set; }
            [DisplayName("Màn hình")]
            public string Screen { get; set; }
            [DisplayName("Camera sau")]
            public string Camera_rear { get; set; }
            [DisplayName("Cam trước")]
            public string Camera_Selfie { get; set; }
            [DisplayName("Ram")]
            public string RAM { get; set; }
            [DisplayName("Bộ nhớ trong")]
            public string Internal_memory { get; set; }
            [DisplayName("CPU")]
            public string CPU { get; set; }
            [DisplayName("GPU")]
            public string GPU { get; set; }
            [DisplayName("Dung lượng pin")]
            public string Battery_capacity { get; set; }
            [DisplayName("SIM")]
            public string SIM { get; set; }
            [DisplayName("Hệ thống")]
            public string Operating_System { get; set; }
            [DisplayName("Sản xuất tại")]
            public string Made_In { get; set; }
            [DisplayName("Thời gian")]
            public Nullable<System.DateTime> Launch_Time { get; set; }
            [DisplayName("Id sản phẩm ")]
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
