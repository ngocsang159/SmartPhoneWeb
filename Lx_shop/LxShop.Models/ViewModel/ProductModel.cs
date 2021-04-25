using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Models.EF
{
    public class ProductModel
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public Product_Category_Type Product_Category_Type { get; set; }
        public Brand Brand { get; set; }
        public Product Product { get; set; }
    }
}
