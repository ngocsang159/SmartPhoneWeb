using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxShop.Models.EF;
using PagedList;

namespace LxShop.Repositories
{
    public interface  IProduct_categoryRepository
    {
        IPagedList<Product_Category> PaggingProduct_category(Product_Category search1);
        List<Product_Category> ListProduct_Category();
    }
}
