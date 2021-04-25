using LxShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Models.EF
{
   public class ProductCategory_Type
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public Product_Category Product_Category { get; set; }
        public Product_Category_Type Product_Category_Type { get; set; }

        //public ProductCategory_Type()
        //{
        //    Product_Category = new Product_Category();
        //    Product_Category_Type = new Product_Category_Type();
        //}
    }
}
