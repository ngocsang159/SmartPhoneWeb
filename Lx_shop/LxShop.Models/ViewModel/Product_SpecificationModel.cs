using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Models.EF
{
    public class Product_SpecificationModel
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public Product _product { get; set; }
        public Product_Specifications product_Specifications { get; set; }
    }
}
