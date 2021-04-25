using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Models.EF
{
    public class Product_ImageModel
    {
        public int? page_num { get; set; }
        public int? page_size { get; set; }
        public Product_image  product_Image { get; set; }
        public Product product { get; set; }
        
    }
}
