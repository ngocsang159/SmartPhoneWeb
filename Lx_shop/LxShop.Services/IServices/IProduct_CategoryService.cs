using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Models.EF;
using PagedList;

namespace LxShop.Services
{
   public interface  IProduct_categoryService
    {
        IPagedList<Product_Category> PaggingProduct_category(Product_Category search);
        List<Product_Category> ListProduct_Category();
    }
}
